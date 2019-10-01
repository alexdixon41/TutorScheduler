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
    public partial class AlertDialog : Form
    {
        String messageText;

        public AlertDialog()
        {
            this.messageText = messageText;
            InitializeComponent();
        }

        private void AlertDialog_Load(object sender, EventArgs e)
        {
            primaryText.Text = messageText;
        }
    }
}
