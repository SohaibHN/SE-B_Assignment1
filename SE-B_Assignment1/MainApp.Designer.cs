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
            this.menuStrip1.SuspendLayout();
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
            this.zedGraphControl1.Size = new System.Drawing.Size(817, 352);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem});
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(852, 109);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(309, 355);
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
            this.MaxHR.Location = new System.Drawing.Point(85, 500);
            this.MaxHR.Name = "MaxHR";
            this.MaxHR.Size = new System.Drawing.Size(0, 13);
            this.MaxHR.TabIndex = 1009;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 500);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 1008;
            this.label6.Text = "Maximum HR:";
            // 
            // MinHR
            // 
            this.MinHR.AutoSize = true;
            this.MinHR.Location = new System.Drawing.Point(85, 525);
            this.MinHR.Name = "MinHR";
            this.MinHR.Size = new System.Drawing.Size(0, 13);
            this.MinHR.TabIndex = 1011;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 525);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 1010;
            this.label7.Text = "Minimum HR:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 652);
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
    }
}

