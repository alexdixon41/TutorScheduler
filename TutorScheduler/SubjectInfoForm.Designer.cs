namespace TutorScheduler
{
    partial class SubjectInfoForm
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
            this.abbreviationTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.tutorListView = new System.Windows.Forms.ListView();
            this.studentWorkerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // abbreviationTextBox
            // 
            this.abbreviationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abbreviationTextBox.Location = new System.Drawing.Point(20, 65);
            this.abbreviationTextBox.Margin = new System.Windows.Forms.Padding(11, 10, 3, 2);
            this.abbreviationTextBox.Name = "abbreviationTextBox";
            this.abbreviationTextBox.Size = new System.Drawing.Size(173, 34);
            this.abbreviationTextBox.TabIndex = 11;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberTextBox.Location = new System.Drawing.Point(207, 65);
            this.numberTextBox.Margin = new System.Windows.Forms.Padding(11, 10, 3, 2);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(173, 34);
            this.numberTextBox.TabIndex = 12;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(20, 19);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(11, 10, 3, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(543, 34);
            this.nameTextBox.TabIndex = 13;
            // 
            // doneButton
            // 
            this.doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doneButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.doneButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.doneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.doneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.doneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(647, 16);
            this.doneButton.Margin = new System.Windows.Forms.Padding(3, 10, 11, 2);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(133, 37);
            this.doneButton.TabIndex = 17;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // tutorListView
            // 
            this.tutorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.studentWorkerName});
            this.tutorListView.HideSelection = false;
            this.tutorListView.Location = new System.Drawing.Point(20, 118);
            this.tutorListView.Name = "tutorListView";
            this.tutorListView.Size = new System.Drawing.Size(760, 311);
            this.tutorListView.TabIndex = 18;
            this.tutorListView.UseCompatibleStateImageBehavior = false;
            this.tutorListView.View = System.Windows.Forms.View.Details;
            // 
            // studentWorkerName
            // 
            this.studentWorkerName.Text = "Name";
            this.studentWorkerName.Width = 320;
            // 
            // SubjectInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tutorListView);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.abbreviationTextBox);
            this.Name = "SubjectInfoForm";
            this.Text = "SubjectInfoForm";
            this.Load += new System.EventHandler(this.SubjectInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox abbreviationTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.ListView tutorListView;
        private System.Windows.Forms.ColumnHeader studentWorkerName;
    }
}