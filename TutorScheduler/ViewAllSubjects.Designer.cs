﻿namespace TutorScheduler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAllSubjects));
            this.subjectListView = new System.Windows.Forms.ListView();
            this.checkColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubjectPrefix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddSubjectButton = new System.Windows.Forms.Button();
            this.RemoveSubject = new System.Windows.Forms.Button();
            this.viewFlyerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // subjectListView
            // 
            this.subjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectListView.CheckBoxes = true;
            this.subjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkColumn,
            this.SubjectPrefix,
            this.SubjectName});
            this.subjectListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.subjectListView.FullRowSelect = true;
            this.subjectListView.HideSelection = false;
            this.subjectListView.Location = new System.Drawing.Point(13, 13);
            this.subjectListView.Margin = new System.Windows.Forms.Padding(4);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.OwnerDraw = true;
            this.subjectListView.Size = new System.Drawing.Size(1236, 784);
            this.subjectListView.TabIndex = 0;
            this.subjectListView.UseCompatibleStateImageBehavior = false;
            this.subjectListView.View = System.Windows.Forms.View.Details;
            this.subjectListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SubjectListView_ColumnClick);
            this.subjectListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.SubjectListView_DrawColumnHeader);
            this.subjectListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.SubjectListView_DrawItem);
            this.subjectListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.SubjectListView_DrawSubItem);
            // 
            // checkColumn
            // 
            this.checkColumn.Text = "";
            this.checkColumn.Width = 30;
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
            this.AddSubjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddSubjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSubjectButton.Location = new System.Drawing.Point(911, 805);
            this.AddSubjectButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddSubjectButton.Name = "AddSubjectButton";
            this.AddSubjectButton.Size = new System.Drawing.Size(160, 35);
            this.AddSubjectButton.TabIndex = 1;
            this.AddSubjectButton.Text = "Add Subjects";
            this.AddSubjectButton.UseVisualStyleBackColor = true;
            this.AddSubjectButton.Click += new System.EventHandler(this.AddSubjectButton_Click);
            // 
            // RemoveSubject
            // 
            this.RemoveSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSubject.Location = new System.Drawing.Point(1079, 805);
            this.RemoveSubject.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveSubject.Name = "RemoveSubject";
            this.RemoveSubject.Size = new System.Drawing.Size(160, 35);
            this.RemoveSubject.TabIndex = 2;
            this.RemoveSubject.Text = "Remove Subjects";
            this.RemoveSubject.UseVisualStyleBackColor = true;
            this.RemoveSubject.Click += new System.EventHandler(this.RemoveSubject_Click);
            // 
            // viewFlyerButton
            // 
            this.viewFlyerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewFlyerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewFlyerButton.Location = new System.Drawing.Point(13, 805);
            this.viewFlyerButton.Margin = new System.Windows.Forms.Padding(4);
            this.viewFlyerButton.Name = "viewFlyerButton";
            this.viewFlyerButton.Size = new System.Drawing.Size(160, 35);
            this.viewFlyerButton.TabIndex = 5;
            this.viewFlyerButton.Text = "View Flyer";
            this.viewFlyerButton.UseVisualStyleBackColor = true;
            this.viewFlyerButton.Click += new System.EventHandler(this.ViewFlyerButton_Click);
            // 
            // ViewAllSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1262, 853);
            this.Controls.Add(this.viewFlyerButton);
            this.Controls.Add(this.RemoveSubject);
            this.Controls.Add(this.AddSubjectButton);
            this.Controls.Add(this.subjectListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewAllSubjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Subjects";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewAllSubjects_FormClosed);
            this.Load += new System.EventHandler(this.ViewAllSubjects_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView subjectListView;
        private System.Windows.Forms.Button AddSubjectButton;
        private System.Windows.Forms.Button RemoveSubject;
        private System.Windows.Forms.ColumnHeader SubjectPrefix;
        private System.Windows.Forms.ColumnHeader SubjectName;
        private System.Windows.Forms.Button viewFlyerButton;
        private System.Windows.Forms.ColumnHeader checkColumn;
    }
}