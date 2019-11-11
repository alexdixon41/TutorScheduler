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
        public AddNewWorkShift()
        {
            InitializeComponent();
        }

        //Create button is clicked
        private void CreateButton_Click(object sender, EventArgs e)
        {
            //TODO: Make sure that the new work shift doesn't conflict with student worker's class schedule
            //TODO: Create shift
            this.Close();
        }

        private void AddNewWorkShift_Load(object sender, EventArgs e)
        {
            displayStudentWorkers();
        }

        private void displayStudentWorkers()
        {
            studentWorkerListView.Items.Clear();
            List<StudentWorker> studentWorkerList = StudentWorker.GetStudentWorkers();
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
