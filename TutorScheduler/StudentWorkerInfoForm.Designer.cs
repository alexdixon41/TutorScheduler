
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.classEditPanel = new System.Windows.Forms.Panel();
            this.addClassButton = new System.Windows.Forms.Button();
            this.classesListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.end = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.colorButton = new System.Windows.Forms.Button();
            this.addSubjectButton = new System.Windows.Forms.Button();
            this.subjectListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(13, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(174, 45);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Alex Dixon";
            // 
            // classEditPanel
            // 
            this.classEditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classEditPanel.Controls.Add(this.addClassButton);
            this.classEditPanel.Controls.Add(this.classesListView);
            this.classEditPanel.Location = new System.Drawing.Point(13, 413);
            this.classEditPanel.Name = "classEditPanel";
            this.classEditPanel.Size = new System.Drawing.Size(1225, 265);
            this.classEditPanel.TabIndex = 1;
            // 
            // addClassButton
            // 
            this.addClassButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addClassButton.Location = new System.Drawing.Point(4, 4);
            this.addClassButton.Name = "addClassButton";
            this.addClassButton.Size = new System.Drawing.Size(233, 51);
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
            this.classesListView.Name = "classesListView";
            this.classesListView.Size = new System.Drawing.Size(1219, 201);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(609, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Color:";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.positionLabel.Location = new System.Drawing.Point(15, 95);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(74, 31);
            this.positionLabel.TabIndex = 3;
            this.positionLabel.Text = "Guru";
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.Red;
            this.colorButton.ForeColor = System.Drawing.Color.Red;
            this.colorButton.Location = new System.Drawing.Point(693, 80);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(38, 35);
            this.colorButton.TabIndex = 6;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // addSubjectButton
            // 
            this.addSubjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addSubjectButton.Location = new System.Drawing.Point(12, 155);
            this.addSubjectButton.Name = "addSubjectButton";
            this.addSubjectButton.Size = new System.Drawing.Size(233, 51);
            this.addSubjectButton.TabIndex = 7;
            this.addSubjectButton.Text = "Add a Subject";
            this.addSubjectButton.UseVisualStyleBackColor = true;
            // 
            // subjectListView
            // 
            this.subjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.subjectListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectListView.FullRowSelect = true;
            this.subjectListView.HideSelection = false;
            this.subjectListView.Location = new System.Drawing.Point(12, 212);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.Size = new System.Drawing.Size(1219, 181);
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
            // StudentWorkerInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 690);
            this.Controls.Add(this.subjectListView);
            this.Controls.Add(this.addSubjectButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.classEditPanel);
            this.Controls.Add(this.nameLabel);
            this.Name = "StudentWorkerInfoForm";
            this.Text = "Edit Class Schedule";
            this.Load += new System.EventHandler(this.StudentWorkerInfoForm_Load);
            this.classEditPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel classEditPanel;
        private System.Windows.Forms.Button addClassButton;
        private System.Windows.Forms.ListView classesListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader start;
        private System.Windows.Forms.ColumnHeader end;
        private System.Windows.Forms.ColumnHeader days;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button addSubjectButton;
        private System.Windows.Forms.ListView subjectListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}