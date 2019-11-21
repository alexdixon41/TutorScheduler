namespace TutorScheduler
{
    partial class OpenScheduleForm
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
            this.scheduleListBox = new System.Windows.Forms.ListBox();
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scheduleListBox
            // 
            this.scheduleListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleListBox.FormattingEnabled = true;
            this.scheduleListBox.ItemHeight = 25;
            this.scheduleListBox.Items.AddRange(new object[] {
            "Fall 2019",
            "Spring 2020",
            "Fall 2020"});
            this.scheduleListBox.Location = new System.Drawing.Point(49, 49);
            this.scheduleListBox.Margin = new System.Windows.Forms.Padding(40);
            this.scheduleListBox.Name = "scheduleListBox";
            this.scheduleListBox.Size = new System.Drawing.Size(489, 254);
            this.scheduleListBox.TabIndex = 1;
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton.Location = new System.Drawing.Point(378, 346);
            this.openButton.Margin = new System.Windows.Forms.Padding(3, 3, 40, 5);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(160, 35);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "Open Schedule";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // OpenScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(587, 395);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.scheduleListBox);
            this.Name = "OpenScheduleForm";
            this.Text = "Open Schedule";
            this.Shown += new System.EventHandler(this.OpenScheduleForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox scheduleListBox;
        private System.Windows.Forms.Button openButton;
    }
}