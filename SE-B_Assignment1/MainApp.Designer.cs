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
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 112);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(834, 385);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 24);
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
            this.HeartRateMenuItem.Size = new System.Drawing.Size(152, 22);
            this.HeartRateMenuItem.Text = "Heart Rate";
            this.HeartRateMenuItem.Click += new System.EventHandler(this.HeartRateMenuItem_Click);
            // 
            // SpeedMenuItem
            // 
            this.SpeedMenuItem.Name = "SpeedMenuItem";
            this.SpeedMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SpeedMenuItem.Text = "Speed";
            this.SpeedMenuItem.Click += new System.EventHandler(this.SpeedMenuItem_Click);
            // 
            // CadenceMenuItem
            // 
            this.CadenceMenuItem.Name = "CadenceMenuItem";
            this.CadenceMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CadenceMenuItem.Text = "Cadence";
            this.CadenceMenuItem.Click += new System.EventHandler(this.CadenceMenuItem_Click);
            // 
            // AltitudeMenuItem
            // 
            this.AltitudeMenuItem.Name = "AltitudeMenuItem";
            this.AltitudeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AltitudeMenuItem.Text = "Altitude";
            this.AltitudeMenuItem.Click += new System.EventHandler(this.AltitudeMenuItem_Click);
            // 
            // PowerMenuItem
            // 
            this.PowerMenuItem.Name = "PowerMenuItem";
            this.PowerMenuItem.Size = new System.Drawing.Size(152, 22);
            this.PowerMenuItem.Text = "Power";
            this.PowerMenuItem.Click += new System.EventHandler(this.PowerMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(852, 109);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(309, 186);
            this.listBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date of Race:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
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
            this.label3.Size = new System.Drawing.Size(1500, 2);
            this.label3.TabIndex = 1003;
            // 
            // DateOfFile
            // 
            this.DateOfFile.AutoSize = true;
            this.DateOfFile.Location = new System.Drawing.Point(79, 43);
            this.DateOfFile.Name = "DateOfFile";
            this.DateOfFile.Size = new System.Drawing.Size(0, 13);
            this.DateOfFile.TabIndex = 1004;
            // 
            // StartTime
            // 
            this.StartTime.AutoSize = true;
            this.StartTime.Location = new System.Drawing.Point(79, 66);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(0, 13);
            this.StartTime.TabIndex = 1005;
            // 
            // EndTime
            // 
            this.EndTime.AutoSize = true;
            this.EndTime.Location = new System.Drawing.Point(79, 88);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(0, 13);
            this.EndTime.TabIndex = 1007;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 1006;
            this.label5.Text = "End Time:";
            // 
            // MaxHR
            // 
            this.MaxHR.AutoSize = true;
            this.MaxHR.Location = new System.Drawing.Point(81, 507);
            this.MaxHR.Name = "MaxHR";
            this.MaxHR.Size = new System.Drawing.Size(0, 13);
            this.MaxHR.TabIndex = 1009;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 507);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 1008;
            this.label6.Text = "Maximum HR:";
            // 
            // MinHR
            // 
            this.MinHR.AutoSize = true;
            this.MinHR.Location = new System.Drawing.Point(81, 532);
            this.MinHR.Name = "MinHR";
            this.MinHR.Size = new System.Drawing.Size(0, 13);
            this.MinHR.TabIndex = 1011;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 532);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 1010;
            this.label7.Text = "Minimum HR:";
            // 
            // BPM
            // 
            this.BPM.AutoSize = true;
            this.BPM.Location = new System.Drawing.Point(81, 555);
            this.BPM.Name = "BPM";
            this.BPM.Size = new System.Drawing.Size(0, 13);
            this.BPM.TabIndex = 1013;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 555);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 1012;
            this.label8.Text = "BPM:";
            // 
            // AvgSpeed
            // 
            this.AvgSpeed.AutoSize = true;
            this.AvgSpeed.Location = new System.Drawing.Point(225, 532);
            this.AvgSpeed.Name = "AvgSpeed";
            this.AvgSpeed.Size = new System.Drawing.Size(0, 13);
            this.AvgSpeed.TabIndex = 1015;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(134, 532);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 1014;
            this.label9.Text = "Average Speed:";
            // 
            // Distance
            // 
            this.Distance.AutoSize = true;
            this.Distance.Location = new System.Drawing.Point(225, 555);
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(0, 13);
            this.Distance.TabIndex = 1017;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(134, 555);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 1016;
            this.label11.Text = "Total Distance:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(852, 300);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(309, 199);
            this.listBox2.TabIndex = 1018;
            // 
            // MaxSpeed
            // 
            this.MaxSpeed.AutoSize = true;
            this.MaxSpeed.Location = new System.Drawing.Point(225, 507);
            this.MaxSpeed.Name = "MaxSpeed";
            this.MaxSpeed.Size = new System.Drawing.Size(0, 13);
            this.MaxSpeed.TabIndex = 1020;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(134, 507);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 1019;
            this.label13.Text = "Maximum Speed:";
            // 
            // MaxPower
            // 
            this.MaxPower.AutoSize = true;
            this.MaxPower.Location = new System.Drawing.Point(373, 507);
            this.MaxPower.Name = "MaxPower";
            this.MaxPower.Size = new System.Drawing.Size(0, 13);
            this.MaxPower.TabIndex = 1026;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 507);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 1025;
            this.label10.Text = "Maximum Power:";
            // 
            // AvgPower
            // 
            this.AvgPower.AutoSize = true;
            this.AvgPower.Location = new System.Drawing.Point(373, 532);
            this.AvgPower.Name = "AvgPower";
            this.AvgPower.Size = new System.Drawing.Size(0, 13);
            this.AvgPower.TabIndex = 1022;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(282, 532);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 1021;
            this.label16.Text = "Average Power:";
            // 
            // MaxAlt
            // 
            this.MaxAlt.AutoSize = true;
            this.MaxAlt.Location = new System.Drawing.Point(523, 507);
            this.MaxAlt.Name = "MaxAlt";
            this.MaxAlt.Size = new System.Drawing.Size(0, 13);
            this.MaxAlt.TabIndex = 1030;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(421, 507);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 1029;
            this.label14.Text = "Maximum Altitude:";
            // 
            // AvgAlt
            // 
            this.AvgAlt.AutoSize = true;
            this.AvgAlt.Location = new System.Drawing.Point(523, 532);
            this.AvgAlt.Name = "AvgAlt";
            this.AvgAlt.Size = new System.Drawing.Size(0, 13);
            this.AvgAlt.TabIndex = 1028;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(421, 532);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 1027;
            this.label18.Text = "Average Altitude:";
            // 
            // MPHRadio
            // 
            this.MPHRadio.AutoSize = true;
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
            this.groupBox1.Location = new System.Drawing.Point(755, 43);
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
            this.KMRadio.TabStop = true;
            this.KMRadio.Text = "EU (KM/H)";
            this.KMRadio.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(852, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(318, 390);
            this.dataGridView1.TabIndex = 1033;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 652);
            this.Controls.Add(this.dataGridView1);
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
            this.Controls.Add(this.listBox2);
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
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cycle Data Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
    }
}

