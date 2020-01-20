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
    public partial class EditClass : Form
    {
        CheckBox[] checkBoxes;
        IndividualSchedule newClassSchedule = new IndividualSchedule();
        StudentWorker studentWorker;

        // whether a new class is being created or an existing class is being edited
        bool isNewClass;

        // whether the class was saved using the save button or the changes were cancelled by exiting the form
        bool isSaved = false;

        // original class info when the form loads, before any user editing; used to restore the class in case the edits are cancelled
        List<CalendarEvent> oldClass = null;                    
        int EventDetailsID = -1;    
        

        public EditClass(StudentWorker selectedStudentWorker)
        {
            InitializeComponent();

            checkBoxes = new CheckBox[] { mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
            studentWorker = selectedStudentWorker;
            studentWorkerNameLabel.Text = selectedStudentWorker.Name;
            isNewClass = true;
        }

        public EditClass(StudentWorker selectedStudentWorker, int eventDetailsID)
        {
            InitializeComponent();
            deleteButton.Visible = true;

            checkBoxes = new CheckBox[] { mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
            studentWorker = selectedStudentWorker;
            studentWorkerNameLabel.Text = selectedStudentWorker.Name;
            isNewClass = false;
            EventDetailsID = eventDetailsID;

            // add class meeting times for the class to edit
            oldClass = DatabaseManager.GetClass(EventDetailsID);
            DatabaseManager.RemoveClass(EventDetailsID);                // remove the class from database while editing so new times will not conflict with times of the same class    
            if (oldClass.Count > 0)
            {
                classNameTextBox.Text = oldClass[0].EventName;
            }
            foreach (CalendarEvent classEvent in oldClass)
            {
                newClassSchedule.AddEvent(classEvent);
                ClassMeetingTimePanel newTimePanel = new ClassMeetingTimePanel();                
                classTimePanel.Controls.Add(newTimePanel);
            }
            LayoutTimePanels();
        }

        /// <summary>
        /// Save the schedule for the new class when save button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveClassButton_Click(object sender, EventArgs e)
        {
            if (newClassSchedule.Events.Count > 0)
            {               
                // save the class                
                newClassSchedule.SaveSchedule(studentWorker.StudentID);
                studentWorker.GetClassSchedule();
                isSaved = true;
                this.Close();
            }                        
        }

        /// <summary>
        /// Add a new MeetingTimePanel to the group box to display a new meeting time for the class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTimeButton_Click(object sender, EventArgs e)
        {            
            int[] checkedDays = new int[5];
            int checkedCount = 0;
            Time startTime = new Time(startTimePicker.Value.TimeOfDay.Hours, startTimePicker.Value.TimeOfDay.Minutes);
            Time endTime = new Time(endTimePicker.Value.TimeOfDay.Hours, endTimePicker.Value.TimeOfDay.Minutes);            

            // validate start and end times
            if (endTime < startTime)
            {                
                new AlertDialog("Start time should be before end time.").ShowDialog();
            }
            else
            {
                // add event for selected day to the schedule
                for (int i = 0; i < checkBoxes.Length; i++)
                {
                    if (checkBoxes[i].Checked)
                    {                                      
                        CalendarEvent newClassEvent = new CalendarEvent(classNameTextBox.Text, startTime, endTime, i, CalendarEvent.CLASS, studentWorker.Name, studentWorker.StudentID, studentWorker.DisplayColor);
                        newClassEvent.EventName = classNameTextBox.Text;                        

                        if (studentWorker.ClassSchedule.Overlaps(newClassEvent) || studentWorker.WorkSchedule.Overlaps(newClassEvent) || newClassSchedule.Overlaps(newClassEvent))
                        {      
                            // [Future] - Display better error message
                            new AlertDialog("The class you are trying to create conflicts with an existing class or work shift.").ShowDialog();
                            break;
                        }
                        else
                        {
                            // add the class event to the schedule
                            newClassSchedule.AddEvent(newClassEvent);

                            // add the day to the array of days
                            checkedDays[i] = 1;
                            checkedCount++;
                        }
                    }
                }
            }
            LayoutTimePanels();
        }

        /// <summary>
        /// Refresh the layout of ClassMeetingTimePanels in the classTimePanel
        /// </summary>
        private void LayoutTimePanels()
        {
            classTimePanel.SuspendLayout();
            studentWorker.GetClassSchedule();
            classTimePanel.Controls.Clear();
            foreach (CalendarEvent classEvent in newClassSchedule.Events)
            {
                ClassMeetingTimePanel newTimePanel = new ClassMeetingTimePanel();
                newTimePanel.SetMeetingTime(classEvent.StartTime, classEvent.EndTime, new int[] { classEvent.Day });
                classTimePanel.Controls.Add(newTimePanel);
            }
            classTimePanel.AutoScrollPosition = new Point(0, 0);                      
            int top = 3;
            foreach (ClassMeetingTimePanel newTimePanel in classTimePanel.Controls)
            {
                newTimePanel.BorderStyle = BorderStyle.FixedSingle;
                newTimePanel.Location = new Point(3, top);                
                newTimePanel.Size = new Size(classTimePanel.ClientRectangle.Width - newTimePanel.Margin.Left - newTimePanel.Margin.Right, 37);                                                           
                newTimePanel.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

                // update the top position for the next time to be added
                top += newTimePanel.Height + 6;
            }
            classTimePanel.ResumeLayout();
        }

        /// <summary>
        /// Remove the specified ClassMeetingTimePanel from the classTimePanel
        /// </summary>
        /// <param name="timePanel">The ClassMeetingTimePanel to be removed</param>
        public void RemoveTimePanel(ClassMeetingTimePanel timePanel)
        {
            // TODO - remove the CalendarEvent from the database so if you try to change the time where it overlaps with the old time it will not cause a time conflict
            newClassSchedule.Events.RemoveAt(classTimePanel.Controls.IndexOf(timePanel));            
            LayoutTimePanels();
        }

        /// <summary>
        /// Put the information for the specified class meeting time into the user input controls and then delete
        /// the ClassMeetingTimePanel so the information can be updated by the user and then saved again.
        /// </summary>
        /// <param name="timePanel">The ClassMeetingTimePanel to edit and remove from the classTimePanel</param>
        /// <param name="startTime">The startTime of the selected time to update</param>
        /// <param name="endTime">The endTime of the selected time to update</param>
        /// <param name="days">The days of the selected time to update</param>
        public void EditTimePanel(ClassMeetingTimePanel timePanel, Time startTime, Time endTime, int[] days)
        {
            startTimePicker.Value = new DateTime(2019, 9, 15, startTime.hours, startTime.minutes, 0);
            endTimePicker.Value = new DateTime(2019, 9, 15, endTime.hours, endTime.minutes, 0);

            foreach (CheckBox box in checkBoxes)
            {
                box.Checked = false;
            }            
            foreach (int day in days)
            {
                checkBoxes[day].Checked = true;
            }

            RemoveTimePanel(timePanel);
        }

        private void EditClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            // if a class is being edited and was not saved, restore the original information for the class
            if (!isSaved && !isNewClass)
            {
                newClassSchedule.Clear();
                foreach (CalendarEvent classEvent in oldClass)
                {
                    newClassSchedule.AddEvent(classEvent);
                }

                newClassSchedule.SaveSchedule(studentWorker.StudentID);
                studentWorker.GetClassSchedule();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // set isSaved to true so the original class will not be restored when the form is closed; this will effectively delete the original class
            isSaved = true;
            this.Close();
        }
    }
}
