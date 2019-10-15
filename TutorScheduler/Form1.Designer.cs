namespace TutorScheduler
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
            this.dayLabelPanel = new System.Windows.Forms.Panel();
            this.fridayLabel = new System.Windows.Forms.Label();
            this.thursdayLabel = new System.Windows.Forms.Label();
            this.tuesdayLabel = new System.Windows.Forms.Label();
            this.wednesdayLabel = new System.Windows.Forms.Label();
            this.mondayLabel = new System.Windows.Forms.Label();
            this.calendarPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectStudentWorkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentWorkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarDayView1 = new TutorScheduler.CalendarDayView();
            this.calendarWeekView1 = new TutorScheduler.CalendarWeekView();
            this.availabilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayLabelPanel.SuspendLayout();
            this.calendarPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dayLabelPanel
            // 
            this.dayLabelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayLabelPanel.AutoSize = true;
            this.dayLabelPanel.Controls.Add(this.fridayLabel);
            this.dayLabelPanel.Controls.Add(this.thursdayLabel);
            this.dayLabelPanel.Controls.Add(this.tuesdayLabel);
            this.dayLabelPanel.Controls.Add(this.wednesdayLabel);
            this.dayLabelPanel.Controls.Add(this.mondayLabel);
            this.dayLabelPanel.Location = new System.Drawing.Point(13, 36);
            this.dayLabelPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dayLabelPanel.Name = "dayLabelPanel";
            this.dayLabelPanel.Size = new System.Drawing.Size(838, 85);
            this.dayLabelPanel.TabIndex = 1;
            // 
            // fridayLabel
            // 
            this.fridayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fridayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.fridayLabel.Location = new System.Drawing.Point(688, 35);
            this.fridayLabel.Name = "fridayLabel";
            this.fridayLabel.Padding = new System.Windows.Forms.Padding(7);
            this.fridayLabel.Size = new System.Drawing.Size(106, 47);
            this.fridayLabel.TabIndex = 4;
            this.fridayLabel.Text = "Friday";
            // 
            // thursdayLabel
            // 
            this.thursdayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thursdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.thursdayLabel.Location = new System.Drawing.Point(532, 35);
            this.thursdayLabel.Name = "thursdayLabel";
            this.thursdayLabel.Padding = new System.Windows.Forms.Padding(7);
            this.thursdayLabel.Size = new System.Drawing.Size(144, 47);
            this.thursdayLabel.TabIndex = 3;
            this.thursdayLabel.Text = "Thursday";
            // 
            // tuesdayLabel
            // 
            this.tuesdayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tuesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tuesdayLabel.Location = new System.Drawing.Point(200, 35);
            this.tuesdayLabel.Name = "tuesdayLabel";
            this.tuesdayLabel.Padding = new System.Windows.Forms.Padding(7);
            this.tuesdayLabel.Size = new System.Drawing.Size(135, 47);
            this.tuesdayLabel.TabIndex = 2;
            this.tuesdayLabel.Text = "Tuesday";
            // 
            // wednesdayLabel
            // 
            this.wednesdayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wednesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.wednesdayLabel.Location = new System.Drawing.Point(347, 35);
            this.wednesdayLabel.Name = "wednesdayLabel";
            this.wednesdayLabel.Padding = new System.Windows.Forms.Padding(7);
            this.wednesdayLabel.Size = new System.Drawing.Size(173, 47);
            this.wednesdayLabel.TabIndex = 1;
            this.wednesdayLabel.Text = "Wednesday";
            // 
            // mondayLabel
            // 
            this.mondayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mondayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.mondayLabel.Location = new System.Drawing.Point(60, 35);
            this.mondayLabel.Name = "mondayLabel";
            this.mondayLabel.Padding = new System.Windows.Forms.Padding(7);
            this.mondayLabel.Size = new System.Drawing.Size(126, 47);
            this.mondayLabel.TabIndex = 0;
            this.mondayLabel.Text = "Monday";
            // 
            // calendarPanel
            // 
            this.calendarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarPanel.AutoScroll = true;
            this.calendarPanel.AutoScrollMinSize = new System.Drawing.Size(0, 1960);
            this.calendarPanel.Controls.Add(this.calendarDayView1);
            this.calendarPanel.Controls.Add(this.calendarWeekView1);
            this.calendarPanel.Location = new System.Drawing.Point(13, 119);
            this.calendarPanel.Name = "calendarPanel";
            this.calendarPanel.Size = new System.Drawing.Size(838, 319);
            this.calendarPanel.TabIndex = 2;
            this.calendarPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CalendarPanel_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.studentWorkersToolStripMenuItem,
            this.subjectsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MenuActivate += new System.EventHandler(this.MenuStrip1_MenuActivate);
            this.menuStrip1.MenuDeactivate += new System.EventHandler(this.MenuStrip1_MenuDeactivate);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(144, 30);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.ToolTipText = "Create a new schedule";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(144, 30);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.ToolTipText = "Save the current schedule";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(144, 30);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.ToolTipText = "Open a different schedule";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 30);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.ToolTipText = "Close the program";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calViewToolStripMenuItem,
            this.selectStudentWorkersToolStripMenuItem,
            this.availabilityToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(67, 29);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // calViewToolStripMenuItem
            // 
            this.calViewToolStripMenuItem.Name = "calViewToolStripMenuItem";
            this.calViewToolStripMenuItem.Size = new System.Drawing.Size(302, 30);
            this.calViewToolStripMenuItem.Text = "Switch to Day View";
            this.calViewToolStripMenuItem.Click += new System.EventHandler(this.DayViewToolStripMenuItem_Click);
            // 
            // selectStudentWorkersToolStripMenuItem
            // 
            this.selectStudentWorkersToolStripMenuItem.Name = "selectStudentWorkersToolStripMenuItem";
            this.selectStudentWorkersToolStripMenuItem.Size = new System.Drawing.Size(302, 30);
            this.selectStudentWorkersToolStripMenuItem.Text = "Display Student Workers";
            this.selectStudentWorkersToolStripMenuItem.Click += new System.EventHandler(this.SelectStudentWorkersToolStripMenuItem_Click);
            // 
            // studentWorkersToolStripMenuItem
            // 
            this.studentWorkersToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.studentWorkersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem});
            this.studentWorkersToolStripMenuItem.Name = "studentWorkersToolStripMenuItem";
            this.studentWorkersToolStripMenuItem.Size = new System.Drawing.Size(164, 29);
            this.studentWorkersToolStripMenuItem.Text = "Student Workers";
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(310, 30);
            this.viewAllToolStripMenuItem.Text = "Manage Student Workers";
            this.viewAllToolStripMenuItem.ToolTipText = "View all student workers";
            this.viewAllToolStripMenuItem.Click += new System.EventHandler(this.ViewAllToolStripMenuItem_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem1});
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
            this.subjectsToolStripMenuItem.Text = "Subjects";
            // 
            // viewAllToolStripMenuItem1
            // 
            this.viewAllToolStripMenuItem1.Name = "viewAllToolStripMenuItem1";
            this.viewAllToolStripMenuItem1.Size = new System.Drawing.Size(242, 30);
            this.viewAllToolStripMenuItem1.Text = "Manage Subjects";
            this.viewAllToolStripMenuItem1.ToolTipText = "View all saved subjects";
            this.viewAllToolStripMenuItem1.Click += new System.EventHandler(this.ViewAllToolStripMenuItem1_Click);
            // 
            // calendarDayView1
            // 
            this.calendarDayView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarDayView1.Location = new System.Drawing.Point(1, 3);
            this.calendarDayView1.Name = "calendarDayView1";
            this.calendarDayView1.Size = new System.Drawing.Size(811, 5239);
            this.calendarDayView1.TabIndex = 1;
            this.calendarDayView1.Text = "calendarDayView1";
            this.calendarDayView1.Visible = false;
            // 
            // calendarWeekView1
            // 
            this.calendarWeekView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarWeekView1.Location = new System.Drawing.Point(0, 3);
            this.calendarWeekView1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.calendarWeekView1.Name = "calendarWeekView1";
            this.calendarWeekView1.Size = new System.Drawing.Size(811, 39316);
            this.calendarWeekView1.TabIndex = 0;
            this.calendarWeekView1.Text = "calendarWeekView1";
            this.calendarWeekView1.Click += new System.EventHandler(this.CalendarWeekView1_Click);
            // 
            // availabilityToolStripMenuItem
            // 
            this.availabilityToolStripMenuItem.Name = "availabilityToolStripMenuItem";
            this.availabilityToolStripMenuItem.Size = new System.Drawing.Size(302, 30);
            this.availabilityToolStripMenuItem.Text = "Availability";
            this.availabilityToolStripMenuItem.Click += new System.EventHandler(this.AvailabilityToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(863, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.calendarPanel);
            this.Controls.Add(this.dayLabelPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.dayLabelPanel.ResumeLayout(false);
            this.calendarPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CalendarWeekView calendarWeekView1;
        private System.Windows.Forms.Panel dayLabelPanel;
        private System.Windows.Forms.Panel calendarPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentWorkersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem1;
        private System.Windows.Forms.Label fridayLabel;
        private System.Windows.Forms.Label thursdayLabel;
        private System.Windows.Forms.Label tuesdayLabel;
        private System.Windows.Forms.Label wednesdayLabel;
        private System.Windows.Forms.Label mondayLabel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calViewToolStripMenuItem;
        private CalendarDayView calendarDayView1;
        private System.Windows.Forms.ToolStripMenuItem selectStudentWorkersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem availabilityToolStripMenuItem;
    }
}

