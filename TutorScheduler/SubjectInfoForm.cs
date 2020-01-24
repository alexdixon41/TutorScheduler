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
    public partial class SubjectInfoForm : Form
    {
        Subject selectedSubject;

        public SubjectInfoForm(Subject selected)
        {
            InitializeComponent();
            selectedSubject = selected;
        }

        void displaySubjectInfo()
        {
            nameTextBox.Text = selectedSubject.name;
            abbreviationTextBox.Text = selectedSubject.abbreviation;
            numberTextBox.Text = selectedSubject.subjectNumber;
        }

        void displayTutors()
        {
            List<StudentWorker> tutorList = selectedSubject.GetTutors();
            int i = 0;
            foreach (StudentWorker tutor in tutorList)
            {
                tutorListView.Items.Add(tutor.Name);
                //Add any subitems
            }
        }

        private void SubjectInfoForm_Load(object sender, EventArgs e)
        {
            displaySubjectInfo();
            displayTutors();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            selectedSubject.updateSubject(nameTextBox.Text, abbreviationTextBox.Text, numberTextBox.Text);
            this.Close();
        }
    }
}
