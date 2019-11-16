
namespace TutorScheduler
{
    partial class StudentWorkerInfoForm
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
            this.classEditPanel = new System.Windows.Forms.Panel();
            this.addClassButton = new System.Windows.Forms.Button();
            this.classesListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.end = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.colorButton = new System.Windows.Forms.Button();
            this.addSubjectButton = new System.Windows.Forms.Button();
            this.subjectListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeSubjectButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.positionTextBox = new System.Windows.Forms.TextBox();
            this.generalSaveButton = new System.Windows.Forms.Button();
            this.classEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // classEditPanel
            // 
            this.classEditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classEditPanel.Controls.Add(this.addClassButton);
            this.classEditPanel.Controls.Add(this.classesListView);
            this.classEditPanel.Location = new System.Drawing.Point(13, 416);
            this.classEditPanel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.classEditPanel.Name = "classEditPanel";
            this.classEditPanel.Size = new System.Drawing.Size(1225, 262);
            this.classEditPanel.TabIndex = 1;
            // 
            // addClassButton
            // 
            this.addClassButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addClassButton.Location = new System.Drawing.Point(4, 4);
            this.addClassButton.Name = "addClassButton";
            this.addClassButton.Size = new System.Drawing.Size(200, 51);
            this.addClassButton.TabIndex = 1;
            this.addClassButton.Text = "Add Class";
            this.addClassButton.UseVisualStyleBackColor = true;
            this.addClassButton.Click += new System.EventHandler(this.AddClassButton_Click);
            // 
            // classesListView
            // 
            this.classesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.start,
            this.end,
            this.days});
            this.classesListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classesListView.FullRowSelect = true;
            this.classesListView.HideSelection = false;
            this.classesListView.Location = new System.Drawing.Point(3, 61);
            this.classesListView.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.classesListView.Name = "classesListView";
            this.classesListView.Size = new System.Drawing.Size(1222, 198);
            this.classesListView.TabIndex = 0;
            this.classesListView.UseCompatibleStateImageBehavior = false;
            this.classesListView.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Class Name";
            this.name.Width = 280;
            // 
            // start
            // 
            this.start.Text = "Start Time";
            this.start.Width = 150;
            // 
            // end
            // 
            this.end.Text = "End Time";
            this.end.Width = 150;
            // 
            // days
            // 
            this.days.Text = "Days";
            this.days.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(433, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(50, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Display Color";
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.Red;
            this.colorButton.ForeColor = System.Drawing.Color.Red;
            this.colorButton.Location = new System.Drawing.Point(623, 80);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(50, 50);
            this.colorButton.TabIndex = 6;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // addSubjectButton
            // 
            this.addSubjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addSubjectButton.Location = new System.Drawing.Point(12, 155);
            this.addSubjectButton.Name = "addSubjectButton";
            this.addSubjectButton.Size = new System.Drawing.Size(200, 51);
            this.addSubjectButton.TabIndex = 7;
            this.addSubjectButton.Text = "Add Subject";
            this.addSubjectButton.UseVisualStyleBackColor = true;
            this.addSubjectButton.Click += new System.EventHandler(this.AddSubjectButton_Click);
            // 
            // subjectListView
            // 
            this.subjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectListView.CheckBoxes = true;
            this.subjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.subjectListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectListView.FullRowSelect = true;
            this.subjectListView.HideSelection = false;
            this.subjectListView.Location = new System.Drawing.Point(12, 212);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.Size = new System.Drawing.Size(1226, 181);
            this.subjectListView.TabIndex = 8;
            this.subjectListView.UseCompatibleStateImageBehavior = false;
            this.subjectListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Subject";
            this.columnHeader1.Width = 280;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 256;
            // 
            // removeSubjectButton
            // 
            this.removeSubjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.removeSubjectButton.Location = new System.Drawing.Point(225, 155);
            this.removeSubjectButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.removeSubjectButton.Name = "removeSubjectButton";
            this.removeSubjectButton.Size = new System.Drawing.Size(200, 51);
            this.removeSubjectButton.TabIndex = 9;
            this.removeSubjectButton.Text = "Remove Subject";
            this.removeSubjectButton.UseVisualStyleBackColor = true;
            this.removeSubjectButton.Click += new System.EventHandler(this.RemoveSubjectButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Segoe UI", 19.8F);
            this.nameTextBox.Location = new System.Drawing.Point(17, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(363, 51);
            this.nameTextBox.TabIndex = 10;
            // 
            // positionTextBox
            // 
            this.positionTextBox.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.positionTextBox.Location = new System.Drawing.Point(17, 80);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(363, 43);
            this.positionTextBox.TabIndex = 11;
            // 
            // generalSaveButton
            // 
            this.generalSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generalSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.generalSaveButton.Location = new System.Drawing.Point(1068, 12);
            this.generalSaveButton.Name = "generalSaveButton";
            this.generalSaveButton.Size = new System.Drawing.Size(170, 50);
            this.generalSaveButton.TabIndex = 12;
            this.generalSaveButton.Text = "Save";
            this.generalSaveButton.UseVisualStyleBackColor = true;
            this.generalSaveButton.Click += new System.EventHandler(this.GeneralSaveButton_Click);
            // 
            // StudentWorkerInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1250, 690);
            this.Controls.Add(this.generalSaveButton);
            this.Controls.Add(this.positionTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.removeSubjectButton);
            this.Controls.Add(this.subjectListView);
            this.Controls.Add(this.addSubjectButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.classEditPanel);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "StudentWorkerInfoForm";
            this.Text = "Student Worker Information";
            this.Load += new System.EventHandler(this.StudentWorkerInfoForm_Load);
            this.classEditPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel classEditPanel;
        private System.Windows.Forms.Button addClassButton;
        private System.Windows.Forms.ListView classesListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader start;
        private System.Windows.Forms.ColumnHeader end;
        private System.Windows.Forms.ColumnHeader days;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button addSubjectButton;
        private System.Windows.Forms.ListView subjectListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button removeSubjectButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox positionTextBox;
        private System.Windows.Forms.Button generalSaveButton;
    }
}