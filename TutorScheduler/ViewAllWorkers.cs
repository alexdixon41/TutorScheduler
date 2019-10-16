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
                i++;
            }
        }

        private void updateStudentWorkerList()
        {
            studentWorkers = StudentWorker.GetStudentWorkers();
        }

        private void ViewAllWorkers_Load(object sender, EventArgs e)
        {
            updateStudentWorkerList();
            displayStudentWorkers();
        }
    }
}
