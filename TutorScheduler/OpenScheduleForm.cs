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
    public partial class OpenScheduleForm : Form
    {
        List<string[]> FullSchedules;

        public OpenScheduleForm()
        {
            InitializeComponent();
        }

        private void OpenScheduleForm_Shown(object sender, EventArgs e)
        {
            FullSchedules = DatabaseManager.GetFullSchedules();

            // add the schedule names to the listbox
            scheduleListBox.BeginUpdate();
            scheduleListBox.Items.Clear();

            foreach (string[] scheduleInfo in FullSchedules)
            {
                scheduleListBox.Items.Add(scheduleInfo[1]);
            }
            scheduleListBox.EndUpdate();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (scheduleListBox.SelectedItems.Count == 0)
            {
                new AlertDialog("Select a schedule to open.").ShowDialog();
            }
            else
            {
                // open the selected schedule
                string idString = FullSchedules[scheduleListBox.SelectedIndex][0];
                Console.WriteLine(idString);
                DatabaseManager.OpenSchedule(idString);

                // refresh the calendar views and close
                RefreshCalendars.Refresh();
                this.Close();
            }
        }
    }
}
