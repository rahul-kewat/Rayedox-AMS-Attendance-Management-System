namespace RP_Project
{
    partial class frmAttendanceReport
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dailyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyAttendanceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyAbsenteeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyPresentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.absenteeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.crystalReportViewer1);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Location = new System.Drawing.Point(-3, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1371, 624);
            this.panel2.TabIndex = 1;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 24);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1366, 582);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyReportToolStripMenuItem,
            this.monthlyReportToolStripMenuItem,
            this.yearlyReportToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1371, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dailyReportToolStripMenuItem
            // 
            this.dailyReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyAttendanceReportToolStripMenuItem,
            this.dailyAbsenteeReportToolStripMenuItem,
            this.dailyPresentReportToolStripMenuItem});
            this.dailyReportToolStripMenuItem.Name = "dailyReportToolStripMenuItem";
            this.dailyReportToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.dailyReportToolStripMenuItem.Text = "Daily Report";
            this.dailyReportToolStripMenuItem.Click += new System.EventHandler(this.dailyReportToolStripMenuItem_Click);
            // 
            // dailyAttendanceReportToolStripMenuItem
            // 
            this.dailyAttendanceReportToolStripMenuItem.Name = "dailyAttendanceReportToolStripMenuItem";
            this.dailyAttendanceReportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.dailyAttendanceReportToolStripMenuItem.Text = "Attendance Report";
            this.dailyAttendanceReportToolStripMenuItem.Click += new System.EventHandler(this.dailyAttendanceReportToolStripMenuItem_Click);
            // 
            // dailyAbsenteeReportToolStripMenuItem
            // 
            this.dailyAbsenteeReportToolStripMenuItem.Name = "dailyAbsenteeReportToolStripMenuItem";
            this.dailyAbsenteeReportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.dailyAbsenteeReportToolStripMenuItem.Text = "Absentee Report";
            this.dailyAbsenteeReportToolStripMenuItem.Click += new System.EventHandler(this.dailyAbsenteeReportToolStripMenuItem_Click);
            // 
            // dailyPresentReportToolStripMenuItem
            // 
            this.dailyPresentReportToolStripMenuItem.Name = "dailyPresentReportToolStripMenuItem";
            this.dailyPresentReportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.dailyPresentReportToolStripMenuItem.Text = "Present Report";
            this.dailyPresentReportToolStripMenuItem.Click += new System.EventHandler(this.dailyPresentReportToolStripMenuItem_Click);
            // 
            // monthlyReportToolStripMenuItem
            // 
            this.monthlyReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attendanceReportToolStripMenuItem,
            this.absenteeReportToolStripMenuItem,
            this.presentReportToolStripMenuItem});
            this.monthlyReportToolStripMenuItem.Name = "monthlyReportToolStripMenuItem";
            this.monthlyReportToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.monthlyReportToolStripMenuItem.Text = "Monthly Report";
            // 
            // attendanceReportToolStripMenuItem
            // 
            this.attendanceReportToolStripMenuItem.Name = "attendanceReportToolStripMenuItem";
            this.attendanceReportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.attendanceReportToolStripMenuItem.Text = "Attendance Report";
            this.attendanceReportToolStripMenuItem.Click += new System.EventHandler(this.attendanceReportToolStripMenuItem_Click);
            // 
            // absenteeReportToolStripMenuItem
            // 
            this.absenteeReportToolStripMenuItem.Name = "absenteeReportToolStripMenuItem";
            this.absenteeReportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.absenteeReportToolStripMenuItem.Text = "Absentee Report";
            this.absenteeReportToolStripMenuItem.Click += new System.EventHandler(this.absenteeReportToolStripMenuItem_Click);
            // 
            // presentReportToolStripMenuItem
            // 
            this.presentReportToolStripMenuItem.Name = "presentReportToolStripMenuItem";
            this.presentReportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.presentReportToolStripMenuItem.Text = "Present Report";
            this.presentReportToolStripMenuItem.Click += new System.EventHandler(this.presentReportToolStripMenuItem_Click);
            // 
            // yearlyReportToolStripMenuItem
            // 
            this.yearlyReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.form14ToolStripMenuItem});
            this.yearlyReportToolStripMenuItem.Name = "yearlyReportToolStripMenuItem";
            this.yearlyReportToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.yearlyReportToolStripMenuItem.Text = "Yearly Report";
            // 
            // form14ToolStripMenuItem
            // 
            this.form14ToolStripMenuItem.Name = "form14ToolStripMenuItem";
            this.form14ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.form14ToolStripMenuItem.Text = "Form 14";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsTXTToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // saveAsTXTToolStripMenuItem
            // 
            this.saveAsTXTToolStripMenuItem.Name = "saveAsTXTToolStripMenuItem";
            this.saveAsTXTToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveAsTXTToolStripMenuItem.Text = "Save as TXT";
            this.saveAsTXTToolStripMenuItem.Click += new System.EventHandler(this.saveAsTXTToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(-1, -17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 667);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(-4, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1374, 48);
            this.panel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(71)))), ((int)(((byte)(80)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1328, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(594, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Attendance Reports";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // frmAttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(1361, 640);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAttendanceReport";
            this.Text = "Attendance Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAttendanceReport_FormClosed);
            this.Load += new System.EventHandler(this.frmAttendanceReport_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dailyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyAttendanceReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyAbsenteeReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyPresentReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem absenteeReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presentReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearlyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form14ToolStripMenuItem;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsTXTToolStripMenuItem;
    }
}