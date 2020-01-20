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
    public partial class CreateWorkEventForm : Form
    {
        List<StudentWorker> studentWorkerList;
        CheckBox[] checkBoxes;

        public CreateWorkEventForm()
        {
            InitializeComponent();

            checkBoxes = new CheckBox[] { mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };

            Text = "Add New Work Event";
        }                        

        //Create button is clicked
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (studentWorkerListView.SelectedIndices.Count != 0)
            {
                StudentWorker selectedStudentWorker = studentWorkerList[studentWorkerListView.SelectedItems[0].Index];
                selectedStudentWorker.UpdateTotalHours();
                IndividualSchedule newShifts = new IndividualSchedule();
                bool shouldSave = true;
                bool boxChecked = false;

                for (int i = 0; i < checkBoxes.Length; i++)
                {
                    if (checkBoxes[i].Checked)
                    {
                        boxChecked = true;
                        Time startTime = new Time(startTimePicker.Value.TimeOfDay.Hours, startTimePicker.Value.TimeOfDay.Minutes);
                        Time endTime = new Time(endTimePicker.Value.TimeOfDay.Hours, endTimePicker.Value.TimeOfDay.Minutes);
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
                            if ((selectedStudentWorker.JobPosition.Equals("Guru") || selectedStudentWorker.JobPosition.Equals("Lead Guru")) && selectedStudentWorker.TotalHours + (endTime - startTime).ToDouble() > 20)
                            {
                                result = new ConfirmationPopup("Adding this work shift will put " + selectedStudentWorker.Name + " over 20 hours a week.", "Are you sure you want to do this?").ShowDialog();
                                if (!(result == DialogResult.OK))
                                {
                                    shouldSave = false;
                                }
                            }

                            if (result == DialogResult.OK)
                            {
                                //Create new event
                                CalendarEvent newWorkEvent = new CalendarEvent("Work", startTime, endTime, i, CalendarEvent.WORK, selectedStudentWorker.Name, selectedStudentWorker.StudentID, selectedStudentWorker.DisplayColor);

                                //Make sure that the new work shift doesn't conflict with student worker's class schedule
                                //if the new work event is in the student's availability schedule
                                if (selectedStudentWorker.GetAvailabilitySchedule().Contains(newWorkEvent) && !selectedStudentWorker.WorkSchedule.Overlaps(newWorkEvent))
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
                    }

                }
                if (boxChecked && shouldSave)
                {
                    newShifts.SaveSchedule(selectedStudentWorker.StudentID);
                    this.Close();
                }
                else if (!boxChecked)
                {
                    new AlertDialog("You must select a day for the shift.").ShowDialog();
                }
            }
        }

        private void AddNewWorkShift_Load(object sender, EventArgs e)
        {
            DisplayStudentWorkers();
        }

        private void DisplayStudentWorkers()
        {
            studentWorkerListView.Items.Clear();
            studentWorkerList = StudentWorker.allStudentWorkers;
            int i = 0;
            foreach (StudentWorker studentWorker in studentWorkerList)
            {
                studentWorker.UpdateTotalHours();
                studentWorkerListView.Items.Add(studentWorker.Name);
                studentWorkerListView.Items[i].SubItems.Add(studentWorker.JobPosition);
                studentWorkerListView.Items[i].SubItems.Add(studentWorker.TotalHours.ToString());
                studentWorkerListView.Items[i].SubItems.Add(GetSubjectString(studentWorker));
                i++;
            }
        }

        private string GetSubjectString(StudentWorker studentWorker)
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

        private void CreateWorkEventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshCalendars.Refresh();
        }

        private void StudentWorkerListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                // sort by first name
                StudentWorker.allStudentWorkers.Sort((x, y) => x.Name.CompareTo(y.Name));
                DisplayStudentWorkers();
            }
            else if (e.Column == 1)
            {
                // sort by job position
                StudentWorker.allStudentWorkers.Sort((x, y) => x.JobPosition.CompareTo(y.JobPosition));
                DisplayStudentWorkers();
            }
        }
    }
}
