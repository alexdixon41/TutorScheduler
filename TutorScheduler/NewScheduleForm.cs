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
    public partial class NewScheduleForm : Form
    {
        public NewScheduleForm()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            DatabaseManager.CreateSchedule(nameTextBox.Text);

            // refresh the calendar and close this form
            RefreshCalendars.Refresh();
            this.Close();
        }
    }
}
