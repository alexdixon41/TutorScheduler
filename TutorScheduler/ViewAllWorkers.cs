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
    public partial class ViewAllWorkers : Form
    {
        public ViewAllWorkers()
        {
            InitializeComponent();
        }

        private void SelectedButton_Click(object sender, EventArgs e)
        {
            new StudentWorkerInfoForm().Show();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new ConfirmationPopup("Are you sure you want to remove Kinsey Wilson?", "This will remove them from the schedule.").ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                //Remove the student worker
            }

        }
    }
}
