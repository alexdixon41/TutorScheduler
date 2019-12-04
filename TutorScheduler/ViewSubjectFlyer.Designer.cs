namespace TutorScheduler
{
    partial class ViewSubjectFlyer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSubjectFlyer));
            this.label1 = new System.Windows.Forms.Label();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.mondayLabel = new System.Windows.Forms.Label();
            this.tuesdayLabel = new System.Windows.Forms.Label();
            this.wednesdayLabel = new System.Windows.Forms.Label();
            this.thursdayLabel = new System.Windows.Forms.Label();
            this.fridayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(64, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Success Center";
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.subjectLabel.Location = new System.Drawing.Point(123, 28);
            this.subjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(145, 36);
            this.subjectLabel.TabIndex = 1;
            this.subjectLabel.Text = "MAT 234";
            // 
            // mondayLabel
            // 
            this.mondayLabel.AutoSize = true;
            this.mondayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.mondayLabel.Location = new System.Drawing.Point(65, 132);
            this.mondayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mondayLabel.Name = "mondayLabel";
            this.mondayLabel.Size = new System.Drawing.Size(262, 24);
            this.mondayLabel.TabIndex = 2;
            this.mondayLabel.Text = "Monday: 8:00 a.m.-12:30 p.m. ";
            // 
            // tuesdayLabel
            // 
            this.tuesdayLabel.AutoSize = true;
            this.tuesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tuesdayLabel.Location = new System.Drawing.Point(65, 177);
            this.tuesdayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tuesdayLabel.Name = "tuesdayLabel";
            this.tuesdayLabel.Size = new System.Drawing.Size(226, 24);
            this.tuesdayLabel.TabIndex = 3;
            this.tuesdayLabel.Text = "Tuesday: 12:00-8:00 p.m. ";
            // 
            // wednesdayLabel
            // 
            this.wednesdayLabel.AutoSize = true;
            this.wednesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.wednesdayLabel.Location = new System.Drawing.Point(65, 221);
            this.wednesdayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wednesdayLabel.Name = "wednesdayLabel";
            this.wednesdayLabel.Size = new System.Drawing.Size(285, 24);
            this.wednesdayLabel.TabIndex = 4;
            this.wednesdayLabel.Text = "Wednesday: 8:00 a.m.-3:00 p.m. ";
            // 
            // thursdayLabel
            // 
            this.thursdayLabel.AutoSize = true;
            this.thursdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.thursdayLabel.Location = new System.Drawing.Point(65, 264);
            this.thursdayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.thursdayLabel.Name = "thursdayLabel";
            this.thursdayLabel.Size = new System.Drawing.Size(273, 24);
            this.thursdayLabel.TabIndex = 5;
            this.thursdayLabel.Text = "Thursday: 11:00 a.m.-5:00 p.m. ";
            // 
            // fridayLabel
            // 
            this.fridayLabel.AutoSize = true;
            this.fridayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.fridayLabel.Location = new System.Drawing.Point(65, 309);
            this.fridayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fridayLabel.Name = "fridayLabel";
            this.fridayLabel.Size = new System.Drawing.Size(236, 24);
            this.fridayLabel.TabIndex = 6;
            this.fridayLabel.Text = "Friday: 9:00 a.m.-4:30 p.m. ";
            // 
            // ViewSubjectFlyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(662, 410);
            this.Controls.Add(this.fridayLabel);
            this.Controls.Add(this.thursdayLabel);
            this.Controls.Add(this.wednesdayLabel);
            this.Controls.Add(this.tuesdayLabel);
            this.Controls.Add(this.mondayLabel);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ViewSubjectFlyer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Subject Flyer";
            this.Load += new System.EventHandler(this.ViewSubjectFlyer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Label mondayLabel;
        private System.Windows.Forms.Label tuesdayLabel;
        private System.Windows.Forms.Label wednesdayLabel;
        private System.Windows.Forms.Label thursdayLabel;
        private System.Windows.Forms.Label fridayLabel;
    }
}