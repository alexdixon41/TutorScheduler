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
    public partial class StudentWorkerInfoForm : Form
    {
        StudentWorker selectedStudentWorker;
        List<Subject> subjectsTutored;

        // dictionary of class events where key is the EventDetailsID and value is a list of ScheduleEvents for the EventDetails
        Dictionary<int, List<CalendarEvent>> eventsByClass = new Dictionary<int, List<CalendarEvent>>();

        public StudentWorkerInfoForm(StudentWorker selected)
        {
            InitializeComponent();
            selectedStudentWorker = selected;
        }

        private void AddClassButton_Click(object sender, EventArgs e)
        {
            new EditClass(selectedStudentWorker).ShowDialog();            
            DisplayClasses();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if(colorPicker.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = colorPicker.Color;
            }
        }

        private void DisplayInfo()
        {
            //set name and position
            nameTextBox.Text = selectedStudentWorker.Name;
            positionComboBox.Text = selectedStudentWorker.JobPosition;

            selectedStudentWorker.UpdateTotalHours();
            totalHoursLabel.Text = "Total Work Hours: " + selectedStudentWorker.TotalHours;

            //set color
            int baseColor = selectedStudentWorker.DisplayColor;
            int red = baseColor / 256 / 256;
            int green = baseColor % (256 * 256) / 256;
            int blue = baseColor % 256;
            colorButton.BackColor = Color.FromArgb(255, red, green, blue);

            //set subjects
            DisplaySubjects();

            //set classes
            DisplayClasses();
        }

        private void DisplaySubjects()
        {
            subjectsTutored = selectedStudentWorker.GetSubjectsTutored();
            subjectListView.Items.Clear();
            int i = 0;
            foreach (Subject subject in subjectsTutored)
            {
                String subjStr = subject.abbreviation + " " + subject.subjectNumber;
                subjectListView.Items.Add(subjStr);
                subjectListView.Items[i].SubItems.Add(subject.name);
                i++;
            }
        }

        /// <summary>
        /// Display the list of class names and meeting times for the selected student worker
        /// </summary>
        private void DisplayClasses()
        {
            selectedStudentWorker.GetClassSchedule();
            classesListView.Items.Clear();
            eventsByClass.Clear();
            string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };            
            foreach (CalendarEvent classEvent in selectedStudentWorker.ClassSchedule.Events)
            {
                if (!eventsByClass.ContainsKey(classEvent.DetailsID))
                {
                    eventsByClass[classEvent.DetailsID] = new List<CalendarEvent>();
                }
                eventsByClass[classEvent.DetailsID].Add(classEvent);
            }

            // loop through each class entry
            int i = 0;
            foreach (KeyValuePair<int, List<CalendarEvent>> classEntry in eventsByClass)
            {
                string times = "";
                string className = "";
                // loop through each event for a class
                foreach (CalendarEvent classEvent in classEntry.Value) {                    
                    times += (times == "" ? "" : "; ") + days[classEvent.Day] + " " + classEvent.StartTime.ToString() + " - " + classEvent.EndTime.ToString();
                }
                if (classEntry.Value[0] != null)
                {
                    className = classEntry.Value[0].EventName;
                }
                classesListView.Items.Add(className);
                classesListView.Items[i].SubItems.Add(times);
                classesListView.Items[i].Tag = classEntry.Key;
                i++;
            }
        }
       
        private void StudentWorkerInfoForm_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void AddSubjectButton_Click(object sender, EventArgs e)
        {
            new AddSubjectToStudentWorker(selectedStudentWorker).ShowDialog();
            DisplaySubjects();
        }

        private void RemoveSubjectButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new ConfirmationPopup("Are you sure you want to remove the subject(s)?", "This will only remove them from " + selectedStudentWorker.Name).ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                int i = 0;
                foreach (Subject subject in subjectsTutored)
                {
                    if (subjectListView.Items[i].Checked)
                    {
                        selectedStudentWorker.RemoveSubjectTutored(subject.subjectID);
                    }
                    i++;
                }

                //Refresh list of subjects
                DisplaySubjects();
            }

        }     

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StudentWorkerInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Save name, position, color
            int color = colorButton.BackColor.ToArgb() & 0x00FFFFFF;
            selectedStudentWorker.UpdateInformation(nameTextBox.Text, positionComboBox.Text, color);
            RefreshCalendars.Refresh();
        }

        private void ClassesListView_DoubleClick(object sender, EventArgs e)
        {
            if (classesListView.SelectedIndices.Count != 0)
            {
                Console.WriteLine(classesListView.SelectedItems[0].Index + ": " + classesListView.SelectedItems[0].Tag);
                int eventDetailsID = Convert.ToInt32(classesListView.SelectedItems[0].Tag);
                new EditClass(selectedStudentWorker, eventDetailsID).ShowDialog();                
                DisplayClasses();
            }
        }
    }
}
