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
        private List<StudentWorker> studentWorkers = StudentWorker.GetStudentWorkers();

        public ViewAllWorkers()
        {
            InitializeComponent();
        }

        private void SelectedButton_Click(object sender, EventArgs e)
        {
            new StudentWorkerInfoForm().Show();
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
                    selectedStudentWorker.removeStudentWorker();
                    //TODO: Remove all the student worker's schedule events and subjects

                    updateStudentWorkerList();
                    displayStudentWorkers();
                }
            }

        }

        private void NewStudentWorkerButton_Click(object sender, EventArgs e)
        {
            new AddNewStudentWorker().ShowDialog();
            updateStudentWorkerList();
            displayStudentWorkers();
        }

        private void displayStudentWorkers()
        {
            studentWorkerListView.Items.Clear();
            int i = 0;
            foreach (StudentWorker student in studentWorkers)
            {                
                studentWorkerListView.Items.Add(student.Name);
                studentWorkerListView.Items[i].SubItems.Add(student.JobPosition);
                //TODO: Get student worker's subjects and display them in list view

                if (student.Selected)
                {
                    studentWorkerListView.Items[i].Checked = true;                    
                }
                i++;
            }
        }

        private void updateStudentWorkerList()
        {            
            studentWorkers = StudentWorker.GetStudentWorkers();         // retrieve student workers from the database

            // the selected worker IDs from application settings
            StringCollection selectedWorkers = Properties.Settings.Default.SelectedWorkers; 

            // check all the selected workers
            foreach (StudentWorker worker in studentWorkers)
            {
                if (selectedWorkers.Contains(worker.StudentID.ToString()))
                {
                    worker.Selected = true;
                }
            }            
        }

        private void ViewAllWorkers_Load(object sender, EventArgs e)
        {
            updateStudentWorkerList();
            displayStudentWorkers();
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
    }
}
