namespace TutorScheduler
{
    partial class DayCalendarForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentWorkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.calendarPanel = new System.Windows.Forms.Panel();
            this.dayLabelPanel = new System.Windows.Forms.Panel();
            this.calendarDayView1 = new TutorScheduler.CalendarDayView();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.calendarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addSubjectToolStripMenuItem
            // 
            this.addSubjectToolStripMenuItem.Name = "addSubjectToolStripMenuItem";
            this.addSubjectToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.addSubjectToolStripMenuItem.Text = "Add Subject";
            this.addSubjectToolStripMenuItem.ToolTipText = "Add a new subject. A subject flyer can then be created for the new subject.";
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSubjectToolStripMenuItem,
            this.viewAllToolStripMenuItem1});
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(87, 27);
            this.subjectsToolStripMenuItem.Text = "Subjects";
            // 
            // viewAllToolStripMenuItem1
            // 
            this.viewAllToolStripMenuItem1.Name = "viewAllToolStripMenuItem1";
            this.viewAllToolStripMenuItem1.Size = new System.Drawing.Size(224, 28);
            this.viewAllToolStripMenuItem1.Text = "View All";
            this.viewAllToolStripMenuItem1.ToolTipText = "View all saved subjects";
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(248, 28);
            this.viewAllToolStripMenuItem.Text = "View All";
            this.viewAllToolStripMenuItem.ToolTipText = "View all student workers";
            // 
            // addStudentWorkerToolStripMenuItem
            // 
            this.addStudentWorkerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addStudentWorkerToolStripMenuItem.Name = "addStudentWorkerToolStripMenuItem";
            this.addStudentWorkerToolStripMenuItem.Size = new System.Drawing.Size(248, 28);
            this.addStudentWorkerToolStripMenuItem.Text = "Add Student Worker";
            this.addStudentWorkerToolStripMenuItem.ToolTipText = "Add a new student worker";
            // 
            // studentWorkersToolStripMenuItem
            // 
            this.studentWorkersToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.studentWorkersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentWorkerToolStripMenuItem,
            this.viewAllToolStripMenuItem});
            this.studentWorkersToolStripMenuItem.Name = "studentWorkersToolStripMenuItem";
            this.studentWorkersToolStripMenuItem.Size = new System.Drawing.Size(149, 27);
            this.studentWorkersToolStripMenuItem.Text = "Student Workers";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.ToolTipText = "Close the program";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.ToolTipText = "Open a different schedule";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.ToolTipText = "Save the current schedule";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.ToolTipText = "Create a new schedule";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(49, 27);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.studentWorkersToolStripMenuItem,
            this.subjectsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 31);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // calendarPanel
            // 
            this.calendarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarPanel.AutoScroll = true;
            this.calendarPanel.AutoScrollMinSize = new System.Drawing.Size(0, 1960);
            this.calendarPanel.Controls.Add(this.calendarDayView1);
            this.calendarPanel.Location = new System.Drawing.Point(13, 148);
            this.calendarPanel.Name = "calendarPanel";
            this.calendarPanel.Size = new System.Drawing.Size(838, 290);
            this.calendarPanel.TabIndex = 5;
            // 
            // dayLabelPanel
            // 
            this.dayLabelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayLabelPanel.AutoSize = true;
            this.dayLabelPanel.Location = new System.Drawing.Point(13, 63);
            this.dayLabelPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dayLabelPanel.Name = "dayLabelPanel";
            this.dayLabelPanel.Size = new System.Drawing.Size(838, 85);
            this.dayLabelPanel.TabIndex = 4;
            // 
            // calendarDayView1
            // 
            this.calendarDayView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarDayView1.Location = new System.Drawing.Point(4, 4);
            this.calendarDayView1.Name = "calendarDayView1";
            this.calendarDayView1.Size = new System.Drawing.Size(810, 3626);
            this.calendarDayView1.TabIndex = 0;
            this.calendarDayView1.Text = "calendarDayView1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(60, 27);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // DayCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(863, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.calendarPanel);
            this.Controls.Add(this.dayLabelPanel);
            this.Name = "DayCalendarForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.calendarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem addSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentWorkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentWorkersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel calendarPanel;
        private CalendarDayView calendarDayView1;
        private System.Windows.Forms.Panel dayLabelPanel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    }
}
