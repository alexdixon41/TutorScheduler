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
        public StudentWorkerInfoForm(StudentWorker selected)
        {
            InitializeComponent();
            selectedStudentWorker = selected;
        }

        private void AddClassButton_Click(object sender, EventArgs e)
        {
            new AddClass().Show();
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
            nameLabel.Text = selectedStudentWorker.Name;
            positionLabel.Text = selectedStudentWorker.JobPosition;

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
            List<Subject> subjectsTutored = selectedStudentWorker.GetSubjectsTutored();
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
            List<CalendarEvent> classes = selectedStudentWorker.GetClassSchedule().Events;
            classesListView.Items.Clear();
            int i = 0;
            foreach (CalendarEvent classEvent in classes)
            {
                //TODO: How to display class name when it isn't stored in the database??
                classesListView.Items.Add("Class " + i);
                classesListView.Items[i].SubItems.Add(classEvent.StartTime.getTimeString());
                classesListView.Items[i].SubItems.Add(classEvent.EndTime.getTimeString());
                classesListView.Items[i].SubItems.Add(""+classEvent.Day);
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
    }
}
