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
            this.subjectListView = new System.Windows.Forms.ListView();
            this.checkColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubjectPrefix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddSubjectButton = new System.Windows.Forms.Button();
            this.RemoveSubject = new System.Windows.Forms.Button();
            this.viewFlyerButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.saveSubjectSchedulesButton = new System.Windows.Forms.Button();
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
            this.subjectListView.Location = new System.Drawing.Point(23, 21);
            this.subjectListView.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.OwnerDraw = true;
            this.subjectListView.Size = new System.Drawing.Size(1215, 754);
            this.subjectListView.TabIndex = 0;
            this.subjectListView.UseCompatibleStateImageBehavior = false;
            this.subjectListView.View = System.Windows.Forms.View.Details;
            this.subjectListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SubjectListView_ColumnClick);
            this.subjectListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.SubjectListView_DrawColumnHeader);
            this.subjectListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.SubjectListView_DrawItem);
            this.subjectListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.SubjectListView_DrawSubItem);
            this.subjectListView.DoubleClick += new System.EventHandler(this.SubjectListView_DoubleClick);
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
            this.AddSubjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddSubjectButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddSubjectButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.AddSubjectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.AddSubjectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddSubjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSubjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSubjectButton.Location = new System.Drawing.Point(412, 795);
            this.AddSubjectButton.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.AddSubjectButton.Name = "AddSubjectButton";
            this.AddSubjectButton.Size = new System.Drawing.Size(187, 37);
            this.AddSubjectButton.TabIndex = 1;
            this.AddSubjectButton.Text = "Add Subjects";
            this.AddSubjectButton.UseVisualStyleBackColor = false;
            this.AddSubjectButton.Click += new System.EventHandler(this.AddSubjectButton_Click);
            // 
            // RemoveSubject
            // 
            this.RemoveSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveSubject.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RemoveSubject.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.RemoveSubject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.RemoveSubject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.RemoveSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSubject.Location = new System.Drawing.Point(620, 795);
            this.RemoveSubject.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.RemoveSubject.Name = "RemoveSubject";
            this.RemoveSubject.Size = new System.Drawing.Size(187, 37);
            this.RemoveSubject.TabIndex = 2;
            this.RemoveSubject.Text = "Remove Subjects";
            this.RemoveSubject.UseVisualStyleBackColor = false;
            this.RemoveSubject.Click += new System.EventHandler(this.RemoveSubject_Click);
            // 
            // viewFlyerButton
            // 
            this.viewFlyerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewFlyerButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.viewFlyerButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.viewFlyerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.viewFlyerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewFlyerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewFlyerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewFlyerButton.Location = new System.Drawing.Point(23, 795);
            this.viewFlyerButton.Margin = new System.Windows.Forms.Padding(8, 4, 11, 10);
            this.viewFlyerButton.Name = "viewFlyerButton";
            this.viewFlyerButton.Size = new System.Drawing.Size(160, 37);
            this.viewFlyerButton.TabIndex = 5;
            this.viewFlyerButton.Text = "View Flyer";
            this.viewFlyerButton.UseVisualStyleBackColor = false;
            this.viewFlyerButton.Click += new System.EventHandler(this.ViewFlyerButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doneButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.doneButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.doneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.doneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.doneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(1079, 795);
            this.doneButton.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(160, 37);
            this.doneButton.TabIndex = 6;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // saveSubjectSchedulesButton
            // 
            this.saveSubjectSchedulesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveSubjectSchedulesButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveSubjectSchedulesButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.saveSubjectSchedulesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.saveSubjectSchedulesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveSubjectSchedulesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveSubjectSchedulesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSubjectSchedulesButton.Location = new System.Drawing.Point(204, 795);
            this.saveSubjectSchedulesButton.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.saveSubjectSchedulesButton.Name = "saveSubjectSchedulesButton";
            this.saveSubjectSchedulesButton.Size = new System.Drawing.Size(187, 37);
            this.saveSubjectSchedulesButton.TabIndex = 7;
            this.saveSubjectSchedulesButton.Text = "Save All Flyers";
            this.saveSubjectSchedulesButton.UseVisualStyleBackColor = false;
            this.saveSubjectSchedulesButton.Click += new System.EventHandler(this.SaveSubjectSchedulesButton_Click);
            // 
            // ViewAllSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1261, 853);
            this.Controls.Add(this.saveSubjectSchedulesButton);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.viewFlyerButton);
            this.Controls.Add(this.RemoveSubject);
            this.Controls.Add(this.AddSubjectButton);
            this.Controls.Add(this.subjectListView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(861, 851);
            this.Name = "ViewAllSubjects";
            this.ShowIcon = false;
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
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button saveSubjectSchedulesButton;
    }
}