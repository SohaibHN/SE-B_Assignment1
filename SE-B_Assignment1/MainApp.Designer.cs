namespace SE_B_Assignment1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HeartRateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpeedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CadenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AltitudeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PowerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DateOfFile = new System.Windows.Forms.Label();
            this.StartTime = new System.Windows.Forms.Label();
            this.EndTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MaxHR = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MinHR = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BPM = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AvgSpeed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Distance = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.MaxSpeed = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.MaxPower = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AvgPower = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.MaxAlt = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.AvgAlt = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.MPHRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.KMRadio = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CompareGridView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.SummarySec1 = new System.Windows.Forms.NumericUpDown();
            this.SummarySections = new System.Windows.Forms.DataGridView();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.FTPCalc = new System.Windows.Forms.Button();
            this.FTPLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.BPMCalc = new System.Windows.Forms.Button();
            this.HRCalcLabel = new System.Windows.Forms.Label();
            this.FTPInput = new System.Windows.Forms.NumericUpDown();
            this.HRUserInput = new System.Windows.Forms.NumericUpDown();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NormalPower = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.DetectedIntervalBox = new System.Windows.Forms.ListBox();
            this.IFLabel = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.TSSLabel = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.ViewIntervalDetails = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompareGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SummarySec1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SummarySections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTPInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRUserInput)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1170, 395);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            this.zedGraphControl1.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.zedGraphControl1_ZoomEvent);
            this.zedGraphControl1.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedGraphControl1_MouseDownEvent);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.compareFilesToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1534, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.loadFileToolStripMenuItem.Text = "Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFileToolStripMenuItem_Click);
            // 
            // compareFilesToolStripMenuItem
            // 
            this.compareFilesToolStripMenuItem.Name = "compareFilesToolStripMenuItem";
            this.compareFilesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.compareFilesToolStripMenuItem.Text = "Compare Files";
            this.compareFilesToolStripMenuItem.Click += new System.EventHandler(this.compareFilesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HeartRateMenuItem,
            this.SpeedMenuItem,
            this.CadenceMenuItem,
            this.AltitudeMenuItem,
            this.PowerMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(96, 20);
            this.toolStripMenuItem1.Text = "Graph Options";
            // 
            // HeartRateMenuItem
            // 
            this.HeartRateMenuItem.Checked = true;
            this.HeartRateMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HeartRateMenuItem.Name = "HeartRateMenuItem";
            this.HeartRateMenuItem.Size = new System.Drawing.Size(129, 22);
            this.HeartRateMenuItem.Text = "Heart Rate";
            this.HeartRateMenuItem.Click += new System.EventHandler(this.HeartRateMenuItem_Click);
            // 
            // SpeedMenuItem
            // 
            this.SpeedMenuItem.Name = "SpeedMenuItem";
            this.SpeedMenuItem.Size = new System.Drawing.Size(129, 22);
            this.SpeedMenuItem.Text = "Speed";
            this.SpeedMenuItem.Click += new System.EventHandler(this.SpeedMenuItem_Click);
            // 
            // CadenceMenuItem
            // 
            this.CadenceMenuItem.Name = "CadenceMenuItem";
            this.CadenceMenuItem.Size = new System.Drawing.Size(129, 22);
            this.CadenceMenuItem.Text = "Cadence";
            this.CadenceMenuItem.Click += new System.EventHandler(this.CadenceMenuItem_Click);
            // 
            // AltitudeMenuItem
            // 
            this.AltitudeMenuItem.Name = "AltitudeMenuItem";
            this.AltitudeMenuItem.Size = new System.Drawing.Size(129, 22);
            this.AltitudeMenuItem.Text = "Altitude";
            this.AltitudeMenuItem.Click += new System.EventHandler(this.AltitudeMenuItem_Click);
            // 
            // PowerMenuItem
            // 
            this.PowerMenuItem.Name = "PowerMenuItem";
            this.PowerMenuItem.Size = new System.Drawing.Size(129, 22);
            this.PowerMenuItem.Text = "Power";
            this.PowerMenuItem.Click += new System.EventHandler(this.PowerMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(589, 238);
            this.listBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date of Race:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Time:";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-2, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2500, 2);
            this.label3.TabIndex = 1003;
            // 
            // DateOfFile
            // 
            this.DateOfFile.AutoSize = true;
            this.DateOfFile.Location = new System.Drawing.Point(112, 61);
            this.DateOfFile.Name = "DateOfFile";
            this.DateOfFile.Size = new System.Drawing.Size(0, 13);
            this.DateOfFile.TabIndex = 1004;
            // 
            // StartTime
            // 
            this.StartTime.AutoSize = true;
            this.StartTime.Location = new System.Drawing.Point(112, 84);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(0, 13);
            this.StartTime.TabIndex = 1005;
            // 
            // EndTime
            // 
            this.EndTime.AutoSize = true;
            this.EndTime.Location = new System.Drawing.Point(112, 106);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(0, 13);
            this.EndTime.TabIndex = 1007;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 1006;
            this.label5.Text = "End Time:";
            // 
            // MaxHR
            // 
            this.MaxHR.AutoSize = true;
            this.MaxHR.Location = new System.Drawing.Point(129, 237);
            this.MaxHR.Name = "MaxHR";
            this.MaxHR.Size = new System.Drawing.Size(0, 13);
            this.MaxHR.TabIndex = 1009;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 1008;
            this.label6.Text = "Maximum Heart Rate:";
            // 
            // MinHR
            // 
            this.MinHR.AutoSize = true;
            this.MinHR.Location = new System.Drawing.Point(129, 255);
            this.MinHR.Name = "MinHR";
            this.MinHR.Size = new System.Drawing.Size(0, 13);
            this.MinHR.TabIndex = 1011;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 1010;
            this.label7.Text = "Minimum Heart Rate:";
            // 
            // BPM
            // 
            this.BPM.AutoSize = true;
            this.BPM.Location = new System.Drawing.Point(129, 273);
            this.BPM.Name = "BPM";
            this.BPM.Size = new System.Drawing.Size(0, 13);
            this.BPM.TabIndex = 1013;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 1012;
            this.label8.Text = "Average Heart Rate:";
            // 
            // AvgSpeed
            // 
            this.AvgSpeed.AutoSize = true;
            this.AvgSpeed.Location = new System.Drawing.Point(129, 320);
            this.AvgSpeed.Name = "AvgSpeed";
            this.AvgSpeed.Size = new System.Drawing.Size(0, 13);
            this.AvgSpeed.TabIndex = 1015;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 1014;
            this.label9.Text = "Average Speed:";
            // 
            // Distance
            // 
            this.Distance.AutoSize = true;
            this.Distance.Location = new System.Drawing.Point(129, 337);
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(0, 13);
            this.Distance.TabIndex = 1017;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 1016;
            this.label11.Text = "Total Distance:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(626, 20);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(600, 238);
            this.listBox2.TabIndex = 1018;
            // 
            // MaxSpeed
            // 
            this.MaxSpeed.AutoSize = true;
            this.MaxSpeed.Location = new System.Drawing.Point(129, 303);
            this.MaxSpeed.Name = "MaxSpeed";
            this.MaxSpeed.Size = new System.Drawing.Size(0, 13);
            this.MaxSpeed.TabIndex = 1020;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 303);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 1019;
            this.label13.Text = "Maximum Speed:";
            // 
            // MaxPower
            // 
            this.MaxPower.AutoSize = true;
            this.MaxPower.Location = new System.Drawing.Point(129, 365);
            this.MaxPower.Name = "MaxPower";
            this.MaxPower.Size = new System.Drawing.Size(0, 13);
            this.MaxPower.TabIndex = 1026;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 1025;
            this.label10.Text = "Maximum Power:";
            // 
            // AvgPower
            // 
            this.AvgPower.AutoSize = true;
            this.AvgPower.Location = new System.Drawing.Point(129, 382);
            this.AvgPower.Name = "AvgPower";
            this.AvgPower.Size = new System.Drawing.Size(0, 13);
            this.AvgPower.TabIndex = 1022;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 382);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 1021;
            this.label16.Text = "Average Power:";
            // 
            // MaxAlt
            // 
            this.MaxAlt.AutoSize = true;
            this.MaxAlt.Location = new System.Drawing.Point(129, 407);
            this.MaxAlt.Name = "MaxAlt";
            this.MaxAlt.Size = new System.Drawing.Size(0, 13);
            this.MaxAlt.TabIndex = 1030;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 407);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 1029;
            this.label14.Text = "Maximum Altitude:";
            // 
            // AvgAlt
            // 
            this.AvgAlt.AutoSize = true;
            this.AvgAlt.Location = new System.Drawing.Point(129, 422);
            this.AvgAlt.Name = "AvgAlt";
            this.AvgAlt.Size = new System.Drawing.Size(0, 13);
            this.AvgAlt.TabIndex = 1028;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 422);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 1027;
            this.label18.Text = "Average Altitude:";
            // 
            // MPHRadio
            // 
            this.MPHRadio.AutoSize = true;
            this.MPHRadio.Checked = true;
            this.MPHRadio.Location = new System.Drawing.Point(9, 16);
            this.MPHRadio.Name = "MPHRadio";
            this.MPHRadio.Size = new System.Drawing.Size(73, 17);
            this.MPHRadio.TabIndex = 1031;
            this.MPHRadio.TabStop = true;
            this.MPHRadio.Text = "US (MPH)";
            this.MPHRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.KMRadio);
            this.groupBox1.Controls.Add(this.MPHRadio);
            this.groupBox1.Location = new System.Drawing.Point(248, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 58);
            this.groupBox1.TabIndex = 1032;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Format";
            // 
            // KMRadio
            // 
            this.KMRadio.AutoSize = true;
            this.KMRadio.Location = new System.Drawing.Point(9, 35);
            this.KMRadio.Name = "KMRadio";
            this.KMRadio.Size = new System.Drawing.Size(78, 17);
            this.KMRadio.TabIndex = 1032;
            this.KMRadio.Text = "EU (KM/H)";
            this.KMRadio.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1156, 363);
            this.dataGridView1.TabIndex = 1033;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 404);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1170, 395);
            this.tabControl1.TabIndex = 1035;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1162, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.listBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1162, 369);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 1037;
            this.label12.Text = "File Information:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(623, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1036;
            this.label4.Text = "Bike Data:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CompareGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1162, 369);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // CompareGridView
            // 
            this.CompareGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompareGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CompareGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompareGridView.Location = new System.Drawing.Point(3, 3);
            this.CompareGridView.Name = "CompareGridView";
            this.CompareGridView.Size = new System.Drawing.Size(1156, 346);
            this.CompareGridView.TabIndex = 1034;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.SummarySec1);
            this.tabPage4.Controls.Add(this.SummarySections);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1162, 369);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(102, 13);
            this.label23.TabIndex = 1063;
            this.label23.Text = "Amount of Sections:";
            // 
            // SummarySec1
            // 
            this.SummarySec1.Location = new System.Drawing.Point(110, 8);
            this.SummarySec1.Name = "SummarySec1";
            this.SummarySec1.Size = new System.Drawing.Size(46, 20);
            this.SummarySec1.TabIndex = 1063;
            this.SummarySec1.ValueChanged += new System.EventHandler(this.SummarySec1_ValueChanged);
            // 
            // SummarySections
            // 
            this.SummarySections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SummarySections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SummarySections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SummarySections.Location = new System.Drawing.Point(3, 33);
            this.SummarySections.Name = "SummarySections";
            this.SummarySections.Size = new System.Drawing.Size(1156, 316);
            this.SummarySections.TabIndex = 1035;
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(112, 128);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(0, 13);
            this.LengthLabel.TabIndex = 1038;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 130);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 1037;
            this.label19.Text = "Length:";
            // 
            // FTPCalc
            // 
            this.FTPCalc.Location = new System.Drawing.Point(210, 527);
            this.FTPCalc.Name = "FTPCalc";
            this.FTPCalc.Size = new System.Drawing.Size(37, 22);
            this.FTPCalc.TabIndex = 1040;
            this.FTPCalc.Text = "Calc";
            this.FTPCalc.UseVisualStyleBackColor = true;
            this.FTPCalc.Visible = false;
            this.FTPCalc.Click += new System.EventHandler(this.button1_Click);
            // 
            // FTPLabel
            // 
            this.FTPLabel.AutoSize = true;
            this.FTPLabel.Location = new System.Drawing.Point(99, 592);
            this.FTPLabel.Name = "FTPLabel";
            this.FTPLabel.Size = new System.Drawing.Size(0, 13);
            this.FTPLabel.TabIndex = 1041;
            this.FTPLabel.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 532);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 1043;
            this.label17.Text = "Enter FTP:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 554);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 13);
            this.label20.TabIndex = 1042;
            this.label20.Text = "Enter Heart Rate:";
            // 
            // BPMCalc
            // 
            this.BPMCalc.Location = new System.Drawing.Point(210, 551);
            this.BPMCalc.Name = "BPMCalc";
            this.BPMCalc.Size = new System.Drawing.Size(37, 20);
            this.BPMCalc.TabIndex = 1044;
            this.BPMCalc.Text = "Calc";
            this.BPMCalc.UseVisualStyleBackColor = true;
            this.BPMCalc.Visible = false;
            this.BPMCalc.Click += new System.EventHandler(this.BPMCalc_Click);
            // 
            // HRCalcLabel
            // 
            this.HRCalcLabel.AutoSize = true;
            this.HRCalcLabel.Location = new System.Drawing.Point(99, 574);
            this.HRCalcLabel.Name = "HRCalcLabel";
            this.HRCalcLabel.Size = new System.Drawing.Size(0, 13);
            this.HRCalcLabel.TabIndex = 1045;
            // 
            // FTPInput
            // 
            this.FTPInput.Location = new System.Drawing.Point(102, 529);
            this.FTPInput.Name = "FTPInput";
            this.FTPInput.Size = new System.Drawing.Size(101, 20);
            this.FTPInput.TabIndex = 1046;
            this.FTPInput.ValueChanged += new System.EventHandler(this.button1_Click);
            this.FTPInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FTPInput_KeyDown);
            // 
            // HRUserInput
            // 
            this.HRUserInput.Location = new System.Drawing.Point(102, 552);
            this.HRUserInput.Name = "HRUserInput";
            this.HRUserInput.Size = new System.Drawing.Size(101, 20);
            this.HRUserInput.TabIndex = 1047;
            this.HRUserInput.ValueChanged += new System.EventHandler(this.BPMCalc_Click);
            this.HRUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HRUserInput_KeyDown);
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Location = new System.Drawing.Point(112, 151);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(0, 13);
            this.IntervalLabel.TabIndex = 1049;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 153);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 13);
            this.label21.TabIndex = 1048;
            this.label21.Text = "Interval:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 196);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 20);
            this.label15.TabIndex = 1050;
            this.label15.Text = "Summary Data";
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Location = new System.Drawing.Point(11, 185);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(204, 2);
            this.label22.TabIndex = 1051;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(112, 37);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(0, 13);
            this.FileNameLabel.TabIndex = 1053;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 39);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(57, 13);
            this.label24.TabIndex = 1052;
            this.label24.Text = "File Name:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.zedGraphControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(358, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1176, 802);
            this.tableLayoutPanel1.TabIndex = 1054;
            // 
            // NormalPower
            // 
            this.NormalPower.AutoSize = true;
            this.NormalPower.Location = new System.Drawing.Point(129, 450);
            this.NormalPower.Name = "NormalPower";
            this.NormalPower.Size = new System.Drawing.Size(0, 13);
            this.NormalPower.TabIndex = 1056;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 450);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(95, 13);
            this.label25.TabIndex = 1055;
            this.label25.Text = "Normalized Power:";
            // 
            // DetectedIntervalBox
            // 
            this.DetectedIntervalBox.FormattingEnabled = true;
            this.DetectedIntervalBox.Location = new System.Drawing.Point(13, 609);
            this.DetectedIntervalBox.Name = "DetectedIntervalBox";
            this.DetectedIntervalBox.Size = new System.Drawing.Size(326, 186);
            this.DetectedIntervalBox.TabIndex = 1057;
            // 
            // IFLabel
            // 
            this.IFLabel.AutoSize = true;
            this.IFLabel.Location = new System.Drawing.Point(129, 468);
            this.IFLabel.Name = "IFLabel";
            this.IFLabel.Size = new System.Drawing.Size(0, 13);
            this.IFLabel.TabIndex = 1059;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 468);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(82, 13);
            this.label26.TabIndex = 1058;
            this.label26.Text = "Intensity Factor:";
            // 
            // TSSLabel
            // 
            this.TSSLabel.AutoSize = true;
            this.TSSLabel.Location = new System.Drawing.Point(129, 486);
            this.TSSLabel.Name = "TSSLabel";
            this.TSSLabel.Size = new System.Drawing.Size(0, 13);
            this.TSSLabel.TabIndex = 1061;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(10, 486);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(31, 13);
            this.label28.TabIndex = 1060;
            this.label28.Text = "TSS:";
            // 
            // ViewIntervalDetails
            // 
            this.ViewIntervalDetails.Location = new System.Drawing.Point(13, 798);
            this.ViewIntervalDetails.Name = "ViewIntervalDetails";
            this.ViewIntervalDetails.Size = new System.Drawing.Size(326, 22);
            this.ViewIntervalDetails.TabIndex = 1062;
            this.ViewIntervalDetails.Text = "View Interval Details";
            this.ViewIntervalDetails.UseVisualStyleBackColor = true;
            this.ViewIntervalDetails.Click += new System.EventHandler(this.ViewIntervalDetails_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 826);
            this.Controls.Add(this.ViewIntervalDetails);
            this.Controls.Add(this.TSSLabel);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.IFLabel);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.DetectedIntervalBox);
            this.Controls.Add(this.NormalPower);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.IntervalLabel);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.HRUserInput);
            this.Controls.Add(this.FTPInput);
            this.Controls.Add(this.HRCalcLabel);
            this.Controls.Add(this.BPMCalc);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.FTPLabel);
            this.Controls.Add(this.FTPCalc);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MaxAlt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.AvgAlt);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.MaxPower);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.AvgPower);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.MaxSpeed);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Distance);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AvgSpeed);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BPM);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.MinHR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MaxHR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StartTime);
            this.Controls.Add(this.DateOfFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cycle Data Program";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompareGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SummarySec1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SummarySections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTPInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRUserInput)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DateOfFile;
        private System.Windows.Forms.Label StartTime;
        private System.Windows.Forms.Label EndTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label MaxHR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label MinHR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label BPM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label AvgSpeed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Distance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label MaxSpeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label MaxPower;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label AvgPower;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label MaxAlt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label AvgAlt;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton MPHRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton KMRadio;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem HeartRateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SpeedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CadenceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AltitudeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PowerMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button FTPCalc;
        private System.Windows.Forms.Label FTPLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button BPMCalc;
        private System.Windows.Forms.Label HRCalcLabel;
        private System.Windows.Forms.NumericUpDown FTPInput;
        private System.Windows.Forms.NumericUpDown HRUserInput;
        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem compareFilesToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView CompareGridView;
        private System.Windows.Forms.Label NormalPower;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ListBox DetectedIntervalBox;
        private System.Windows.Forms.Label IFLabel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label TSSLabel;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button ViewIntervalDetails;
        private System.Windows.Forms.TabPage tabPage4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView SummarySections;
        private System.Windows.Forms.NumericUpDown SummarySec1;
        private System.Windows.Forms.Label label23;
    }
}

