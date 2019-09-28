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
            this.SubjectPrefix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddSubjectButton = new System.Windows.Forms.Button();
            this.RemoveSubject = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SubjectSearchTextBox = new System.Windows.Forms.TextBox();
            this.viewFlyerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SubjectList
            // 
            this.SubjectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SubjectPrefix,
            this.SubjectName});
            this.SubjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SubjectList.FullRowSelect = true;
            this.SubjectList.HideSelection = false;
            this.SubjectList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.SubjectList.Location = new System.Drawing.Point(16, 70);
            this.SubjectList.Margin = new System.Windows.Forms.Padding(4);
            this.SubjectList.Name = "SubjectList";
            this.SubjectList.Size = new System.Drawing.Size(767, 304);
            this.SubjectList.TabIndex = 0;
            this.SubjectList.UseCompatibleStateImageBehavior = false;
            this.SubjectList.View = System.Windows.Forms.View.Details;
            this.SubjectList.SelectedIndexChanged += new System.EventHandler(this.SubjectList_SelectedIndexChanged);
            // 
            // SubjectPrefix
            // 
            this.SubjectPrefix.Text = "Subject Prefix";
            this.SubjectPrefix.Width = 152;
            // 
            // SubjectName
            // 
            this.SubjectName.Text = "Subject Name";
            this.SubjectName.Width = 476;
            // 
            // AddSubjectButton
            // 
            this.AddSubjectButton.Location = new System.Drawing.Point(463, 383);
            this.AddSubjectButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddSubjectButton.Name = "AddSubjectButton";
            this.AddSubjectButton.Size = new System.Drawing.Size(149, 53);
            this.AddSubjectButton.TabIndex = 1;
            this.AddSubjectButton.Text = "Add a Subject";
            this.AddSubjectButton.UseVisualStyleBackColor = true;
            this.AddSubjectButton.Click += new System.EventHandler(this.AddSubjectButton_Click);
            // 
            // RemoveSubject
            // 
            this.RemoveSubject.Location = new System.Drawing.Point(641, 383);
            this.RemoveSubject.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveSubject.Name = "RemoveSubject";
            this.RemoveSubject.Size = new System.Drawing.Size(143, 53);
            this.RemoveSubject.TabIndex = 2;
            this.RemoveSubject.Text = "Remove";
            this.RemoveSubject.UseVisualStyleBackColor = true;
            this.RemoveSubject.Click += new System.EventHandler(this.RemoveSubject_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(641, 15);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(136, 34);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SubjectSearchTextBox
            // 
            this.SubjectSearchTextBox.Location = new System.Drawing.Point(16, 21);
            this.SubjectSearchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SubjectSearchTextBox.Name = "SubjectSearchTextBox";
            this.SubjectSearchTextBox.Size = new System.Drawing.Size(616, 22);
            this.SubjectSearchTextBox.TabIndex = 4;
            // 
            // viewFlyerButton
            // 
            this.viewFlyerButton.Location = new System.Drawing.Point(16, 384);
            this.viewFlyerButton.Margin = new System.Windows.Forms.Padding(4);
            this.viewFlyerButton.Name = "viewFlyerButton";
            this.viewFlyerButton.Size = new System.Drawing.Size(143, 53);
            this.viewFlyerButton.TabIndex = 5;
            this.viewFlyerButton.Text = "View Flyer";
            this.viewFlyerButton.UseVisualStyleBackColor = true;
            this.viewFlyerButton.Click += new System.EventHandler(this.ViewFlyerButton_Click);
            // 
            // ViewAllSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewFlyerButton);
            this.Controls.Add(this.SubjectSearchTextBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.RemoveSubject);
            this.Controls.Add(this.AddSubjectButton);
            this.Controls.Add(this.SubjectList);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button viewFlyerButton;
    }
}