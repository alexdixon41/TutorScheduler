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
            this.subjectListView = new System.Windows.Forms.ListView();
            this.SubjectAbbreviation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveButton = new System.Windows.Forms.Button();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // subjectListView
            // 
            this.subjectListView.CheckBoxes = true;
            this.subjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SubjectAbbreviation,
            this.SubjectName});
            this.subjectListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.subjectListView.FullRowSelect = true;
            this.subjectListView.HideSelection = false;
            this.subjectListView.Location = new System.Drawing.Point(13, 38);
            this.subjectListView.Margin = new System.Windows.Forms.Padding(4);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.Size = new System.Drawing.Size(671, 316);
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
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.saveButton.Location = new System.Drawing.Point(607, 361);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(77, 38);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.instructionLabel.Location = new System.Drawing.Point(12, 9);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(316, 25);
            this.instructionLabel.TabIndex = 3;
            this.instructionLabel.Text = "Select the subjects you wish to add";
            // 
            // AddSubjectToStudentWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 411);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.subjectListView);
            this.Name = "AddSubjectToStudentWorker";
            this.Text = "AddSubjectToStudentWorker";
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
    }
}