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
    public partial class AddSubjectToStudentWorker : Form
    {
        StudentWorker selectedStudentWorker;
        private List<Subject> subjectList;

        public AddSubjectToStudentWorker(StudentWorker selected)
        {
            InitializeComponent();
            selectedStudentWorker = selected;
        }

        private void AddSubjectToStudentWorker_Load(object sender, EventArgs e)
        {
            instructionLabel.Text = "Select the subjects you wish to add to " + selectedStudentWorker.Name;
            updateSubjectList();
            displaySubjects();
        }

        private void displaySubjects()
        {
            subjectListView.Items.Clear();
            int i = 0;
            foreach (Subject subject in subjectList)
            {
                string subString = subject.abbreviation + " " + subject.subjectNumber;
                subjectListView.Items.Add(subString);
                subjectListView.Items[i].SubItems.Add(subject.name);
                i++;
            }
        }

        private void updateSubjectList()
        {
            subjectList = Subject.GetSubjects();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Subject subject in subjectList)
            {
                if (subjectListView.Items[i].Checked)
                {
                    selectedStudentWorker.AddSubjectTutored(subject.subjectID);
                }
                i++;
            }
            this.Close();
        }

        private void NewSubjectButton_Click(object sender, EventArgs e)
        {
            new AddNewSubject().ShowDialog();
            updateSubjectList();
            displaySubjects();
        }
    }
}
