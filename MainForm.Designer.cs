namespace SocketPlotter {
    partial class MainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.書式SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lSocketStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnListen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSocketPortNum = new System.Windows.Forms.TextBox();
            this.gbSocketType = new System.Windows.Forms.GroupBox();
            this.rbUDP = new System.Windows.Forms.RadioButton();
            this.rbTcp = new System.Windows.Forms.RadioButton();
            this.gbDetectedSeries = new System.Windows.Forms.GroupBox();
            this.btnDetectedSeriesAllUncheck = new System.Windows.Forms.Button();
            this.btnDetectedSeriesAllCheck = new System.Windows.Forms.Button();
            this.btnDetectedSeriesClear = new System.Windows.Forms.Button();
            this.tblSeries = new System.Windows.Forms.TableLayoutPanel();
            this.lDownSampling = new System.Windows.Forms.Label();
            this.lUseRightYAxis = new System.Windows.Forms.Label();
            this.lVisible = new System.Windows.Forms.Label();
            this.lSeriesName = new System.Windows.Forms.Label();
            this.lLatestValue = new System.Windows.Forms.Label();
            this.GBPlotSettings = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbDownSampling = new System.Windows.Forms.ComboBox();
            this.tbY2ndMax = new System.Windows.Forms.TextBox();
            this.tbY2ndMin = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbAutoScale2nd = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbDockingGeaphWindow = new System.Windows.Forms.CheckBox();
            this.tbYMax = new System.Windows.Forms.TextBox();
            this.tbYMin = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbAutoScale = new System.Windows.Forms.CheckBox();
            this.cbBufferFullScale = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbChartRefreshRate = new System.Windows.Forms.ComboBox();
            this.cbPlotMarker = new System.Windows.Forms.CheckBox();
            this.LabelPoltPoint = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TrackBarPlotTime = new System.Windows.Forms.TrackBar();
            this.BtnPlotReset = new System.Windows.Forms.Button();
            this.BtnPlotStart = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSocketType.SuspendLayout();
            this.gbDetectedSeries.SuspendLayout();
            this.tblSeries.SuspendLayout();
            this.GBPlotSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPlotTime)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.書式SToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 書式SToolStripMenuItem
            // 
            this.書式SToolStripMenuItem.Name = "書式SToolStripMenuItem";
            this.書式SToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.書式SToolStripMenuItem.Text = "書式(&S)";
            this.書式SToolStripMenuItem.Click += new System.EventHandler(this.FormatSToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lSocketStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnListen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbSocketPortNum);
            this.groupBox1.Location = new System.Drawing.Point(218, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Socket settings";
            // 
            // lSocketStatus
            // 
            this.lSocketStatus.AutoSize = true;
            this.lSocketStatus.Location = new System.Drawing.Point(308, 20);
            this.lSocketStatus.Name = "lSocketStatus";
            this.lSocketStatus.Size = new System.Drawing.Size(72, 12);
            this.lSocketStatus.TabIndex = 5;
            this.lSocketStatus.Text = "socketStatus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "status:";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(145, 15);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(100, 23);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "port:";
            // 
            // tbSocketPortNum
            // 
            this.tbSocketPortNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SocketPlotter.Properties.Settings.Default, "tbSocketPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbSocketPortNum.Location = new System.Drawing.Point(39, 18);
            this.tbSocketPortNum.MaxLength = 5;
            this.tbSocketPortNum.Name = "tbSocketPortNum";
            this.tbSocketPortNum.Size = new System.Drawing.Size(100, 19);
            this.tbSocketPortNum.TabIndex = 1;
            this.tbSocketPortNum.Text = global::SocketPlotter.Properties.Settings.Default.tbSocketPort;
            this.tbSocketPortNum.TextChanged += new System.EventHandler(this.tbSocketPortNum_TextChanged);
            // 
            // gbSocketType
            // 
            this.gbSocketType.Controls.Add(this.rbUDP);
            this.gbSocketType.Controls.Add(this.rbTcp);
            this.gbSocketType.Location = new System.Drawing.Point(12, 27);
            this.gbSocketType.Name = "gbSocketType";
            this.gbSocketType.Size = new System.Drawing.Size(200, 45);
            this.gbSocketType.TabIndex = 0;
            this.gbSocketType.TabStop = false;
            this.gbSocketType.Text = "Socket type";
            // 
            // rbUDP
            // 
            this.rbUDP.AutoSize = true;
            this.rbUDP.Location = new System.Drawing.Point(98, 18);
            this.rbUDP.Name = "rbUDP";
            this.rbUDP.Size = new System.Drawing.Size(46, 16);
            this.rbUDP.TabIndex = 2;
            this.rbUDP.Text = "UDP";
            this.rbUDP.UseVisualStyleBackColor = true;
            // 
            // rbTcp
            // 
            this.rbTcp.AutoSize = true;
            this.rbTcp.Checked = true;
            this.rbTcp.Location = new System.Drawing.Point(6, 18);
            this.rbTcp.Name = "rbTcp";
            this.rbTcp.Size = new System.Drawing.Size(45, 16);
            this.rbTcp.TabIndex = 1;
            this.rbTcp.TabStop = true;
            this.rbTcp.Text = "TCP";
            this.rbTcp.UseVisualStyleBackColor = true;
            // 
            // gbDetectedSeries
            // 
            this.gbDetectedSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbDetectedSeries.AutoSize = true;
            this.gbDetectedSeries.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbDetectedSeries.Controls.Add(this.btnDetectedSeriesAllUncheck);
            this.gbDetectedSeries.Controls.Add(this.btnDetectedSeriesAllCheck);
            this.gbDetectedSeries.Controls.Add(this.btnDetectedSeriesClear);
            this.gbDetectedSeries.Controls.Add(this.tblSeries);
            this.gbDetectedSeries.Location = new System.Drawing.Point(12, 205);
            this.gbDetectedSeries.Name = "gbDetectedSeries";
            this.gbDetectedSeries.Size = new System.Drawing.Size(760, 91);
            this.gbDetectedSeries.TabIndex = 202;
            this.gbDetectedSeries.TabStop = false;
            this.gbDetectedSeries.Text = "Detected series";
            // 
            // btnDetectedSeriesAllUncheck
            // 
            this.btnDetectedSeriesAllUncheck.Location = new System.Drawing.Point(130, 18);
            this.btnDetectedSeriesAllUncheck.Name = "btnDetectedSeriesAllUncheck";
            this.btnDetectedSeriesAllUncheck.Size = new System.Drawing.Size(118, 23);
            this.btnDetectedSeriesAllUncheck.TabIndex = 202;
            this.btnDetectedSeriesAllUncheck.Text = "all invisibe";
            this.btnDetectedSeriesAllUncheck.UseVisualStyleBackColor = true;
            this.btnDetectedSeriesAllUncheck.Click += new System.EventHandler(this.btnDetectedSeriesAllUncheck_Click);
            // 
            // btnDetectedSeriesAllCheck
            // 
            this.btnDetectedSeriesAllCheck.Location = new System.Drawing.Point(6, 18);
            this.btnDetectedSeriesAllCheck.Name = "btnDetectedSeriesAllCheck";
            this.btnDetectedSeriesAllCheck.Size = new System.Drawing.Size(118, 23);
            this.btnDetectedSeriesAllCheck.TabIndex = 201;
            this.btnDetectedSeriesAllCheck.Text = "all visible";
            this.btnDetectedSeriesAllCheck.UseVisualStyleBackColor = true;
            this.btnDetectedSeriesAllCheck.Click += new System.EventHandler(this.btnDetectedSeriesAllCheck_Click);
            // 
            // btnDetectedSeriesClear
            // 
            this.btnDetectedSeriesClear.Location = new System.Drawing.Point(634, 18);
            this.btnDetectedSeriesClear.Name = "btnDetectedSeriesClear";
            this.btnDetectedSeriesClear.Size = new System.Drawing.Size(120, 23);
            this.btnDetectedSeriesClear.TabIndex = 203;
            this.btnDetectedSeriesClear.Text = "clear";
            this.btnDetectedSeriesClear.UseVisualStyleBackColor = true;
            this.btnDetectedSeriesClear.Click += new System.EventHandler(this.btnDetectedSeriesClear_Click);
            // 
            // tblSeries
            // 
            this.tblSeries.AutoScroll = true;
            this.tblSeries.AutoSize = true;
            this.tblSeries.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblSeries.BackColor = System.Drawing.Color.White;
            this.tblSeries.ColumnCount = 5;
            this.tblSeries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tblSeries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblSeries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblSeries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblSeries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblSeries.Controls.Add(this.lDownSampling, 3, 0);
            this.tblSeries.Controls.Add(this.lUseRightYAxis, 2, 0);
            this.tblSeries.Controls.Add(this.lVisible, 1, 0);
            this.tblSeries.Controls.Add(this.lSeriesName, 0, 0);
            this.tblSeries.Controls.Add(this.lLatestValue, 4, 0);
            this.tblSeries.Location = new System.Drawing.Point(6, 47);
            this.tblSeries.Name = "tblSeries";
            this.tblSeries.RowCount = 1;
            this.tblSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblSeries.Size = new System.Drawing.Size(745, 26);
            this.tblSeries.TabIndex = 73;
            // 
            // lDownSampling
            // 
            this.lDownSampling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lDownSampling.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lDownSampling.Location = new System.Drawing.Point(508, 0);
            this.lDownSampling.Name = "lDownSampling";
            this.lDownSampling.Size = new System.Drawing.Size(114, 26);
            this.lDownSampling.TabIndex = 73;
            this.lDownSampling.Text = "downsampling";
            this.lDownSampling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lUseRightYAxis
            // 
            this.lUseRightYAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lUseRightYAxis.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lUseRightYAxis.Location = new System.Drawing.Point(388, 0);
            this.lUseRightYAxis.Name = "lUseRightYAxis";
            this.lUseRightYAxis.Size = new System.Drawing.Size(114, 26);
            this.lUseRightYAxis.TabIndex = 73;
            this.lUseRightYAxis.Text = "use 2nd Y axis";
            this.lUseRightYAxis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lVisible
            // 
            this.lVisible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lVisible.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lVisible.Location = new System.Drawing.Point(268, 0);
            this.lVisible.Name = "lVisible";
            this.lVisible.Size = new System.Drawing.Size(114, 26);
            this.lVisible.TabIndex = 73;
            this.lVisible.Text = "visible";
            this.lVisible.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lSeriesName
            // 
            this.lSeriesName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSeriesName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lSeriesName.Location = new System.Drawing.Point(3, 0);
            this.lSeriesName.Name = "lSeriesName";
            this.lSeriesName.Size = new System.Drawing.Size(259, 26);
            this.lSeriesName.TabIndex = 69;
            this.lSeriesName.Text = "series name";
            this.lSeriesName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lLatestValue
            // 
            this.lLatestValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lLatestValue.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline);
            this.lLatestValue.Location = new System.Drawing.Point(628, 0);
            this.lLatestValue.Name = "lLatestValue";
            this.lLatestValue.Size = new System.Drawing.Size(114, 26);
            this.lLatestValue.TabIndex = 74;
            this.lLatestValue.Text = "latest value";
            this.lLatestValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GBPlotSettings
            // 
            this.GBPlotSettings.Controls.Add(this.label12);
            this.GBPlotSettings.Controls.Add(this.cbDownSampling);
            this.GBPlotSettings.Controls.Add(this.tbY2ndMax);
            this.GBPlotSettings.Controls.Add(this.tbY2ndMin);
            this.GBPlotSettings.Controls.Add(this.label14);
            this.GBPlotSettings.Controls.Add(this.cbAutoScale2nd);
            this.GBPlotSettings.Controls.Add(this.label15);
            this.GBPlotSettings.Controls.Add(this.cbDockingGeaphWindow);
            this.GBPlotSettings.Controls.Add(this.tbYMax);
            this.GBPlotSettings.Controls.Add(this.tbYMin);
            this.GBPlotSettings.Controls.Add(this.label13);
            this.GBPlotSettings.Controls.Add(this.cbAutoScale);
            this.GBPlotSettings.Controls.Add(this.cbBufferFullScale);
            this.GBPlotSettings.Controls.Add(this.label9);
            this.GBPlotSettings.Controls.Add(this.cbChartRefreshRate);
            this.GBPlotSettings.Controls.Add(this.cbPlotMarker);
            this.GBPlotSettings.Controls.Add(this.LabelPoltPoint);
            this.GBPlotSettings.Controls.Add(this.label11);
            this.GBPlotSettings.Controls.Add(this.label6);
            this.GBPlotSettings.Controls.Add(this.TrackBarPlotTime);
            this.GBPlotSettings.Controls.Add(this.BtnPlotReset);
            this.GBPlotSettings.Controls.Add(this.BtnPlotStart);
            this.GBPlotSettings.Location = new System.Drawing.Point(12, 78);
            this.GBPlotSettings.Name = "GBPlotSettings";
            this.GBPlotSettings.Size = new System.Drawing.Size(760, 121);
            this.GBPlotSettings.TabIndex = 201;
            this.GBPlotSettings.TabStop = false;
            this.GBPlotSettings.Text = "Plot settings";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(526, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 12);
            this.label12.TabIndex = 79;
            this.label12.Text = "downsampling(1/n):";
            // 
            // cbDownSampling
            // 
            this.cbDownSampling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDownSampling.FormattingEnabled = true;
            this.cbDownSampling.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "30",
            "50",
            "100"});
            this.cbDownSampling.Location = new System.Drawing.Point(636, 93);
            this.cbDownSampling.Name = "cbDownSampling";
            this.cbDownSampling.Size = new System.Drawing.Size(97, 20);
            this.cbDownSampling.TabIndex = 124;
            // 
            // tbY2ndMax
            // 
            this.tbY2ndMax.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SocketPlotter.Properties.Settings.Default, "tbY2ndMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbY2ndMax.Location = new System.Drawing.Point(339, 93);
            this.tbY2ndMax.MaxLength = 16;
            this.tbY2ndMax.Name = "tbY2ndMax";
            this.tbY2ndMax.Size = new System.Drawing.Size(83, 19);
            this.tbY2ndMax.TabIndex = 114;
            this.tbY2ndMax.Text = global::SocketPlotter.Properties.Settings.Default.tbY2ndMax;
            this.tbY2ndMax.TextChanged += new System.EventHandler(this.tbY2ndMax_TextChanged);
            // 
            // tbY2ndMin
            // 
            this.tbY2ndMin.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SocketPlotter.Properties.Settings.Default, "tbY2ndMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbY2ndMin.Location = new System.Drawing.Point(226, 93);
            this.tbY2ndMin.MaxLength = 16;
            this.tbY2ndMin.Name = "tbY2ndMin";
            this.tbY2ndMin.Size = new System.Drawing.Size(84, 19);
            this.tbY2ndMin.TabIndex = 113;
            this.tbY2ndMin.Text = global::SocketPlotter.Properties.Settings.Default.tbY2ndMin;
            this.tbY2ndMin.TextChanged += new System.EventHandler(this.tbY2ndMin_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(316, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 75;
            this.label14.Text = "～";
            // 
            // cbAutoScale2nd
            // 
            this.cbAutoScale2nd.AutoSize = true;
            this.cbAutoScale2nd.Checked = global::SocketPlotter.Properties.Settings.Default.cbAutoScale2nd;
            this.cbAutoScale2nd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoScale2nd.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SocketPlotter.Properties.Settings.Default, "cbAutoScale2nd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAutoScale2nd.Location = new System.Drawing.Point(428, 95);
            this.cbAutoScale2nd.Name = "cbAutoScale2nd";
            this.cbAutoScale2nd.Size = new System.Drawing.Size(77, 16);
            this.cbAutoScale2nd.TabIndex = 116;
            this.cbAutoScale2nd.Text = "auto scale";
            this.cbAutoScale2nd.UseVisualStyleBackColor = true;
            this.cbAutoScale2nd.CheckedChanged += new System.EventHandler(this.cbAutoScale2nd_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(132, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 12);
            this.label15.TabIndex = 73;
            this.label15.Text = "plot range(2nd)";
            // 
            // cbDockingGeaphWindow
            // 
            this.cbDockingGeaphWindow.AutoSize = true;
            this.cbDockingGeaphWindow.Checked = true;
            this.cbDockingGeaphWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDockingGeaphWindow.Location = new System.Drawing.Point(528, 40);
            this.cbDockingGeaphWindow.Name = "cbDockingGeaphWindow";
            this.cbDockingGeaphWindow.Size = new System.Drawing.Size(136, 16);
            this.cbDockingGeaphWindow.TabIndex = 122;
            this.cbDockingGeaphWindow.Text = "docking graph window";
            this.cbDockingGeaphWindow.UseVisualStyleBackColor = true;
            this.cbDockingGeaphWindow.CheckedChanged += new System.EventHandler(this.cbDockingGeaphWindow_CheckedChanged);
            // 
            // tbYMax
            // 
            this.tbYMax.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SocketPlotter.Properties.Settings.Default, "tbYMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbYMax.Location = new System.Drawing.Point(339, 68);
            this.tbYMax.MaxLength = 16;
            this.tbYMax.Name = "tbYMax";
            this.tbYMax.Size = new System.Drawing.Size(83, 19);
            this.tbYMax.TabIndex = 112;
            this.tbYMax.Text = global::SocketPlotter.Properties.Settings.Default.tbYMax;
            this.tbYMax.TextChanged += new System.EventHandler(this.tbYMax_TextChanged);
            // 
            // tbYMin
            // 
            this.tbYMin.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SocketPlotter.Properties.Settings.Default, "tbYMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbYMin.Location = new System.Drawing.Point(226, 68);
            this.tbYMin.MaxLength = 16;
            this.tbYMin.Name = "tbYMin";
            this.tbYMin.Size = new System.Drawing.Size(84, 19);
            this.tbYMin.TabIndex = 111;
            this.tbYMin.Text = global::SocketPlotter.Properties.Settings.Default.tbYMin;
            this.tbYMin.TextChanged += new System.EventHandler(this.tbYMin_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(316, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 64;
            this.label13.Text = "～";
            // 
            // cbAutoScale
            // 
            this.cbAutoScale.AutoSize = true;
            this.cbAutoScale.Checked = global::SocketPlotter.Properties.Settings.Default.cbAutoScale;
            this.cbAutoScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoScale.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SocketPlotter.Properties.Settings.Default, "cbAutoScale", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAutoScale.Location = new System.Drawing.Point(428, 70);
            this.cbAutoScale.Name = "cbAutoScale";
            this.cbAutoScale.Size = new System.Drawing.Size(77, 16);
            this.cbAutoScale.TabIndex = 115;
            this.cbAutoScale.Text = "auto scale";
            this.cbAutoScale.UseVisualStyleBackColor = true;
            this.cbAutoScale.CheckedChanged += new System.EventHandler(this.cbAutoScale_CheckedChanged);
            // 
            // cbBufferFullScale
            // 
            this.cbBufferFullScale.AutoSize = true;
            this.cbBufferFullScale.Checked = true;
            this.cbBufferFullScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBufferFullScale.Location = new System.Drawing.Point(616, 18);
            this.cbBufferFullScale.Name = "cbBufferFullScale";
            this.cbBufferFullScale.Size = new System.Drawing.Size(105, 16);
            this.cbBufferFullScale.TabIndex = 121;
            this.cbBufferFullScale.Text = "buffer full scale";
            this.cbBufferFullScale.UseVisualStyleBackColor = true;
            this.cbBufferFullScale.CheckedChanged += new System.EventHandler(this.cbBufferFullScale_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(526, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 12);
            this.label9.TabIndex = 61;
            this.label9.Text = "refresh rate(Hz):";
            // 
            // cbChartRefreshRate
            // 
            this.cbChartRefreshRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChartRefreshRate.FormattingEnabled = true;
            this.cbChartRefreshRate.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20",
            "30",
            "60",
            "120"});
            this.cbChartRefreshRate.Location = new System.Drawing.Point(636, 68);
            this.cbChartRefreshRate.Name = "cbChartRefreshRate";
            this.cbChartRefreshRate.Size = new System.Drawing.Size(97, 20);
            this.cbChartRefreshRate.TabIndex = 123;
            // 
            // cbPlotMarker
            // 
            this.cbPlotMarker.AutoSize = true;
            this.cbPlotMarker.Checked = true;
            this.cbPlotMarker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPlotMarker.Location = new System.Drawing.Point(528, 18);
            this.cbPlotMarker.Name = "cbPlotMarker";
            this.cbPlotMarker.Size = new System.Drawing.Size(82, 16);
            this.cbPlotMarker.TabIndex = 120;
            this.cbPlotMarker.Text = "plot marker";
            this.cbPlotMarker.UseVisualStyleBackColor = true;
            this.cbPlotMarker.CheckedChanged += new System.EventHandler(this.cbPlotMarker_CheckedChanged);
            // 
            // LabelPoltPoint
            // 
            this.LabelPoltPoint.AutoSize = true;
            this.LabelPoltPoint.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelPoltPoint.Location = new System.Drawing.Point(471, 26);
            this.LabelPoltPoint.Name = "LabelPoltPoint";
            this.LabelPoltPoint.Size = new System.Drawing.Size(34, 15);
            this.LabelPoltPoint.TabIndex = 58;
            this.LabelPoltPoint.Text = "num";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(132, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 12);
            this.label11.TabIndex = 55;
            this.label11.Text = "plot range(prim):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 12);
            this.label6.TabIndex = 55;
            this.label6.Text = "plot time:";
            // 
            // TrackBarPlotTime
            // 
            this.TrackBarPlotTime.Location = new System.Drawing.Point(193, 18);
            this.TrackBarPlotTime.Maximum = 31;
            this.TrackBarPlotTime.Minimum = 1;
            this.TrackBarPlotTime.Name = "TrackBarPlotTime";
            this.TrackBarPlotTime.Size = new System.Drawing.Size(272, 45);
            this.TrackBarPlotTime.TabIndex = 110;
            this.TrackBarPlotTime.Value = 1;
            this.TrackBarPlotTime.ValueChanged += new System.EventHandler(this.TrackBarPlotTime_ValueChanged);
            // 
            // BtnPlotReset
            // 
            this.BtnPlotReset.Location = new System.Drawing.Point(6, 47);
            this.BtnPlotReset.Name = "BtnPlotReset";
            this.BtnPlotReset.Size = new System.Drawing.Size(120, 23);
            this.BtnPlotReset.TabIndex = 102;
            this.BtnPlotReset.Text = "reset";
            this.BtnPlotReset.UseVisualStyleBackColor = true;
            this.BtnPlotReset.Click += new System.EventHandler(this.BtnPlotReset_Click);
            // 
            // BtnPlotStart
            // 
            this.BtnPlotStart.Enabled = false;
            this.BtnPlotStart.Location = new System.Drawing.Point(6, 18);
            this.BtnPlotStart.Name = "BtnPlotStart";
            this.BtnPlotStart.Size = new System.Drawing.Size(120, 23);
            this.BtnPlotStart.TabIndex = 101;
            this.BtnPlotStart.Text = "plot start";
            this.BtnPlotStart.UseVisualStyleBackColor = true;
            this.BtnPlotStart.Click += new System.EventHandler(this.BtnPlotStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 305);
            this.Controls.Add(this.gbDetectedSeries);
            this.Controls.Add(this.GBPlotSettings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbSocketType);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::SocketPlotter.Properties.Settings.Default, "WindowLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::SocketPlotter.Properties.Settings.Default.WindowLocation;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 344);
            this.Name = "MainForm";
            this.Text = "SocketPlotter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Move += new System.EventHandler(this.DockingGraphWindowEventCallback);
            this.Resize += new System.EventHandler(this.DockingGraphWindowEventCallback);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSocketType.ResumeLayout(false);
            this.gbSocketType.PerformLayout();
            this.gbDetectedSeries.ResumeLayout(false);
            this.gbDetectedSeries.PerformLayout();
            this.tblSeries.ResumeLayout(false);
            this.GBPlotSettings.ResumeLayout(false);
            this.GBPlotSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPlotTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 書式SToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSocketPortNum;
        private System.Windows.Forms.GroupBox gbSocketType;
        private System.Windows.Forms.RadioButton rbUDP;
        private System.Windows.Forms.RadioButton rbTcp;
        private System.Windows.Forms.Label lSocketStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbDetectedSeries;
        private System.Windows.Forms.Button btnDetectedSeriesAllUncheck;
        private System.Windows.Forms.Button btnDetectedSeriesAllCheck;
        private System.Windows.Forms.Button btnDetectedSeriesClear;
        private System.Windows.Forms.TableLayoutPanel tblSeries;
        private System.Windows.Forms.Label lDownSampling;
        private System.Windows.Forms.Label lUseRightYAxis;
        private System.Windows.Forms.Label lVisible;
        private System.Windows.Forms.Label lSeriesName;
        private System.Windows.Forms.Label lLatestValue;
        private System.Windows.Forms.GroupBox GBPlotSettings;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbDownSampling;
        private System.Windows.Forms.TextBox tbY2ndMax;
        private System.Windows.Forms.TextBox tbY2ndMin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbAutoScale2nd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cbDockingGeaphWindow;
        private System.Windows.Forms.TextBox tbYMax;
        private System.Windows.Forms.TextBox tbYMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbAutoScale;
        private System.Windows.Forms.CheckBox cbBufferFullScale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbChartRefreshRate;
        private System.Windows.Forms.CheckBox cbPlotMarker;
        private System.Windows.Forms.Label LabelPoltPoint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar TrackBarPlotTime;
        private System.Windows.Forms.Button BtnPlotReset;
        private System.Windows.Forms.Button BtnPlotStart;
    }
}

