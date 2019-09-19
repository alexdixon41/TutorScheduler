namespace TutorScheduler
{
    partial class ViewAllSubjects
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "MAT 234",
            "Calculus 1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "MAT 235",
            "Calculus 2"}, -1);
            this.SubjectList = new System.Windows.Forms.ListView();
            this.AddSubjectButton = new System.Windows.Forms.Button();
            this.RemoveSubject = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SubjectSearchTextBox = new System.Windows.Forms.TextBox();
            this.SubjectPrefix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // SubjectList
            // 
            this.SubjectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SubjectPrefix,
            this.SubjectName});
            this.SubjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SubjectList.FullRowSelect = true;
            this.SubjectList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.SubjectList.Location = new System.Drawing.Point(12, 57);
            this.SubjectList.Name = "SubjectList";
            this.SubjectList.Size = new System.Drawing.Size(576, 248);
            this.SubjectList.TabIndex = 0;
            this.SubjectList.UseCompatibleStateImageBehavior = false;
            this.SubjectList.View = System.Windows.Forms.View.Details;
            this.SubjectList.SelectedIndexChanged += new System.EventHandler(this.SubjectList_SelectedIndexChanged);
            // 
            // AddSubjectButton
            // 
            this.AddSubjectButton.Location = new System.Drawing.Point(12, 311);
            this.AddSubjectButton.Name = "AddSubjectButton";
            this.AddSubjectButton.Size = new System.Drawing.Size(112, 43);
            this.AddSubjectButton.TabIndex = 1;
            this.AddSubjectButton.Text = "Add a Subject";
            this.AddSubjectButton.UseVisualStyleBackColor = true;
            this.AddSubjectButton.Click += new System.EventHandler(this.AddSubjectButton_Click);
            // 
            // RemoveSubject
            // 
            this.RemoveSubject.Location = new System.Drawing.Point(481, 311);
            this.RemoveSubject.Name = "RemoveSubject";
            this.RemoveSubject.Size = new System.Drawing.Size(107, 43);
            this.RemoveSubject.TabIndex = 2;
            this.RemoveSubject.Text = "Remove";
            this.RemoveSubject.UseVisualStyleBackColor = true;
            this.RemoveSubject.Click += new System.EventHandler(this.RemoveSubject_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(481, 12);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(102, 28);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SubjectSearchTextBox
            // 
            this.SubjectSearchTextBox.Location = new System.Drawing.Point(12, 17);
            this.SubjectSearchTextBox.Name = "SubjectSearchTextBox";
            this.SubjectSearchTextBox.Size = new System.Drawing.Size(463, 20);
            this.SubjectSearchTextBox.TabIndex = 4;
            // 
            // SubjectPrefix
            // 
            this.SubjectPrefix.Text = "Subject Prefix";
            this.SubjectPrefix.Width = 100;
            // 
            // SubjectName
            // 
            this.SubjectName.Text = "Subject Name";
            this.SubjectName.Width = 476;
            // 
            // ViewAllSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.SubjectSearchTextBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.RemoveSubject);
            this.Controls.Add(this.AddSubjectButton);
            this.Controls.Add(this.SubjectList);
            this.Name = "ViewAllSubjects";
            this.Text = "Subjects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView SubjectList;
        private System.Windows.Forms.Button AddSubjectButton;
        private System.Windows.Forms.Button RemoveSubject;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SubjectSearchTextBox;
        private System.Windows.Forms.ColumnHeader SubjectPrefix;
        private System.Windows.Forms.ColumnHeader SubjectName;
    }
}