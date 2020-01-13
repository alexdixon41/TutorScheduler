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
    public partial class AddClass : Form
    {
        StudentWorker studentWorker;

        public AddClass(StudentWorker selectedStudentWorker)
        {
            InitializeComponent();

            studentWorker = selectedStudentWorker;
            studentWorkerNameLabel.Text = selectedStudentWorker.Name;
        }

        private void SaveClassButton_Click(object sender, EventArgs e)
        {          
            CheckBox[] checkBoxes = { mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
            IndividualSchedule newClass = new IndividualSchedule();
            bool shouldSave = true;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    Time startTime = new Time(startTimePicker.Value.TimeOfDay.Hours, startTimePicker.Value.TimeOfDay.Minutes);
                    Time endTime = new Time(endTimePicker.Value.TimeOfDay.Hours, endTimePicker.Value.TimeOfDay.Minutes);

                    if (endTime < startTime)
                    {
                        new AlertDialog("Start time should be before end time.").ShowDialog();
                        shouldSave = false;
                    }
                    else
                    {
                        CalendarEvent newClassEvent = new CalendarEvent(classNameTextBox.Text, startTime, endTime, i, CalendarEvent.CLASS, studentWorker.Name, studentWorker.StudentID, studentWorker.DisplayColor);
                        newClassEvent.EventName = classNameTextBox.Text;

                        if (studentWorker.ClassSchedule.Overlaps(newClassEvent) || studentWorker.WorkSchedule.Overlaps(newClassEvent))
                        {
                            // [Future] - Display better error message
                            new AlertDialog("The class you are trying to create conflicts with an existing class or work shift.").ShowDialog();
                            shouldSave = false;
                        }
                        else                
                        {
                            //Add the class event to the schedule
                            newClass.AddEvent(newClassEvent);
                        }
                    }
                }
            }

            if (shouldSave)
            {                
                studentWorker.ClassSchedule.AddEvents(newClass.Events.ToArray());
                newClass.SaveSchedule(studentWorker.StudentID);
                this.Close();
            }
        }
    }
}
