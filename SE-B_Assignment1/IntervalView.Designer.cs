namespace SE_B_Assignment1
{
    partial class IntervalView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.TSSLabel = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.IFLabel = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.NormalPower = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.HRUserInput = new System.Windows.Forms.NumericUpDown();
            this.FTPInput = new System.Windows.Forms.NumericUpDown();
            this.HRCalcLabel = new System.Windows.Forms.Label();
            this.BPMCalc = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.FTPLabel = new System.Windows.Forms.Label();
            this.FTPCalc = new System.Windows.Forms.Button();
            this.MaxAlt = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.AvgAlt = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.MaxPower = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AvgPower = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.MaxSpeed = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Distance = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AvgSpeed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BPM = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MinHR = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MaxHR = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HRUserInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTPInput)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(293, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(947, 453);
            this.tableLayoutPanel1.TabIndex = 1055;
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
            this.zedGraphControl1.Size = new System.Drawing.Size(941, 448);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            this.zedGraphControl1.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.zedGraphControl1_ZoomEvent);
            this.zedGraphControl1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedGraphControl1_PointValueEvent);
            this.zedGraphControl1.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedGraphControl1_MouseDownEvent);
            // 
            // TSSLabel
            // 
            this.TSSLabel.AutoSize = true;
            this.TSSLabel.Location = new System.Drawing.Point(131, 329);
            this.TSSLabel.Name = "TSSLabel";
            this.TSSLabel.Size = new System.Drawing.Size(0, 13);
            this.TSSLabel.TabIndex = 1096;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(12, 329);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(31, 13);
            this.label28.TabIndex = 1095;
            this.label28.Text = "TSS:";
            // 
            // IFLabel
            // 
            this.IFLabel.AutoSize = true;
            this.IFLabel.Location = new System.Drawing.Point(131, 311);
            this.IFLabel.Name = "IFLabel";
            this.IFLabel.Size = new System.Drawing.Size(0, 13);
            this.IFLabel.TabIndex = 1094;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 311);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(82, 13);
            this.label26.TabIndex = 1093;
            this.label26.Text = "Intensity Factor:";
            // 
            // NormalPower
            // 
            this.NormalPower.AutoSize = true;
            this.NormalPower.Location = new System.Drawing.Point(131, 293);
            this.NormalPower.Name = "NormalPower";
            this.NormalPower.Size = new System.Drawing.Size(0, 13);
            this.NormalPower.TabIndex = 1092;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 293);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(95, 13);
            this.label25.TabIndex = 1091;
            this.label25.Text = "Normalized Power:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 20);
            this.label15.TabIndex = 1090;
            this.label15.Text = "Summary Data";
            // 
            // HRUserInput
            // 
            this.HRUserInput.Location = new System.Drawing.Point(104, 395);
            this.HRUserInput.Name = "HRUserInput";
            this.HRUserInput.Size = new System.Drawing.Size(101, 20);
            this.HRUserInput.TabIndex = 1089;
            this.HRUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HRUserInput_KeyDown);
            // 
            // FTPInput
            // 
            this.FTPInput.Location = new System.Drawing.Point(104, 372);
            this.FTPInput.Name = "FTPInput";
            this.FTPInput.Size = new System.Drawing.Size(101, 20);
            this.FTPInput.TabIndex = 1088;
            this.FTPInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FTPInput_KeyDown);
            // 
            // HRCalcLabel
            // 
            this.HRCalcLabel.AutoSize = true;
            this.HRCalcLabel.Location = new System.Drawing.Point(101, 417);
            this.HRCalcLabel.Name = "HRCalcLabel";
            this.HRCalcLabel.Size = new System.Drawing.Size(0, 13);
            this.HRCalcLabel.TabIndex = 1087;
            // 
            // BPMCalc
            // 
            this.BPMCalc.Location = new System.Drawing.Point(212, 394);
            this.BPMCalc.Name = "BPMCalc";
            this.BPMCalc.Size = new System.Drawing.Size(37, 20);
            this.BPMCalc.TabIndex = 1086;
            this.BPMCalc.Text = "Calc";
            this.BPMCalc.UseVisualStyleBackColor = true;
            this.BPMCalc.Visible = false;
            this.BPMCalc.Click += new System.EventHandler(this.BPMCalc_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 375);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 1085;
            this.label17.Text = "Enter FTP:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 397);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 13);
            this.label20.TabIndex = 1084;
            this.label20.Text = "Enter Heart Rate:";
            // 
            // FTPLabel
            // 
            this.FTPLabel.AutoSize = true;
            this.FTPLabel.Location = new System.Drawing.Point(101, 435);
            this.FTPLabel.Name = "FTPLabel";
            this.FTPLabel.Size = new System.Drawing.Size(0, 13);
            this.FTPLabel.TabIndex = 1083;
            this.FTPLabel.Visible = false;
            // 
            // FTPCalc
            // 
            this.FTPCalc.Location = new System.Drawing.Point(212, 370);
            this.FTPCalc.Name = "FTPCalc";
            this.FTPCalc.Size = new System.Drawing.Size(37, 22);
            this.FTPCalc.TabIndex = 1082;
            this.FTPCalc.Text = "Calc";
            this.FTPCalc.UseVisualStyleBackColor = true;
            this.FTPCalc.Visible = false;
            // 
            // MaxAlt
            // 
            this.MaxAlt.AutoSize = true;
            this.MaxAlt.Location = new System.Drawing.Point(131, 250);
            this.MaxAlt.Name = "MaxAlt";
            this.MaxAlt.Size = new System.Drawing.Size(0, 13);
            this.MaxAlt.TabIndex = 1081;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 1080;
            this.label14.Text = "Maximum Altitude:";
            // 
            // AvgAlt
            // 
            this.AvgAlt.AutoSize = true;
            this.AvgAlt.Location = new System.Drawing.Point(131, 265);
            this.AvgAlt.Name = "AvgAlt";
            this.AvgAlt.Size = new System.Drawing.Size(0, 13);
            this.AvgAlt.TabIndex = 1079;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 265);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 1078;
            this.label18.Text = "Average Altitude:";
            // 
            // MaxPower
            // 
            this.MaxPower.AutoSize = true;
            this.MaxPower.Location = new System.Drawing.Point(131, 208);
            this.MaxPower.Name = "MaxPower";
            this.MaxPower.Size = new System.Drawing.Size(0, 13);
            this.MaxPower.TabIndex = 1077;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 1076;
            this.label10.Text = "Maximum Power:";
            // 
            // AvgPower
            // 
            this.AvgPower.AutoSize = true;
            this.AvgPower.Location = new System.Drawing.Point(131, 225);
            this.AvgPower.Name = "AvgPower";
            this.AvgPower.Size = new System.Drawing.Size(0, 13);
            this.AvgPower.TabIndex = 1075;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 225);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 1074;
            this.label16.Text = "Average Power:";
            // 
            // MaxSpeed
            // 
            this.MaxSpeed.AutoSize = true;
            this.MaxSpeed.Location = new System.Drawing.Point(131, 146);
            this.MaxSpeed.Name = "MaxSpeed";
            this.MaxSpeed.Size = new System.Drawing.Size(0, 13);
            this.MaxSpeed.TabIndex = 1073;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 1072;
            this.label13.Text = "Maximum Speed:";
            // 
            // Distance
            // 
            this.Distance.AutoSize = true;
            this.Distance.Location = new System.Drawing.Point(131, 180);
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(0, 13);
            this.Distance.TabIndex = 1071;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 1070;
            this.label11.Text = "Total Distance:";
            // 
            // AvgSpeed
            // 
            this.AvgSpeed.AutoSize = true;
            this.AvgSpeed.Location = new System.Drawing.Point(131, 163);
            this.AvgSpeed.Name = "AvgSpeed";
            this.AvgSpeed.Size = new System.Drawing.Size(0, 13);
            this.AvgSpeed.TabIndex = 1069;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 1068;
            this.label9.Text = "Average Speed:";
            // 
            // BPM
            // 
            this.BPM.AutoSize = true;
            this.BPM.Location = new System.Drawing.Point(131, 116);
            this.BPM.Name = "BPM";
            this.BPM.Size = new System.Drawing.Size(0, 13);
            this.BPM.TabIndex = 1067;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 1066;
            this.label8.Text = "Average Heart Rate:";
            // 
            // MinHR
            // 
            this.MinHR.AutoSize = true;
            this.MinHR.Location = new System.Drawing.Point(131, 98);
            this.MinHR.Name = "MinHR";
            this.MinHR.Size = new System.Drawing.Size(0, 13);
            this.MinHR.TabIndex = 1065;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 1064;
            this.label7.Text = "Minimum Heart Rate:";
            // 
            // MaxHR
            // 
            this.MaxHR.AutoSize = true;
            this.MaxHR.Location = new System.Drawing.Point(131, 80);
            this.MaxHR.Name = "MaxHR";
            this.MaxHR.Size = new System.Drawing.Size(0, 13);
            this.MaxHR.TabIndex = 1063;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 1062;
            this.label6.Text = "Maximum Heart Rate:";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(261, -129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 800);
            this.label3.TabIndex = 1097;
            // 
            // IntervalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 536);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TSSLabel);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.IFLabel);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.NormalPower);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.HRUserInput);
            this.Controls.Add(this.FTPInput);
            this.Controls.Add(this.HRCalcLabel);
            this.Controls.Add(this.BPMCalc);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.FTPLabel);
            this.Controls.Add(this.FTPCalc);
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
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "IntervalView";
            this.Text = "IntervalView";
            this.Load += new System.EventHandler(this.IntervalView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HRUserInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTPInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label TSSLabel;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label IFLabel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label NormalPower;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown HRUserInput;
        private System.Windows.Forms.NumericUpDown FTPInput;
        private System.Windows.Forms.Label HRCalcLabel;
        private System.Windows.Forms.Button BPMCalc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label FTPLabel;
        private System.Windows.Forms.Button FTPCalc;
        private System.Windows.Forms.Label MaxAlt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label AvgAlt;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label MaxPower;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label AvgPower;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label MaxSpeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label Distance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label AvgSpeed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label BPM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label MinHR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label MaxHR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}