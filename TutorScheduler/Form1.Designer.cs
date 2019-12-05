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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dayLabelPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fridayLabel = new System.Windows.Forms.Label();
            this.thursdayLabel = new System.Windows.Forms.Label();
            this.tuesdayLabel = new System.Windows.Forms.Label();
            this.wednesdayLabel = new System.Windows.Forms.Label();
            this.mondayLabel = new System.Windows.Forms.Label();
            this.calendarPanel = new TutorScheduler.CalendarPanel();
            this.calendarWeekView1 = new TutorScheduler.CalendarWeekView();
            this.calendarDayView1 = new TutorScheduler.CalendarDayView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.availabilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentWorkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dayLabelPanel.Controls.Add(this.panel1);
            this.dayLabelPanel.Controls.Add(this.fridayLabel);
            this.dayLabelPanel.Controls.Add(this.thursdayLabel);
            this.dayLabelPanel.Controls.Add(this.tuesdayLabel);
            this.dayLabelPanel.Controls.Add(this.wednesdayLabel);
            this.dayLabelPanel.Controls.Add(this.mondayLabel);
            this.dayLabelPanel.Location = new System.Drawing.Point(0, 29);
            this.dayLabelPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dayLabelPanel.Name = "dayLabelPanel";
            this.dayLabelPanel.Size = new System.Drawing.Size(647, 69);
            this.dayLabelPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 3);
            this.panel1.TabIndex = 5;
            // 
            // fridayLabel
            // 
            this.fridayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fridayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.fridayLabel.Location = new System.Drawing.Point(516, 28);
            this.fridayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fridayLabel.Name = "fridayLabel";
            this.fridayLabel.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.fridayLabel.Size = new System.Drawing.Size(80, 39);
            this.fridayLabel.TabIndex = 4;
            this.fridayLabel.Text = "Friday";
            // 
            // thursdayLabel
            // 
            this.thursdayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thursdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.thursdayLabel.Location = new System.Drawing.Point(399, 28);
            this.thursdayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.thursdayLabel.Name = "thursdayLabel";
            this.thursdayLabel.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.thursdayLabel.Size = new System.Drawing.Size(108, 39);
            this.thursdayLabel.TabIndex = 3;
            this.thursdayLabel.Text = "Thursday";
            // 
            // tuesdayLabel
            // 
            this.tuesdayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tuesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tuesdayLabel.Location = new System.Drawing.Point(150, 28);
            this.tuesdayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tuesdayLabel.Name = "tuesdayLabel";
            this.tuesdayLabel.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tuesdayLabel.Size = new System.Drawing.Size(102, 39);
            this.tuesdayLabel.TabIndex = 2;
            this.tuesdayLabel.Text = "Tuesday";
            // 
            // wednesdayLabel
            // 
            this.wednesdayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wednesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.wednesdayLabel.Location = new System.Drawing.Point(260, 28);
            this.wednesdayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wednesdayLabel.Name = "wednesdayLabel";
            this.wednesdayLabel.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.wednesdayLabel.Size = new System.Drawing.Size(130, 39);
            this.wednesdayLabel.TabIndex = 1;
            this.wednesdayLabel.Text = "Wednesday";
            // 
            // mondayLabel
            // 
            this.mondayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mondayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.mondayLabel.Location = new System.Drawing.Point(45, 28);
            this.mondayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mondayLabel.Name = "mondayLabel";
            this.mondayLabel.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.mondayLabel.Size = new System.Drawing.Size(95, 39);
            this.mondayLabel.TabIndex = 0;
            this.mondayLabel.Text = "Monday";
            // 
            // calendarPanel
            // 
            this.calendarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarPanel.AutoScroll = true;
            this.calendarPanel.AutoScrollMinSize = new System.Drawing.Size(0, 1930);
            this.calendarPanel.BackColor = System.Drawing.SystemColors.Window;
            this.calendarPanel.Controls.Add(this.calendarWeekView1);
            this.calendarPanel.Controls.Add(this.calendarDayView1);
            this.calendarPanel.Location = new System.Drawing.Point(0, 97);
            this.calendarPanel.Margin = new System.Windows.Forms.Padding(2);
            this.calendarPanel.Name = "calendarPanel";
            this.calendarPanel.Size = new System.Drawing.Size(647, 259);
            this.calendarPanel.TabIndex = 2;
            // 
            // calendarWeekView1
            // 
            this.calendarWeekView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarWeekView1.Location = new System.Drawing.Point(0, 0);
            this.calendarWeekView1.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.calendarWeekView1.Name = "calendarWeekView1";
            this.calendarWeekView1.Size = new System.Drawing.Size(627, 61267);
            this.calendarWeekView1.TabIndex = 0;
            this.calendarWeekView1.Text = "calendarWeekView1";
            // 
            // calendarDayView1
            // 
            this.calendarDayView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarDayView1.Location = new System.Drawing.Point(0, 0);
            this.calendarDayView1.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.calendarDayView1.Name = "calendarDayView1";
            this.calendarDayView1.Size = new System.Drawing.Size(627, 33579);
            this.calendarDayView1.TabIndex = 1;
            this.calendarDayView1.Text = "calendarDayView1";
            this.calendarDayView1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.studentWorkersToolStripMenuItem,
            this.subjectsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(647, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.newToolStripMenuItem.Text = "&New Schedule";
            this.newToolStripMenuItem.ToolTipText = "Create a new schedule";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.openToolStripMenuItem.Text = "&Open Schedule";
            this.openToolStripMenuItem.ToolTipText = "Open a different schedule";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.ToolTipText = "Close the program";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calViewToolStripMenuItem,
            this.availabilityToolStripMenuItem,
            this.classesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // calViewToolStripMenuItem
            // 
            this.calViewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("calViewToolStripMenuItem.Image")));
            this.calViewToolStripMenuItem.Name = "calViewToolStripMenuItem";
            this.calViewToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.calViewToolStripMenuItem.Text = "Switch to Day View";
            this.calViewToolStripMenuItem.Click += new System.EventHandler(this.DayViewToolStripMenuItem_Click);
            // 
            // availabilityToolStripMenuItem
            // 
            this.availabilityToolStripMenuItem.CheckOnClick = true;
            this.availabilityToolStripMenuItem.Name = "availabilityToolStripMenuItem";
            this.availabilityToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.availabilityToolStripMenuItem.Text = "Availability";
            this.availabilityToolStripMenuItem.Click += new System.EventHandler(this.AvailabilityToolStripMenuItem_Click);
            // 
            // classesToolStripMenuItem
            // 
            this.classesToolStripMenuItem.Checked = true;
            this.classesToolStripMenuItem.CheckOnClick = true;
            this.classesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.classesToolStripMenuItem.Name = "classesToolStripMenuItem";
            this.classesToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.classesToolStripMenuItem.Text = "Classes";
            this.classesToolStripMenuItem.Click += new System.EventHandler(this.ClassesToolStripMenuItem_Click);
            // 
            // studentWorkersToolStripMenuItem
            // 
            this.studentWorkersToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.studentWorkersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem});
            this.studentWorkersToolStripMenuItem.Name = "studentWorkersToolStripMenuItem";
            this.studentWorkersToolStripMenuItem.Size = new System.Drawing.Size(126, 21);
            this.studentWorkersToolStripMenuItem.Text = "Student Workers";
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Image = global::TutorScheduler.Properties.Resources.User_16x;
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.viewAllToolStripMenuItem.Text = "Manage Student Workers";
            this.viewAllToolStripMenuItem.ToolTipText = "View all student workers";
            this.viewAllToolStripMenuItem.Click += new System.EventHandler(this.ViewAllToolStripMenuItem_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem1});
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.subjectsToolStripMenuItem.Text = "Subjects";
            // 
            // viewAllToolStripMenuItem1
            // 
            this.viewAllToolStripMenuItem1.Image = global::TutorScheduler.Properties.Resources.Document_16x;
            this.viewAllToolStripMenuItem1.Name = "viewAllToolStripMenuItem1";
            this.viewAllToolStripMenuItem1.Size = new System.Drawing.Size(189, 26);
            this.viewAllToolStripMenuItem1.Text = "Manage Subjects";
            this.viewAllToolStripMenuItem1.ToolTipText = "View all saved subjects";
            this.viewAllToolStripMenuItem1.Click += new System.EventHandler(this.ViewAllToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(647, 366);
            this.Controls.Add(this.dayLabelPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.calendarPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Tutor Scheduler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form1_Shown);
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
        private CalendarPanel calendarPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem availabilityToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
    }
}

