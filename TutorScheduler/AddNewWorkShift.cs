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
    public partial class AddNewWorkShift : Form
    {
        List<StudentWorker> studentWorkerList;


        public AddNewWorkShift()
        {
            InitializeComponent();
        }

        //Create button is clicked
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (studentWorkerListView.SelectedIndices.Count != 0)
            {
                StudentWorker selectedStudentWorker = studentWorkerList[studentWorkerListView.SelectedItems[0].Index];
                CheckBox[] checkBoxes = { mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
                Schedule newShifts = new Schedule();
                bool shouldSave = true;

                for (int i = 0; i < checkBoxes.Length; i++)
                {
                    if (checkBoxes[i].Checked)
                    {
                        //TODO: Verify event info

                        Time startTime = new Time(startTimePicker.Value.TimeOfDay.Hours, startTimePicker.Value.TimeOfDay.Minutes);
                        Time endTime = new Time(endTimePicker.Value.TimeOfDay.Hours, endTimePicker.Value.TimeOfDay.Minutes);
                        //Create new event
                        CalendarEvent newWorkEvent = new CalendarEvent(startTime, endTime, i, CalendarEvent.WORK, selectedStudentWorker.Name, selectedStudentWorker.DisplayColor);

                        //Make sure that the new work shift doesn't conflict with student worker's class schedule
                        //if the new work event is in the student's availability schedule
                        if (selectedStudentWorker.GetAvailabilitySchedule().Contains(newWorkEvent) && !selectedStudentWorker.GetWorkSchedule().Overlaps(newWorkEvent))
                        {
                            newShifts.AddEvent(newWorkEvent);
                        }
                        else
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
                    newShifts.SaveSchedule(selectedStudentWorker.StudentID);
                }
            }
            this.Close();
        }

        private void AddNewWorkShift_Load(object sender, EventArgs e)
        {
            displayStudentWorkers();
        }

        private void displayStudentWorkers()
        {
            studentWorkerListView.Items.Clear();
            studentWorkerList = StudentWorker.GetStudentWorkers();
            int i = 0;
            foreach (StudentWorker studentWorker in studentWorkerList)
            {
                studentWorkerListView.Items.Add(studentWorker.Name);
                studentWorkerListView.Items[i].SubItems.Add(studentWorker.JobPosition);
                studentWorkerListView.Items[i].SubItems.Add(getSubjectString(studentWorker));
                i++;
            }
        }

        private string getSubjectString(StudentWorker studentWorker)
        {
            string subjectString = "";

            //Get all subjects tutored by the student worker
            List<Subject> subjectList = studentWorker.GetSubjectsTutored();

            //Add each subject into string
            foreach (Subject subject in subjectList)
            {
                subjectString += subject.abbreviation + " " + subject.subjectNumber + ", ";
            }

            //Remove the final comma
            if (subjectString.Length > 0)
                subjectString = subjectString.Substring(0, (subjectString.Length - 2));

            return subjectString;
        }

    }
}
