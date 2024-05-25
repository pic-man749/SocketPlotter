using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SocketPlotter {
    public partial class GraphWindow : Form {

        private readonly int BUFFER_MAX;
        private int plotRange;
        private bool isMarkerPlot;
        private bool isFullScaleBuffer;
        private bool isPlotting = false;
        private double lastChartTime = 0;

        private System.Timers.Timer chartRefreshTimer = new System.Timers.Timer();

        private Dictionary<string, Series> buffer = new Dictionary<string, Series>();

        public GraphWindow(int range, bool marker, bool fsBuf, int bufMax, Point stPos, int w) {
            plotRange = range;
            isMarkerPlot = marker;
            isFullScaleBuffer = fsBuf;
            BUFFER_MAX = bufMax;

            InitializeComponent();

            // init chart area
            chartDefault.Series.Clear();
            chartRefreshTimer.Elapsed += ChartUpdateTimerCallback;
            chartRefreshTimer.AutoReset = false;

            // init start position
            this.StartPosition = FormStartPosition.Manual;
            this.Location = stPos;
            this.Width = w;

            this.Show();
        }

        public void AddDatapointToSeries(double now, Dictionary<string, double> kvs) {

            foreach(string key in kvs.Keys) {
                // check key existance and set data
                if(!buffer.ContainsKey(key)) {
                    // make new series
                    buffer[key] = MakeNewSeries(key);
                    // set graph
                    chartDefault.Series.Add(buffer[key]);
                }
                DataPoint dp = new DataPoint(now, kvs[key]);
                buffer[key].Points.Add(dp);
            }
        }

        public void ClearChartSeries() {
            // clear points
            foreach(var s in chartDefault.Series) {
                s.Points.Clear();
            }
        }

        public void ClearChart() {
            chartDefault.Series.Clear();
            buffer.Clear();
        }

        public void SetPlotRange(int range) {
            plotRange = range;
        }

        public void SetIsFullScaleBuffer(bool f) {
            isFullScaleBuffer = f;
        }

        public void ChangeMarkerStyle(bool f) {

            isMarkerPlot = f;

            foreach(var s in buffer.Values) {
                s.MarkerStyle = isMarkerPlot ? MarkerStyle.Circle : MarkerStyle.None;
            }
        }

        public void SetUpdateChartPeriod(float p) {
            chartRefreshTimer.Interval = p;
        }

        public void BackupStopWatchTim() {
            lastChartTime = PlotStopwatch.ElapsedSec();
        }

        public void StartChartRefreshTimer() {
            chartRefreshTimer.Start();
        }

        public void StopChartRefreshTimer() {
            chartRefreshTimer.Stop();
        }

        public void SetIsPlotting(bool b) {
            isPlotting = b;
        }

        public void ChartUpdateTimerCallback(Object source, ElapsedEventArgs e) {
            this.Invoke((MethodInvoker)delegate { UpdateChart(PlotStopwatch.ElapsedSec()); });
            chartRefreshTimer.Start();
        }

        public void UpdateChart(double now) {
            // 1. add new point data
            ReceivedPacket rp;
            while(ReceivedPacketQueue.Take(out rp)) {
                Dictionary<string, double> kvs = new Dictionary<string, double>();
                foreach(var key in rp.data.Keys) {
                    double tmp;
                    // format : numeric string
                    if(double.TryParse(rp.data[key], out tmp)) {
                        kvs[key] = tmp;
                    } 
                    // format : double hex string
                    else if(String2Double(rp.data[key], out tmp)) {
                        kvs[key] = tmp;
                    }
                    // invalid format
                    else {
                        continue;
                    }
                }
                AddDatapointToSeries(rp.recvTime / 1000d, kvs);
            }

            // 2. move graph range of time span
            for(int cnt = 0; cnt < this.chartDefault.ChartAreas.Count; ++cnt) {
                this.chartDefault.ChartAreas[cnt].AxisX.Maximum = now;
                this.chartDefault.ChartAreas[cnt].AxisX.Minimum = now - plotRange;
            }

            // 3. delete old point data
            double bufferXSize = (isFullScaleBuffer) ? now - BUFFER_MAX : chartDefault.ChartAreas[0].AxisX.Minimum;
            foreach(string k in buffer.Keys) {
                while(true) {
                    // to prevent the line from breaking within the frame, leave one point outside the range.
                    if(buffer[k].Points.Count <= 1) {
                        break;
                    }
                    if(buffer[k].Points[1].XValue >= bufferXSize) {
                        break;
                    }
                    buffer[k].Points.RemoveAt(0);
                }
            }
            chartDefault.ResetAutoValues();
        }

        public void ChangePlotRange(int range) {
            SetPlotRange(range);
            double now = PlotStopwatch.ElapsedSec();
            if(!isPlotting) {
                now = lastChartTime;
            }
            for(int cnt = 0; cnt < this.chartDefault.ChartAreas.Count; ++cnt) {
                this.chartDefault.ChartAreas[cnt].AxisX.Maximum = now;
                this.chartDefault.ChartAreas[cnt].AxisX.Minimum = now - plotRange;
            }
        }

        public void ChangePlotAxis(string key, bool is2ndAxis) {
            if(buffer.ContainsKey(key)) buffer[key].YAxisType = is2ndAxis ? AxisType.Secondary : AxisType.Primary;
        }

        public void SetYScale(double min, double max, bool is2ndAxis) {
            for(int cnt = 0; cnt < this.chartDefault.ChartAreas.Count; ++cnt) {
                if(is2ndAxis) {
                    this.chartDefault.ChartAreas[cnt].AxisY2.Minimum = min;
                    this.chartDefault.ChartAreas[cnt].AxisY2.Maximum = max;
                } else {
                    this.chartDefault.ChartAreas[cnt].AxisY.Minimum = min;
                    this.chartDefault.ChartAreas[cnt].AxisY.Maximum = max;
                }
            }
        }

        public void SetSeriesEnable(string name, bool isEnable) {
            for(int cnt = 0; cnt < this.chartDefault.ChartAreas.Count; ++cnt) {
                foreach(var s in this.chartDefault.Series) {
                    if(s.LegendText == name) {
                        s.Enabled = isEnable;
                    }
                }
            }
        }

        // ref : https://stackoverflow.com/questions/33978447/display-tooltip-when-mouse-over-the-line-chart
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        private void Chart_MouseMove(object sender, MouseEventArgs e) {
            var pos = e.Location;
            if(prevPosition.HasValue && pos == prevPosition.Value) {
                return;
            }
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chartDefault.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach(var result in results) {
                if(result.ChartElementType == ChartElementType.DataPoint) {
                    var valueX = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var valueY = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    string s = $"({(float)valueX}, {(float)valueY})";
                    tooltip.Show(s, chartDefault, pos.X, pos.Y - 15);
                }
            }
        }

        private Series MakeNewSeries(string name) {
            Series seriesLine = new Series();
            seriesLine.ChartType = SeriesChartType.Line;
            seriesLine.LegendText = name;
            seriesLine.BorderWidth = 2;
            seriesLine.MarkerStyle = isMarkerPlot ? MarkerStyle.Circle : MarkerStyle.None;
            seriesLine.MarkerSize = 6;
            seriesLine.ChartArea = "ChartAreaDefault";
            return seriesLine;
        }

        private void GraphWindow_FormClosing(object sender, FormClosingEventArgs e) {
            // do not close
            e.Cancel = true;
        }

        private void GraphWindow_Shown(object sender, EventArgs e) {
            // window position setting
            int needRestorePosition = 0;
            foreach(Screen scr in Screen.AllScreens) {
                if(scr.WorkingArea.Contains(this.Location.X, this.Location.Y)) {
                    needRestorePosition++;
                }
            }
            if(needRestorePosition == 0) {
                this.Location = new System.Drawing.Point(110, 110);
            }
        }

        private bool String2Double(string str, out double tmp) {
            // length check
            if(str.Length != 16) {
                tmp = double.NaN;
                return false;
            }

            // hexString -> byte[]
            int numBytes = str.Length / 2;
            byte[] bytes = new byte[numBytes];
            for(int i = 0; i < numBytes; i++) {
                bytes[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
            }

            // byte[] -> double
            tmp = BitConverter.ToDouble(bytes, 0);
            return true;
        }
    }
}
