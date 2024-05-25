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

        Socket listener = null;
        Socket handler = null;
        CancellationTokenSource cts = new CancellationTokenSource();
        Thread threadPacketRecv = null;

        private GraphWindow graphWindow = null;

        private bool isPlotting = false;
        private int downSampleNum = 1;

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

                // clear chart
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
                        ReceivedPacket rp = new ReceivedPacket();
                        rp.Data = JsonSerializer.Deserialize<Dictionary<string, string>>(s + "}");
                        rp.recvTime = recvTime;
                        ReceivedPacketQueue.Add(rp);
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

    }
}
