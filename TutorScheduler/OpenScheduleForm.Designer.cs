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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenScheduleForm));
            this.scheduleListBox = new System.Windows.Forms.ListBox();
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scheduleListBox
            // 
            this.scheduleListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleListBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.scheduleListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scheduleListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleListBox.FormattingEnabled = true;
            this.scheduleListBox.ItemHeight = 20;
            this.scheduleListBox.Items.AddRange(new object[] {
            "Fall 2019",
            "Spring 2020",
            "Fall 2020"});
            this.scheduleListBox.Location = new System.Drawing.Point(17, 17);
            this.scheduleListBox.Margin = new System.Windows.Forms.Padding(8);
            this.scheduleListBox.Name = "scheduleListBox";
            this.scheduleListBox.Size = new System.Drawing.Size(414, 202);
            this.scheduleListBox.TabIndex = 1;
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.openButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.openButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(98)))), ((int)(((byte)(107)))));
            this.openButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton.Location = new System.Drawing.Point(311, 259);
            this.openButton.Margin = new System.Windows.Forms.Padding(2, 8, 8, 10);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(120, 30);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "Open Schedule";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // OpenScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(448, 306);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.scheduleListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(454, 332);
            this.Name = "OpenScheduleForm";
            this.ShowIcon = false;
            this.Text = "Open Schedule";
            this.Shown += new System.EventHandler(this.OpenScheduleForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox scheduleListBox;
        private System.Windows.Forms.Button openButton;
    }
}