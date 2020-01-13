namespace TutorScheduler
{
    partial class CreateWorkEventForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateWorkEventForm));
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.studentWorkerListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.createButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fridayCheckBox = new System.Windows.Forms.CheckBox();
            this.thursdayCheckBox = new System.Windows.Forms.CheckBox();
            this.wednesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.tuesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.mondayCheckBox = new System.Windows.Forms.CheckBox();
            this.subjects = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // endTimePicker
            // 
            this.endTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endTimePicker.CustomFormat = "hh:mm tt";
            this.endTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(693, 17);
            this.endTimePicker.Margin = new System.Windows.Forms.Padding(29, 2, 11, 2);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(245, 30);
            this.endTimePicker.TabIndex = 6;
            this.endTimePicker.Value = new System.DateTime(2019, 9, 15, 10, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(560, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "End Time";
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "hh:mm tt";
            this.startTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(159, 17);
            this.startTimePicker.Margin = new System.Windows.Forms.Padding(29, 2, 3, 2);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(245, 30);
            this.startTimePicker.TabIndex = 5;
            this.startTimePicker.Value = new System.DateTime(2019, 9, 15, 10, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 12, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Start Time";
            // 
            // studentWorkerListView
            // 
            this.studentWorkerListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studentWorkerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.position,
            this.totalHours,
            this.subjects});
            this.studentWorkerListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentWorkerListView.FullRowSelect = true;
            this.studentWorkerListView.HideSelection = false;
            this.studentWorkerListView.Location = new System.Drawing.Point(23, 171);
            this.studentWorkerListView.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.studentWorkerListView.Name = "studentWorkerListView";
            this.studentWorkerListView.Size = new System.Drawing.Size(916, 349);
            this.studentWorkerListView.TabIndex = 11;
            this.studentWorkerListView.UseCompatibleStateImageBehavior = false;
            this.studentWorkerListView.View = System.Windows.Forms.View.Details;
            this.studentWorkerListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.StudentWorkerListView_ColumnClick);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 130;
            // 
            // position
            // 
            this.position.Text = "Position";
            this.position.Width = 117;
            // 
            // totalHours
            // 
            this.totalHours.Text = "Total Work Hours";
            this.totalHours.Width = 138;
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.createButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.createButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.createButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(807, 533);
            this.createButton.Margin = new System.Windows.Forms.Padding(3, 2, 11, 12);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(133, 37);
            this.createButton.TabIndex = 12;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.fridayCheckBox);
            this.groupBox1.Controls.Add(this.thursdayCheckBox);
            this.groupBox1.Controls.Add(this.wednesdayCheckBox);
            this.groupBox1.Controls.Add(this.tuesdayCheckBox);
            this.groupBox1.Controls.Add(this.mondayCheckBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 74);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(11, 2, 11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(917, 78);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Days";
            // 
            // fridayCheckBox
            // 
            this.fridayCheckBox.AutoSize = true;
            this.fridayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fridayCheckBox.Location = new System.Drawing.Point(561, 33);
            this.fridayCheckBox.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.fridayCheckBox.Name = "fridayCheckBox";
            this.fridayCheckBox.Size = new System.Drawing.Size(88, 29);
            this.fridayCheckBox.TabIndex = 5;
            this.fridayCheckBox.Text = "Friday";
            this.fridayCheckBox.UseVisualStyleBackColor = true;
            // 
            // thursdayCheckBox
            // 
            this.thursdayCheckBox.AutoSize = true;
            this.thursdayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thursdayCheckBox.Location = new System.Drawing.Point(425, 33);
            this.thursdayCheckBox.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.thursdayCheckBox.Name = "thursdayCheckBox";
            this.thursdayCheckBox.Size = new System.Drawing.Size(117, 29);
            this.thursdayCheckBox.TabIndex = 4;
            this.thursdayCheckBox.Text = "Thursday";
            this.thursdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // wednesdayCheckBox
            // 
            this.wednesdayCheckBox.AutoSize = true;
            this.wednesdayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wednesdayCheckBox.Location = new System.Drawing.Point(267, 33);
            this.wednesdayCheckBox.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.wednesdayCheckBox.Name = "wednesdayCheckBox";
            this.wednesdayCheckBox.Size = new System.Drawing.Size(140, 29);
            this.wednesdayCheckBox.TabIndex = 3;
            this.wednesdayCheckBox.Text = "Wednesday";
            this.wednesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // tuesdayCheckBox
            // 
            this.tuesdayCheckBox.AutoSize = true;
            this.tuesdayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuesdayCheckBox.Location = new System.Drawing.Point(139, 33);
            this.tuesdayCheckBox.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.tuesdayCheckBox.Name = "tuesdayCheckBox";
            this.tuesdayCheckBox.Size = new System.Drawing.Size(111, 29);
            this.tuesdayCheckBox.TabIndex = 2;
            this.tuesdayCheckBox.Text = "Tuesday";
            this.tuesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // mondayCheckBox
            // 
            this.mondayCheckBox.AutoSize = true;
            this.mondayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mondayCheckBox.Location = new System.Drawing.Point(9, 33);
            this.mondayCheckBox.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.mondayCheckBox.Name = "mondayCheckBox";
            this.mondayCheckBox.Size = new System.Drawing.Size(105, 29);
            this.mondayCheckBox.TabIndex = 1;
            this.mondayCheckBox.Text = "Monday";
            this.mondayCheckBox.UseVisualStyleBackColor = true;
            // 
            // subjects
            // 
            this.subjects.Text = "Subjects";
            this.subjects.Width = 513;
            // 
            // CreateWorkEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(963, 593);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.studentWorkerListView);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(850, 598);
            this.Name = "CreateWorkEventForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Work Shift";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateWorkEventForm_FormClosed);
            this.Load += new System.EventHandler(this.AddNewWorkShift_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView studentWorkerListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader position;
        private System.Windows.Forms.ColumnHeader totalHours;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox fridayCheckBox;
        private System.Windows.Forms.CheckBox thursdayCheckBox;
        private System.Windows.Forms.CheckBox wednesdayCheckBox;
        private System.Windows.Forms.CheckBox tuesdayCheckBox;
        private System.Windows.Forms.CheckBox mondayCheckBox;
        private System.Windows.Forms.ColumnHeader subjects;
    }
}