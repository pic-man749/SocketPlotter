using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketPlotter {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();

            UserInit();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            // window position setting
            int needRestorePosition = 0;
            foreach(Screen scr in Screen.AllScreens) {
                if(scr.WorkingArea.Contains(this.Location.X, this.Location.Y)) {
                    needRestorePosition++;
                }
            }
            if(needRestorePosition == 0) {
                this.Location = new System.Drawing.Point(100, 100);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            cts.Cancel();
            isPlotting = false;
            graphWindow.SetIsPlotting(isPlotting);
            graphWindow.StopChartRefreshTimer();
            listener?.Close();
            handler?.Close();
            Properties.Settings.Default.Save();
        }

        private void btnListen_Click(object sender, EventArgs e) {
            ProcBtnConnectClick();
        }

        private void BtnPlotStart_Click(object sender, EventArgs e) {
            ProcBtnStartClick();
        }

        private void BtnPlotReset_Click(object sender, EventArgs e) {
            graphWindow.ClearChartSeries();
        }

        private void btnDetectedSeriesAllCheck_Click(object sender, EventArgs e) {

        }

        private void btnDetectedSeriesAllUncheck_Click(object sender, EventArgs e) {

        }

        private void btnDetectedSeriesClear_Click(object sender, EventArgs e) {

        }

        private void TrackBarPlotTime_ValueChanged(object sender, EventArgs e) {
            UpdateTrackBarValue();
        }

        private void tbSocketPortNum_TextChanged(object sender, EventArgs e) {
            Validation.TryPaesePortNum(tbSocketPortNum);
        }

        private void tbYMin_TextChanged(object sender, EventArgs e) {
            Validation.TryPaeseDouble((TextBox)sender, out _);
        }

        private void tbYMax_TextChanged(object sender, EventArgs e) {
            Validation.TryPaeseDouble((TextBox)sender, out _);
        }

        private void tbY2ndMin_TextChanged(object sender, EventArgs e) {
            Validation.TryPaeseDouble((TextBox)sender, out _);
        }

        private void tbY2ndMax_TextChanged(object sender, EventArgs e) {
            Validation.TryPaeseDouble((TextBox)sender, out _);
        }

        private void cbAutoScale_CheckedChanged(object sender, EventArgs e) {
            SetYScale();
        }

        private void cbAutoScale2nd_CheckedChanged(object sender, EventArgs e) {
            Set2ndYScale();
        }

        private void DockingGraphWindowEventCallback(object sender, EventArgs e) {
            if(cbDockingGeaphWindow.Checked && graphWindow != null) {
                graphWindow.Activate();
                int x = this.Location.X;
                int y = this.Location.Y + this.Height;
                graphWindow.Location = new Point(x, y);
                graphWindow.Width = this.Width;
            }
        }

        private void cbPlotMarker_CheckedChanged(object sender, EventArgs e) {
            graphWindow.ChangeMarkerStyle(cbPlotMarker.Checked);
        }

        private void cbBufferFullScale_CheckedChanged(object sender, EventArgs e) {
            graphWindow.SetIsFullScaleBuffer(cbBufferFullScale.Checked);
        }

        private void cbDockingGeaphWindow_CheckedChanged(object sender, EventArgs e) {
            if(cbDockingGeaphWindow.Checked) {
                DockingGraphWindowEventCallback(sender, e);
            }
        }

        private void FormatSToolStripMenuItem_Click(object sender, EventArgs e) {
            FormatWindow _ = new FormatWindow();
        }
    }
}
