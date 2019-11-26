using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TutorScheduler
{
    public partial class ViewAllWorkers : Form
    {        
        public ViewAllWorkers()
        {
            InitializeComponent();            
        }

        private List<StudentWorker> studentWorkers;

        private void SelectedButton_Click(object sender, EventArgs e)
        {
            if (studentWorkerListView.SelectedIndices.Count != 0)
            {
                StudentWorker selectedStudentWorker = studentWorkers[studentWorkerListView.SelectedItems[0].Index];
                new StudentWorkerInfoForm(selectedStudentWorker).Show();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (studentWorkerListView.SelectedIndices.Count != 0)
            {
                //Get selected student worker
                StudentWorker selectedStudentWorker = studentWorkers[studentWorkerListView.SelectedItems[0].Index];

                //Ask for confirmation from the user
                DialogResult dialogResult = new ConfirmationPopup("Are you sure you want to remove " + selectedStudentWorker.Name + "?", "This will remove them from the schedule.").ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    //Remove the student worker
                    selectedStudentWorker.RemoveStudentWorker();
                    //TODO: Remove all the student worker's schedule events and subjects

                    StudentWorker.allStudentWorkers = StudentWorker.GetStudentWorkers();
                    studentWorkers = StudentWorker.allStudentWorkers;
                    DisplayStudentWorkers();
                }
            }

        }

        private void NewStudentWorkerButton_Click(object sender, EventArgs e)
        {
            new AddNewStudentWorker().ShowDialog();
            studentWorkers = StudentWorker.allStudentWorkers;
            DisplayStudentWorkers();
        }

        private void DisplayStudentWorkers()
        {
            studentWorkerListView.BeginUpdate();
            studentWorkerListView.Items.Clear();            

            int i = 0;
            foreach (StudentWorker student in studentWorkers)
            {                
                studentWorkerListView.Items.Add(student.Name);
                studentWorkerListView.Items[i].SubItems.Add(student.JobPosition);
                studentWorkerListView.Items[i].SubItems.Add(GetSubjectString(student));

                if (student.Selected)
                {
                    studentWorkerListView.Items[i].Checked = true;
                }
                i++;
            }
            studentWorkerListView.EndUpdate();
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

        private void ViewAllWorkers_Load(object sender, EventArgs e)
        {
            StudentWorker.allStudentWorkers = StudentWorker.GetStudentWorkers();
            studentWorkers = StudentWorker.allStudentWorkers;
            DisplayStudentWorkers();
        }

        private void StudentWorkerListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int checkedID = studentWorkers[e.Item.Index].StudentID;
            if (e.Item.Checked)
            {                
                Properties.Settings.Default.SelectedWorkers.Add(checkedID.ToString());
            }
            else
            {
                Properties.Settings.Default.SelectedWorkers.Remove(checkedID.ToString());
            }            
            Properties.Settings.Default.Save();            
        }

        private void ViewAllWorkers_FormClosed(object sender, FormClosedEventArgs e)
        {            
            RefreshCalendars.Refresh();
        }

        private void StudentWorkerListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                // sort list view items by name
                
            }
        }
    }
}
