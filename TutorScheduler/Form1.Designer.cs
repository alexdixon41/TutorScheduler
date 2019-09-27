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
            this.fridayLabel = new System.Windows.Forms.TextBox();
            this.thursdayLabel = new System.Windows.Forms.TextBox();
            this.wednesdayLabel = new System.Windows.Forms.TextBox();
            this.tuesdayLabel = new System.Windows.Forms.TextBox();
            this.mondayLabel = new System.Windows.Forms.TextBox();
            this.calendarPanel = new System.Windows.Forms.Panel();
            this.calendarWeekView1 = new TutorScheduler.CalendarWeekView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentWorkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dayLabelPanel.Controls.Add(this.fridayLabel);
            this.dayLabelPanel.Controls.Add(this.thursdayLabel);
            this.dayLabelPanel.Controls.Add(this.wednesdayLabel);
            this.dayLabelPanel.Controls.Add(this.tuesdayLabel);
            this.dayLabelPanel.Controls.Add(this.mondayLabel);
            this.dayLabelPanel.Location = new System.Drawing.Point(13, 34);
            this.dayLabelPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dayLabelPanel.Name = "dayLabelPanel";
            this.dayLabelPanel.Size = new System.Drawing.Size(838, 85);
            this.dayLabelPanel.TabIndex = 1;
            // 
            // fridayLabel
            // 
            this.fridayLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fridayLabel.Enabled = false;
            this.fridayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.fridayLabel.Location = new System.Drawing.Point(660, 48);
            this.fridayLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.fridayLabel.Name = "fridayLabel";
            this.fridayLabel.ReadOnly = true;
            this.fridayLabel.Size = new System.Drawing.Size(134, 34);
            this.fridayLabel.TabIndex = 4;
            this.fridayLabel.Text = "Friday";
            // 
            // thursdayLabel
            // 
            this.thursdayLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.thursdayLabel.Enabled = false;
            this.thursdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.thursdayLabel.Location = new System.Drawing.Point(509, 48);
            this.thursdayLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.thursdayLabel.Name = "thursdayLabel";
            this.thursdayLabel.ReadOnly = true;
            this.thursdayLabel.Size = new System.Drawing.Size(134, 34);
            this.thursdayLabel.TabIndex = 3;
            this.thursdayLabel.Text = "Thursday";
            // 
            // wednesdayLabel
            // 
            this.wednesdayLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.wednesdayLabel.Enabled = false;
            this.wednesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.wednesdayLabel.Location = new System.Drawing.Point(360, 48);
            this.wednesdayLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.wednesdayLabel.Name = "wednesdayLabel";
            this.wednesdayLabel.ReadOnly = true;
            this.wednesdayLabel.Size = new System.Drawing.Size(134, 34);
            this.wednesdayLabel.TabIndex = 2;
            this.wednesdayLabel.Text = "Wednesday";
            // 
            // tuesdayLabel
            // 
            this.tuesdayLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tuesdayLabel.Enabled = false;
            this.tuesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tuesdayLabel.Location = new System.Drawing.Point(211, 48);
            this.tuesdayLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tuesdayLabel.Name = "tuesdayLabel";
            this.tuesdayLabel.ReadOnly = true;
            this.tuesdayLabel.Size = new System.Drawing.Size(134, 34);
            this.tuesdayLabel.TabIndex = 1;
            this.tuesdayLabel.Text = "Tuesday";
            // 
            // mondayLabel
            // 
            this.mondayLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mondayLabel.Enabled = false;
            this.mondayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.mondayLabel.Location = new System.Drawing.Point(61, 48);
            this.mondayLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.mondayLabel.Name = "mondayLabel";
            this.mondayLabel.ReadOnly = true;
            this.mondayLabel.Size = new System.Drawing.Size(134, 34);
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
            this.calendarPanel.Controls.Add(this.calendarWeekView1);
            this.calendarPanel.Location = new System.Drawing.Point(13, 119);
            this.calendarPanel.Name = "calendarPanel";
            this.calendarPanel.Size = new System.Drawing.Size(838, 319);
            this.calendarPanel.TabIndex = 2;
            this.calendarPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CalendarPanel_Scroll);
            // 
            // calendarWeekView1
            // 
            this.calendarWeekView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarWeekView1.Location = new System.Drawing.Point(1, 3);
            this.calendarWeekView1.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.calendarWeekView1.Name = "calendarWeekView1";
            this.calendarWeekView1.Size = new System.Drawing.Size(811, 23253);
            this.calendarWeekView1.TabIndex = 0;
            this.calendarWeekView1.Text = "calendarWeekView1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.studentWorkersToolStripMenuItem,
            this.subjectsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 31);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 27);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.ToolTipText = "Create a new schedule";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.ToolTipText = "Save the current schedule";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.ToolTipText = "Open a different schedule";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.ToolTipText = "Close the program";
            // 
            // studentWorkersToolStripMenuItem
            // 
            this.studentWorkersToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.studentWorkersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentWorkerToolStripMenuItem,
            this.viewAllToolStripMenuItem});
            this.studentWorkersToolStripMenuItem.Name = "studentWorkersToolStripMenuItem";
            this.studentWorkersToolStripMenuItem.Size = new System.Drawing.Size(147, 27);
            this.studentWorkersToolStripMenuItem.Text = "Student Workers";
            // 
            // addStudentWorkerToolStripMenuItem
            // 
            this.addStudentWorkerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addStudentWorkerToolStripMenuItem.Name = "addStudentWorkerToolStripMenuItem";
            this.addStudentWorkerToolStripMenuItem.Size = new System.Drawing.Size(240, 28);
            this.addStudentWorkerToolStripMenuItem.Text = "Add Student Worker";
            this.addStudentWorkerToolStripMenuItem.ToolTipText = "Add a new student worker";
            this.addStudentWorkerToolStripMenuItem.Click += new System.EventHandler(this.AddStudentWorkerToolStripMenuItem_Click);
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(240, 28);
            this.viewAllToolStripMenuItem.Text = "View All";
            this.viewAllToolStripMenuItem.ToolTipText = "View all student workers";
            this.viewAllToolStripMenuItem.Click += new System.EventHandler(this.ViewAllToolStripMenuItem_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSubjectToolStripMenuItem,
            this.viewAllToolStripMenuItem1});
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(85, 27);
            this.subjectsToolStripMenuItem.Text = "Subjects";
            // 
            // addSubjectToolStripMenuItem
            // 
            this.addSubjectToolStripMenuItem.Name = "addSubjectToolStripMenuItem";
            this.addSubjectToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.addSubjectToolStripMenuItem.Text = "Add Subject";
            this.addSubjectToolStripMenuItem.ToolTipText = "Add a new subject. A subject flyer can then be created for the new subject.";
            // 
            // viewAllToolStripMenuItem1
            // 
            this.viewAllToolStripMenuItem1.Name = "viewAllToolStripMenuItem1";
            this.viewAllToolStripMenuItem1.Size = new System.Drawing.Size(216, 28);
            this.viewAllToolStripMenuItem1.Text = "View All";
            this.viewAllToolStripMenuItem1.ToolTipText = "View all saved subjects";
            this.viewAllToolStripMenuItem1.Click += new System.EventHandler(this.ViewAllToolStripMenuItem1_Click);
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
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.dayLabelPanel.ResumeLayout(false);
            this.dayLabelPanel.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem addSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addStudentWorkerToolStripMenuItem;
        private System.Windows.Forms.TextBox mondayLabel;
        private System.Windows.Forms.TextBox fridayLabel;
        private System.Windows.Forms.TextBox thursdayLabel;
        private System.Windows.Forms.TextBox wednesdayLabel;
        private System.Windows.Forms.TextBox tuesdayLabel;
    }
}

