namespace TutorScheduler
{
    partial class EditClassSchedule
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Example Class",
            "12:30 pm",
            "1:45 pm",
            "T, TR"}, -1);
            this.label1 = new System.Windows.Forms.Label();
            this.classEditPanel = new System.Windows.Forms.Panel();
            this.classesListView = new System.Windows.Forms.ListView();
            this.addClassButton = new System.Windows.Forms.Button();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.end = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Worker Name";
            // 
            // classEditPanel
            // 
            this.classEditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classEditPanel.Controls.Add(this.addClassButton);
            this.classEditPanel.Controls.Add(this.classesListView);
            this.classEditPanel.Location = new System.Drawing.Point(13, 63);
            this.classEditPanel.Name = "classEditPanel";
            this.classEditPanel.Size = new System.Drawing.Size(1225, 517);
            this.classEditPanel.TabIndex = 1;
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
            this.classesListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.classesListView.Location = new System.Drawing.Point(3, 61);
            this.classesListView.Name = "classesListView";
            this.classesListView.Size = new System.Drawing.Size(1219, 453);
            this.classesListView.TabIndex = 0;
            this.classesListView.UseCompatibleStateImageBehavior = false;
            this.classesListView.View = System.Windows.Forms.View.Details;
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
            // EditClassSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 592);
            this.Controls.Add(this.classEditPanel);
            this.Controls.Add(this.label1);
            this.Name = "EditClassSchedule";
            this.Text = "Edit Class Schedule";
            this.classEditPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel classEditPanel;
        private System.Windows.Forms.Button addClassButton;
        private System.Windows.Forms.ListView classesListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader start;
        private System.Windows.Forms.ColumnHeader end;
        private System.Windows.Forms.ColumnHeader days;
    }
}