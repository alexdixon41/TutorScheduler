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
    public partial class EditWorkEventForm : Form
    {
        private CalendarEvent selectedEvent;

        public EditWorkEventForm(CalendarEvent selectedEvent)
        {
            InitializeComponent();

            this.selectedEvent = selectedEvent;

            // display the name of the student worker the event belongs to
            nameLabel.Text = selectedEvent.PrimaryText;

            // display the day the event occurs on
            string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            dayLabel.Text = "Work Shift for " + days[selectedEvent.Day];

            DateTime startTime = new DateTime(1900, 1, 1, selectedEvent.StartTime.hours, selectedEvent.StartTime.minutes, 0);
            DateTime endTime = new DateTime(1900, 1, 1, selectedEvent.EndTime.hours, selectedEvent.EndTime.minutes, 0);
            startTimePicker.Value = startTime;
            endTimePicker.Value = endTime;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            // save the updated event details 
            selectedEvent.UpdateEvent(startTimePicker.Value.Hour, startTimePicker.Value.Minute, endTimePicker.Value.Hour, endTimePicker.Value.Minute);            
            this.Close();
        }

        private void EditWorkEventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshCalendars.Refresh();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            selectedEvent.RemoveEvent();
            this.Close();
        }
    }
}
