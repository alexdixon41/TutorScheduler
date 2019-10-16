namespace TutorScheduler
{
    partial class ViewAllWorkers
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
            this.selectedButton = new System.Windows.Forms.Button();
            this.studentWorkerListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subjects = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.newStudentWorkerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectedButton
            // 
            this.selectedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.selectedButton.Location = new System.Drawing.Point(652, 407);
            this.selectedButton.Name = "selectedButton";
            this.selectedButton.Size = new System.Drawing.Size(136, 35);
            this.selectedButton.TabIndex = 7;
            this.selectedButton.Text = "Select";
            this.selectedButton.UseVisualStyleBackColor = true;
            this.selectedButton.Click += new System.EventHandler(this.SelectedButton_Click);
            // 
            // studentWorkerListView
            // 
            this.studentWorkerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.position,
            this.subjects});
            this.studentWorkerListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.studentWorkerListView.FullRowSelect = true;
            this.studentWorkerListView.HideSelection = false;
            this.studentWorkerListView.Location = new System.Drawing.Point(13, 60);
            this.studentWorkerListView.Name = "studentWorkerListView";
            this.studentWorkerListView.Size = new System.Drawing.Size(775, 341);
            this.studentWorkerListView.TabIndex = 6;
            this.studentWorkerListView.UseCompatibleStateImageBehavior = false;
            this.studentWorkerListView.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 130;
            // 
            // position
            // 
            this.position.Text = "Position";
            this.position.Width = 117;
            // 
            // subjects
            // 
            this.subjects.Text = "Subjects";
            this.subjects.Width = 514;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchButton.Location = new System.Drawing.Point(652, 8);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(136, 35);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(633, 22);
            this.textBox1.TabIndex = 4;
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.removeButton.Location = new System.Drawing.Point(497, 407);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(136, 35);
            this.removeButton.TabIndex = 8;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // newStudentWorkerButton
            // 
            this.newStudentWorkerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.newStudentWorkerButton.Location = new System.Drawing.Point(13, 407);
            this.newStudentWorkerButton.Name = "newStudentWorkerButton";
            this.newStudentWorkerButton.Size = new System.Drawing.Size(136, 35);
            this.newStudentWorkerButton.TabIndex = 9;
            this.newStudentWorkerButton.Text = "Add New";
            this.newStudentWorkerButton.UseVisualStyleBackColor = true;
            this.newStudentWorkerButton.Click += new System.EventHandler(this.NewStudentWorkerButton_Click);
            // 
            // ViewAllWorkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.newStudentWorkerButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.selectedButton);
            this.Controls.Add(this.studentWorkerListView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.textBox1);
            this.Name = "ViewAllWorkers";
            this.Text = "ViewAllWorkers";
            this.Load += new System.EventHandler(this.ViewAllWorkers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectedButton;
        private System.Windows.Forms.ListView studentWorkerListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader position;
        private System.Windows.Forms.ColumnHeader subjects;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button newStudentWorkerButton;
    }
}