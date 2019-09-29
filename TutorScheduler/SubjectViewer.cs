﻿using System;
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
    public partial class ViewAllSubjects : Form
    {
        #region Windows Form Generated Code
        public ViewAllSubjects()
        {
            InitializeComponent();
            


           
        }
        #endregion
        private void AddSubjectButton_Click(object sender, EventArgs e)
        {
            new AddNewSubject().Show();
        }

        //Remove button is clicked
        private void RemoveSubject_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new ConfirmationPopup("Are you sure you want to remove this subject?", "This will remove it from all student workers.").ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                //Remove the subject
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private void SubjectList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //View subject flyer button is clicked
        private void ViewFlyerButton_Click(object sender, EventArgs e)
        {
            new ViewSubjectFlyer().Show();
        }
    }
}
