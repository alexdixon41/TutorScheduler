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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAllWorkers));
            this.selectedButton = new System.Windows.Forms.Button();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subjects = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeButton = new System.Windows.Forms.Button();
            this.newStudentWorkerButton = new System.Windows.Forms.Button();
            this.studentWorkerListView = new System.Windows.Forms.ListView();
            this.checkColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // selectedButton
            // 
            this.selectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedButton.Location = new System.Drawing.Point(1114, 806);
            this.selectedButton.Name = "selectedButton";
            this.selectedButton.Size = new System.Drawing.Size(136, 35);
            this.selectedButton.TabIndex = 7;
            this.selectedButton.Text = "Select";
            this.selectedButton.UseVisualStyleBackColor = true;
            this.selectedButton.Click += new System.EventHandler(this.SelectedButton_Click);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 180;
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
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(972, 806);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(136, 35);
            this.removeButton.TabIndex = 8;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // newStudentWorkerButton
            // 
            this.newStudentWorkerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newStudentWorkerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newStudentWorkerButton.Location = new System.Drawing.Point(12, 806);
            this.newStudentWorkerButton.Name = "newStudentWorkerButton";
            this.newStudentWorkerButton.Size = new System.Drawing.Size(136, 35);
            this.newStudentWorkerButton.TabIndex = 9;
            this.newStudentWorkerButton.Text = "Add New";
            this.newStudentWorkerButton.UseVisualStyleBackColor = true;
            this.newStudentWorkerButton.Click += new System.EventHandler(this.NewStudentWorkerButton_Click);
            // 
            // studentWorkerListView
            // 
            this.studentWorkerListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studentWorkerListView.AutoArrange = false;
            this.studentWorkerListView.CheckBoxes = true;
            this.studentWorkerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkColumn,
            this.name,
            this.position,
            this.subjects});
            this.studentWorkerListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.studentWorkerListView.FullRowSelect = true;
            this.studentWorkerListView.HideSelection = false;
            this.studentWorkerListView.Location = new System.Drawing.Point(13, 12);
            this.studentWorkerListView.Name = "studentWorkerListView";
            this.studentWorkerListView.OwnerDraw = true;
            this.studentWorkerListView.Size = new System.Drawing.Size(1237, 785);
            this.studentWorkerListView.TabIndex = 6;
            this.studentWorkerListView.UseCompatibleStateImageBehavior = false;
            this.studentWorkerListView.View = System.Windows.Forms.View.Details;
            this.studentWorkerListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.StudentWorkerListView_ColumnClick);
            this.studentWorkerListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.StudentWorkerListView_DrawColumnHeader);
            this.studentWorkerListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.StudentWorkerListView_DrawItem);
            this.studentWorkerListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.StudentWorkerListView_DrawSubItem);
            // 
            // checkColumn
            // 
            this.checkColumn.Text = "";
            this.checkColumn.Width = 30;
            // 
            // ViewAllWorkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1262, 853);
            this.Controls.Add(this.newStudentWorkerButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.selectedButton);
            this.Controls.Add(this.studentWorkerListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewAllWorkers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Student Workers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewAllWorkers_FormClosed);
            this.Load += new System.EventHandler(this.ViewAllWorkers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectedButton;
        private System.Windows.Forms.ListView studentWorkerListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader position;
        private System.Windows.Forms.ColumnHeader subjects;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button newStudentWorkerButton;
        private System.Windows.Forms.ColumnHeader checkColumn;
    }
}