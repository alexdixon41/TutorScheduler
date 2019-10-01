namespace TutorScheduler
{
    partial class DisplayStudentWorkers
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
            "Alex Dixon",
            "Guru"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "McKinsey Wilson",
            "Lead Guru"}, -1);
            this.displayStudentWorkersListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.positionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayStudentWorkersListView
            // 
            this.displayStudentWorkersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayStudentWorkersListView.CheckBoxes = true;
            this.displayStudentWorkersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.positionColumnHeader});
            this.displayStudentWorkersListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.displayStudentWorkersListView.FullRowSelect = true;
            this.displayStudentWorkersListView.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.displayStudentWorkersListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.displayStudentWorkersListView.Location = new System.Drawing.Point(13, 94);
            this.displayStudentWorkersListView.Name = "displayStudentWorkersListView";
            this.displayStudentWorkersListView.Size = new System.Drawing.Size(1057, 647);
            this.displayStudentWorkersListView.TabIndex = 0;
            this.displayStudentWorkersListView.UseCompatibleStateImageBehavior = false;
            this.displayStudentWorkersListView.View = System.Windows.Forms.View.Details;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 300;
            // 
            // positionColumnHeader
            // 
            this.positionColumnHeader.Text = "Position";
            this.positionColumnHeader.Width = 150;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBox1.Location = new System.Drawing.Point(6, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(232, 28);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.filterButton);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by Subject";
            // 
            // filterButton
            // 
            this.filterButton.AutoSize = true;
            this.filterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.filterButton.Location = new System.Drawing.Point(244, 22);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(62, 31);
            this.filterButton.TabIndex = 2;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.clearButton.Location = new System.Drawing.Point(312, 22);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(59, 31);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // DisplayStudentWorkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.displayStudentWorkersListView);
            this.Name = "DisplayStudentWorkers";
            this.Text = "DisplayStudentWorkers";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView displayStudentWorkersListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader positionColumnHeader;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button clearButton;
    }
}