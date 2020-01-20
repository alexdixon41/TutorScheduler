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
            bool shouldSave = true;
            StudentWorker[] sw = DatabaseManager.GetStudentWorkerByID(selectedEvent.StudentID);

            // if StudentWorker could not be found there is an error
            if (sw[0] == null)
            {
                Console.Error.WriteLine("StudentWorker not found for selected Work event.");               
                return;
            }
            
            StudentWorker selectedStudentWorker = sw[0];
            selectedStudentWorker.WorkSchedule = DatabaseManager.GetSchedule(selectedStudentWorker.StudentID, CalendarEvent.WORK);
            selectedStudentWorker.ClassSchedule = DatabaseManager.GetSchedule(selectedStudentWorker.StudentID, CalendarEvent.CLASS);
            selectedStudentWorker.BuildAvailabilitySchedule();
            selectedStudentWorker.UpdateTotalHours();
            Time startTime = new Time(startTimePicker.Value.TimeOfDay.Hours, startTimePicker.Value.TimeOfDay.Minutes);
            Time endTime = new Time(endTimePicker.Value.TimeOfDay.Hours, endTimePicker.Value.TimeOfDay.Minutes);
            CalendarEvent newEvent = new CalendarEvent(selectedEvent.EventName, startTime, endTime, selectedEvent.Day, selectedEvent.type, selectedEvent.PrimaryText, 
                selectedEvent.StudentID, selectedStudentWorker.DisplayColor);
            if (endTime < startTime)
            {
                new AlertDialog("Start time should be before end time.").ShowDialog();
                shouldSave = false;
            }
            else if (endTime.hours - startTime.hours > 5 && (selectedStudentWorker.JobPosition.Equals("Guru") || selectedStudentWorker.JobPosition.Equals("Lead Guru")))
            {
                new AlertDialog("A work shift should not be longer than 5 hours.").ShowDialog();
                shouldSave = false;
            }
            else
            {
                DialogResult result = DialogResult.OK;
                if ((selectedStudentWorker.JobPosition.Equals("Guru") || selectedStudentWorker.JobPosition.Equals("Lead Guru")) && selectedStudentWorker.TotalHours - (selectedEvent.EndTime - selectedEvent.StartTime).ToDouble() + (endTime - startTime).ToDouble() > 20)
                {
                    result = new ConfirmationPopup("Adding this work shift will put " + selectedStudentWorker.Name + " over 20 hours a week.", "Are you sure you want to do this?").ShowDialog();
                    if (!(result == DialogResult.OK))
                    {
                        shouldSave = false;
                    }
                }
                if (result == DialogResult.OK)
                {
                    // Make sure that the new work shift doesn't conflict with student worker's class schedule
                    // if the new work event is in the student's availability schedule                
                    if (!selectedStudentWorker.GetAvailabilitySchedule().Contains(newEvent))
                    {
                        //Display conflict error
                        //TODO: Display better error message
                        new AlertDialog("The shift conflicts with one of the student worker's classes or work shifts").ShowDialog();
                        shouldSave = false;
                    }
                }                      
            }
            if (shouldSave)
            {
                // save the updated event details 
                selectedEvent.UpdateEvent(startTimePicker.Value.Hour, startTimePicker.Value.Minute, endTimePicker.Value.Hour, endTimePicker.Value.Minute);
                this.Close();
            }            
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
