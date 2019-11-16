using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorScheduler
{
    public partial class ConfirmationPopup : Form
    {
        String primaryText, secondaryText;

        /// <summary>
        /// Sets primary and secondary text for the popup
        /// </summary>
        /// <param name="primaryText">The main text of the dialog form</param>
        /// <param name="secondaryText">The secondary or addition text of the dialog form</param>
        public ConfirmationPopup(String primaryText, String secondaryText)
        {
            // don't allow primary text longer than 50 characters, or it will be cut off
            if (primaryText.Length > 50)
            {
                primaryText = primaryText.Substring(0, 50);
            }
            InitializeComponent();
            this.primaryText = primaryText;
            this.secondaryText = secondaryText;
        }

        private void ConfirmationPopup_Load(object sender, EventArgs e)
        {
            primaryLabel.Text = primaryText;
            secondaryLabel.Text = secondaryText;
        }
    }
}
