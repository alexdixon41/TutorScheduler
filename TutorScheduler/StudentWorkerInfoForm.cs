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

        public StudentWorkerInfoForm(StudentWorker selected)
        {
            InitializeComponent();
            selectedStudentWorker = selected;
        }

        private void AddClassButton_Click(object sender, EventArgs e)
        {
            new AddClass(selectedStudentWorker).Show();
            
            selectedStudentWorker.FetchClassSchedule();
            displayClasses();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if(colorPicker.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = colorPicker.Color;
            }
        }

        private void displayInfo()
        {
            //set name and position
            nameTextBox.Text = selectedStudentWorker.Name;
            positionTextBox.Text = selectedStudentWorker.JobPosition;

            //set color
            int baseColor = selectedStudentWorker.DisplayColor;
            int red = baseColor / 256 / 256;
            int green = baseColor % (256 * 256) / 256;
            int blue = baseColor % 256;
            colorButton.BackColor = Color.FromArgb(255, red, green, blue);

            //set subjects
            displaySubjects();

            //set classes
            displayClasses();
        }

        private void displaySubjects()
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

        private void displayClasses()
        {
            List<CalendarEvent> classes = selectedStudentWorker.ClassSchedule.Events;
            classesListView.Items.Clear();
            Dictionary<string, string> classesByDay = new Dictionary<string, string>();
            string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };            
            foreach (CalendarEvent classEvent in classes)
            {
                // if class with same name already exists, add this event's time and day to it
                if (classesByDay.ContainsKey(classEvent.EventName))
                {
                    classesByDay[classEvent.EventName] += "; " + classEvent.StartTime.ToString() 
                        + " - " + classEvent.EndTime.ToString() + " " + days[classEvent.Day];
                }        
                else
                {
                    classesByDay[classEvent.EventName] = classEvent.StartTime.ToString()
                        + " - " + classEvent.EndTime.ToString() + " " + days[classEvent.Day];
                }
            }

            int i = 0;
            foreach (KeyValuePair<string, string> classEntry in classesByDay) {
                classesListView.Items.Add(classEntry.Key);
                classesListView.Items[i].SubItems.Add(classEntry.Value);
                i++;
            }
        }

        private void StudentWorkerInfoForm_Load(object sender, EventArgs e)
        {
            displayInfo();
        }

        private void AddSubjectButton_Click(object sender, EventArgs e)
        {
            new AddSubjectToStudentWorker(selectedStudentWorker).ShowDialog();
            displaySubjects();
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
                displaySubjects();
            }

        }

        private void GeneralSaveButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new ConfirmationPopup("Would you like to save?", "This will save any changes to name, position, or color").ShowDialog(); 
            if (dialogResult == DialogResult.OK)
            {
                //Save name, position, color
                int color = colorButton.BackColor.ToArgb() & 0x00FFFFFF;
                Console.WriteLine("Color is " + color);
                selectedStudentWorker.UpdateInformation(nameTextBox.Text, positionTextBox.Text, color);
            }
            
        }
    }
}
