﻿namespace TutorScheduler
{
    partial class ConfirmationPopup
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.secondaryLabel = new System.Windows.Forms.Label();
            this.primaryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.AutoSize = true;
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(348, 141);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(96, 38);
            this.confirmButton.TabIndex = 7;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSize = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(450, 141);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 38);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // secondaryLabel
            // 
            this.secondaryLabel.AutoSize = true;
            this.secondaryLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondaryLabel.Location = new System.Drawing.Point(14, 55);
            this.secondaryLabel.Name = "secondaryLabel";
            this.secondaryLabel.Size = new System.Drawing.Size(138, 25);
            this.secondaryLabel.TabIndex = 5;
            this.secondaryLabel.Text = "Secondary Text";
            // 
            // primaryLabel
            // 
            this.primaryLabel.AutoSize = true;
            this.primaryLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primaryLabel.Location = new System.Drawing.Point(12, 9);
            this.primaryLabel.Name = "primaryLabel";
            this.primaryLabel.Size = new System.Drawing.Size(152, 32);
            this.primaryLabel.TabIndex = 4;
            this.primaryLabel.Text = "Primary Text";
            // 
            // ConfirmationPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 193);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.secondaryLabel);
            this.Controls.Add(this.primaryLabel);
            this.Name = "ConfirmationPopup";
            this.Text = "ConfirmationPopup";
            this.Load += new System.EventHandler(this.ConfirmationPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label secondaryLabel;
        private System.Windows.Forms.Label primaryLabel;
    }
}