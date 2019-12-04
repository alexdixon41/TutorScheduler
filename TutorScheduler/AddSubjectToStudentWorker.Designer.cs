namespace TutorScheduler
{
    partial class AddSubjectToStudentWorker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSubjectToStudentWorker));
            this.subjectListView = new System.Windows.Forms.ListView();
            this.SubjectAbbreviation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveButton = new System.Windows.Forms.Button();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.newSubjectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // subjectListView
            // 
            this.subjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectListView.CheckBoxes = true;
            this.subjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SubjectAbbreviation,
            this.SubjectName});
            this.subjectListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.subjectListView.FullRowSelect = true;
            this.subjectListView.HideSelection = false;
            this.subjectListView.Location = new System.Drawing.Point(17, 42);
            this.subjectListView.Margin = new System.Windows.Forms.Padding(8);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.Size = new System.Drawing.Size(558, 305);
            this.subjectListView.TabIndex = 1;
            this.subjectListView.UseCompatibleStateImageBehavior = false;
            this.subjectListView.View = System.Windows.Forms.View.Details;
            // 
            // SubjectAbbreviation
            // 
            this.SubjectAbbreviation.Text = "Subject";
            this.SubjectAbbreviation.Width = 188;
            // 
            // SubjectName
            // 
            this.SubjectName.Text = "Name";
            this.SubjectName.Width = 476;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(475, 357);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 8, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.instructionLabel.Location = new System.Drawing.Point(13, 14);
            this.instructionLabel.Margin = new System.Windows.Forms.Padding(8, 5, 2, 0);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(257, 20);
            this.instructionLabel.TabIndex = 3;
            this.instructionLabel.Text = "Select the subjects you wish to add";
            // 
            // newSubjectButton
            // 
            this.newSubjectButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.newSubjectButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.newSubjectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.newSubjectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.newSubjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newSubjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newSubjectButton.Location = new System.Drawing.Point(17, 357);
            this.newSubjectButton.Margin = new System.Windows.Forms.Padding(8, 2, 2, 10);
            this.newSubjectButton.Name = "newSubjectButton";
            this.newSubjectButton.Size = new System.Drawing.Size(100, 30);
            this.newSubjectButton.TabIndex = 4;
            this.newSubjectButton.Text = "New Subject";
            this.newSubjectButton.UseVisualStyleBackColor = false;
            this.newSubjectButton.Click += new System.EventHandler(this.NewSubjectButton_Click);
            // 
            // AddSubjectToStudentWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(592, 406);
            this.Controls.Add(this.newSubjectButton);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.subjectListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "AddSubjectToStudentWorker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Subjects to Student Worker";
            this.Load += new System.EventHandler(this.AddSubjectToStudentWorker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView subjectListView;
        private System.Windows.Forms.ColumnHeader SubjectAbbreviation;
        private System.Windows.Forms.ColumnHeader SubjectName;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Button newSubjectButton;
    }
}