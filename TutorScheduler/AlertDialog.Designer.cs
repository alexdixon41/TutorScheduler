namespace TutorScheduler
{
    partial class AlertDialog
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
            this.confirmButton = new System.Windows.Forms.Button();
            this.primaryText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmButton.Location = new System.Drawing.Point(369, 102);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(95, 34);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // primaryText
            // 
            this.primaryText.AutoSize = true;
            this.primaryText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primaryText.Location = new System.Drawing.Point(12, 12);
            this.primaryText.Name = "primaryText";
            this.primaryText.Size = new System.Drawing.Size(92, 28);
            this.primaryText.TabIndex = 3;
            this.primaryText.Text = "Alert text";
            // 
            // AlertDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 149);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.primaryText);
            this.Name = "AlertDialog";
            this.Text = "AlertDialog";
            this.Load += new System.EventHandler(this.AlertDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label primaryText;
    }
}