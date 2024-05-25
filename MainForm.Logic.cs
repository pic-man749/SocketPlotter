using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SocketPlotter {
    public partial class MainForm {

        // socket 
        Socket listener = null;
        Socket handler = null;
        CancellationTokenSource cts = new CancellationTokenSource();
        Thread threadPacketRecv = null;

        // graph window
        private GraphWindow graphWindow = null;

        // status
        private bool isPlotting = false;
        private int downSampleNum = 1;

        // series table
        private struct TableRow {
            public CheckBox cbSeriesEnable;
            public CheckBox cbSeriesUse2ndYAxis;
            public CheckBox cbDownSampling;
            public Label lSeriesLatestValue;
        }
        private Dictionary<string, TableRow> dictTableRows = new Dictionary<string, TableRow>();
        private List<string> knownKeyList = new List<string>();

        private void UserInit() {
            // show graph window
            graphWindow = new GraphWindow(
                                    TrackBarPlotTime.Value,
                                    cbPlotMarker.Checked,
                                    cbBufferFullScale.Checked,
                                    TrackBarPlotTime.Maximum);

            // init UI view
            UpdateTrackBarValue();
            UpdateCtrlText(lSocketStatus, "disconnected");

            // select comb box default
            cbChartRefreshRate.SelectedIndex = 4;   // 30
            cbDownSampling.SelectedIndex = 0;       // 1

            // init tb
            if(cbAutoScale.Checked) {
                tbYMax.Enabled = false;
                tbYMin.Enabled = false;
            }
            if(cbAutoScale2nd.Checked) {
                tbY2ndMax.Enabled = false;
                tbY2ndMin.Enabled = false;
            }
        }
        
        private void ProcBtnConnectClick() {
            if(btnListen.Text == "Listen") {
                // validation
                int portNum;
                if(!Validation.TryPaesePortNum(tbSocketPortNum, out portNum)) {
                    General.ShowErrMsgBox("Invalid port num.");
                    return;
                }

                // clear queue
                ReceivedPacketQueue.Clear();

                // clear chart and table
                knownKeyList.Clear();
                graphWindow.ClearChart();
                graphWindow.SetIsPlotting(true);
                graphWindow.BackupStopWatchTim();
                graphWindow.SetUpdateChartPeriod(GetChartRefreshRatePeriod());
                PlotStopwatch.Clear();
                graphWindow.StartChartRefreshTimer();
                PlotStopwatch.Start();

                // start plot
                ProcBtnStartClick();

                // connect
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, portNum);
                ProtocolType pt = GetSelectedProtocoleType();
                if(pt == ProtocolType.Tcp) {
                    listener = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, pt);
                } else {
                    listener = new Socket(SocketType.Dgram, pt);
                }
                listener.Bind(ipEndPoint);

                // start recv thread
                cts = new CancellationTokenSource();
                threadPacketRecv = new Thread(new ThreadStart(this.ThreadPacketRecv));
                threadPacketRecv.Start();

                ChangeUIEnable(true);
                btnListen.Text = "Close";
            } else {
                if(isPlotting) {
                    // stop plot
                    ProcBtnStartClick();
                }
                cts.Cancel();

                if(handler != null) {
                    handler.Close();
                }
                listener.Close();
                handler = null;
                listener = null;

                graphWindow.SetIsPlotting(false);
                graphWindow.BackupStopWatchTim();
                graphWindow.StopChartRefreshTimer();
                PlotStopwatch.Stop();

                ChangeUIEnable(false);
                UpdateCtrlText(lSocketStatus, "disconnected");
                btnListen.Text = "Listen";
            }
        }

        private void ThreadPacketRecv() {

            try {
                if(listener.ProtocolType == ProtocolType.Tcp) {
                    // wait for connection
                    UpdateCtrlText(lSocketStatus, "waiting connection...");
                    listener.Listen(10);
                    handler = listener.Accept();
                    UpdateCtrlText(lSocketStatus, "established");
                } else {
                    UpdateCtrlText(lSocketStatus, "listen");
                    handler = listener;
                }

                while(!cts.Token.IsCancellationRequested) {
                    // wait for data recv
                    byte[] buffer = new byte[2_048];
                    int received = handler.Receive(buffer, SocketFlags.None);
                    long recvTime = PlotStopwatch.Elapsed();
                    string str = Encoding.UTF8.GetString(buffer, 0, received);

                    foreach(var s in str.Split('}')) {
                        if(!s.StartsWith("{")) {
                            continue;
                        }
                        ReceivedPacket rp = new ReceivedPacket {
                            data = JsonSerializer.Deserialize<Dictionary<string, string>>(s + "}"),
                            recvTime = recvTime
                        };
                        if(rp.data.ContainsKey("type")) {
                            switch(rp.data["type"]) {
                                case "data":
                                    foreach(var key in rp.data.Keys) {
                                        // if special keys, then skip
                                        if(key == "type" || key == "id") {
                                            continue;
                                        }
                                        // is new key? then add keyList and series table row
                                        if(!knownKeyList.Contains(key)) {
                                            knownKeyList.Add(key);
                                            // DictDownSamplingCounter[key] = downSampleNum;
                                            AddNewSeries(key);
                                            // isNeedRefresh = true;
                                        }
                                    }
                                    ReceivedPacketQueue.Add(rp);
                                    break;
                                case "start":
                                    if(!isPlotting) {
                                        this.Invoke((MethodInvoker)delegate { ProcBtnStartClick(); });
                                    }
                                    break;
                                case "stop":
                                    if(isPlotting) {
                                        this.Invoke((MethodInvoker)delegate { ProcBtnStartClick(); });
                                    }
                                    break;
                                case "exit":
                                    this.Invoke((MethodInvoker)delegate { ProcBtnConnectClick(); });
                                    return;
                                    break;
                                default :
                                    // nothing to do
                                    break;
                            }
                        }
                    }
                }
            }catch (Exception ex) {
                return;
            }
        }

        private void ProcBtnStartClick() {
            isPlotting = !isPlotting;
            graphWindow.SetIsPlotting(isPlotting);
            cbChartRefreshRate.Enabled = !isPlotting;
            cbDownSampling.Enabled = !isPlotting;
            graphWindow.BackupStopWatchTim();
            if(isPlotting) {
                BtnPlotStart.Text = "plot stop";
                downSampleNum = int.Parse((string)cbDownSampling.SelectedItem);
                graphWindow.SetUpdateChartPeriod(GetChartRefreshRatePeriod());
                graphWindow.StartChartRefreshTimer();
            } else {
                BtnPlotStart.Text = "plot start";
                graphWindow.StopChartRefreshTimer();
            }
        }

        private void SetYScale() {
            double min = double.NaN;
            double max = double.NaN;
            if(!cbAutoScale.Checked) {
                tbYMax.Enabled = true;
                tbYMin.Enabled = true;
                try {
                    // parse and validation
                    double _min = double.Parse(tbYMin.Text);
                    double _max = double.Parse(tbYMax.Text);
                    if(_min < _max) {
                        min = _min;
                        max = _max;
                    }
                } catch {
                    min = double.NaN;
                    max = double.NaN;
                }
            } else {
                tbYMax.Enabled = false;
                tbYMin.Enabled = false;
            }
            graphWindow.SetYScale(min, max, false);
        }
        private void Set2ndYScale() {
            double min = double.NaN;
            double max = double.NaN;
            if(!cbAutoScale2nd.Checked) {
                tbY2ndMin.Enabled = true;
                tbY2ndMax.Enabled = true;
                try {
                    // parse and validation
                    double _min = double.Parse(tbY2ndMin.Text);
                    double _max = double.Parse(tbY2ndMax.Text);
                    if(_min < _max) {
                        min = _min;
                        max = _max;
                    }
                } catch {
                    min = double.NaN;
                    max = double.NaN;
                }
            } else {
                tbY2ndMax.Enabled = false;
                tbY2ndMin.Enabled = false;
            }
            graphWindow.SetYScale(min, max, true);
        }

        private void AddNewSeries(string key) {
            if(this.InvokeRequired) {
                this.BeginInvoke((MethodInvoker)delegate { AddNewSeries(key); });
            } else {
                if(dictTableRows.Keys.Contains(key)) {
                    graphWindow.SetSeriesEnable(key, dictTableRows[key].cbSeriesEnable.Checked);
                    graphWindow.ChangePlotAxis(key, dictTableRows[key].cbSeriesUse2ndYAxis.Checked);
                    return;
                }

                // add row
                tblSeries.RowCount += 1;
                tblSeries.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                this.tblSeries.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
                this.tblSeries.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
                this.tblSeries.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
                this.tblSeries.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));

                int nowRow = tblSeries.RowCount - 1;
                int colCount = 0;

                // make new series label
                Label l = new Label();
                l.Text = key;
                l.Dock = System.Windows.Forms.DockStyle.Fill;
                l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                tblSeries.Controls.Add(l, colCount++, nowRow);

                // make visible CheckBox and add Dict
                CheckBox cbVisible = new CheckBox();
                cbVisible.Checked = true;
                cbVisible.Name = key;
                cbVisible.Dock = System.Windows.Forms.DockStyle.Fill;
                cbVisible.CheckedChanged += ChangeSeriesVisibleCb;
                cbVisible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tblSeries.Controls.Add(cbVisible, colCount++, nowRow);

                // make 2ndAxis CheckBox and add Dict
                CheckBox cb2ndAxis = new CheckBox();
                cb2ndAxis.Checked = false;
                cb2ndAxis.Name = key;
                cb2ndAxis.Dock = System.Windows.Forms.DockStyle.Fill;
                cb2ndAxis.CheckedChanged += ChangeSeries2ndAxisCb;
                cb2ndAxis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tblSeries.Controls.Add(cb2ndAxis, colCount++, nowRow);

                // make down sampling CheckBox and add Dict
                CheckBox cbDownSampling = new CheckBox();
                cbDownSampling.Checked = true;
                cbDownSampling.Name = key;
                cbDownSampling.Dock = System.Windows.Forms.DockStyle.Fill;
                cbDownSampling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tblSeries.Controls.Add(cbDownSampling, colCount++, nowRow);

                // make new latest value label
                Label llv = new Label();
                llv.Text = "0.0";
                llv.Dock = System.Windows.Forms.DockStyle.Fill;
                llv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                tblSeries.Controls.Add(llv, colCount++, nowRow);

                TableRow tr = new TableRow();
                tr.cbSeriesEnable = cbVisible;
                tr.cbSeriesUse2ndYAxis = cb2ndAxis;
                tr.cbDownSampling = cbDownSampling;
                tr.lSeriesLatestValue = llv;

                dictTableRows.Add(key, tr);
            }
        }

        // --------------------------------------------------
        // misc functions
        // --------------------------------------------------
        private void UpdateTrackBarValue() {
            int range = TrackBarPlotTime.Value;
            LabelPoltPoint.Text = range.ToString();
            graphWindow.ChangePlotRange(range);
        }

        private ProtocolType GetSelectedProtocoleType() {
            if(rbTcp.Checked) {
                return ProtocolType.Tcp;
            } else {
                return ProtocolType.Udp;
            }
        }

        private float GetChartRefreshRatePeriod() {
            string hzValStr = cbChartRefreshRate.SelectedItem.ToString();
            float hzVal = float.Parse(hzValStr);
            return 1000f / hzVal;
        }

        private void ChangeUIEnable(bool isSocketOpen) {
            // open -> disable
            gbSocketType.Enabled = !isSocketOpen;
            tbSocketPortNum.Enabled = !isSocketOpen;

            // open -> enable
            BtnPlotStart.Enabled = isSocketOpen;
        }

        private void UpdateCtrlText(Control ctrl, string str) {
            if(ctrl.InvokeRequired) {
                Action safeWrite = delegate { UpdateCtrlText(ctrl, str); };
                ctrl.Invoke(safeWrite);
            } else {
                ctrl.Text = str;
            }
        }

        private void ChangeSeriesVisibleCb(object sender, EventArgs e) {
            var s = (CheckBox)sender;
            graphWindow.SetSeriesEnable(s.Name, s.Checked);
        }

        private void ChangeSeries2ndAxisCb(object sender, EventArgs e) {
            var s = (CheckBox)sender;
            graphWindow.ChangePlotAxis(s.Name, s.Checked);
        }
    }
}
