﻿using System;
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
using System.Diagnostics;

namespace TutorScheduler
{
    public partial class ViewAllWorkers : Form
    {        
        public ViewAllWorkers()
        {
            InitializeComponent();            
        }

        Stopwatch stopwatch = new Stopwatch();

        private void SelectedButton_Click(object sender, EventArgs e)
        {
            if (studentWorkerListView.SelectedIndices.Count != 0)
            {
                StudentWorker selectedStudentWorker = StudentWorker.allStudentWorkers[studentWorkerListView.SelectedItems[0].Index];
                new StudentWorkerInfoForm(selectedStudentWorker).ShowDialog();
                StudentWorker.allStudentWorkers = StudentWorker.GetStudentWorkers();                
                DisplayStudentWorkers();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (studentWorkerListView.SelectedIndices.Count != 0)
            {
                //Get selected student worker
                StudentWorker selectedStudentWorker = StudentWorker.allStudentWorkers[studentWorkerListView.SelectedItems[0].Index];

                //Ask for confirmation from the user
                DialogResult dialogResult = new ConfirmationPopup("Are you sure you want to remove " + selectedStudentWorker.Name + "?", "This will remove them from the schedule.").ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    //Remove the student worker
                    selectedStudentWorker.RemoveStudentWorker();
                    //TODO: Remove all the student worker's schedule events and subjects

                    StudentWorker.allStudentWorkers = StudentWorker.GetStudentWorkers();                    
                    DisplayStudentWorkers();
                }
            }

        }

        private void NewStudentWorkerButton_Click(object sender, EventArgs e)
        {
            new AddNewStudentWorker().ShowDialog();
            StudentWorker.allStudentWorkers = StudentWorker.GetStudentWorkers();
            DisplayStudentWorkers();
        }

        private void DisplayStudentWorkers()
        {           
            List<ListViewItem> swItems = new List<ListViewItem>();

            int i = 0;
            foreach (StudentWorker student in StudentWorker.allStudentWorkers)
            {
                swItems.Add(new ListViewItem(student.Name));
                swItems[i].SubItems.Add(student.JobPosition);
                //TODO: Get student worker's subjects and display them in list view

                if (student.Selected)
                {
                    swItems[i].Checked = true;
                }
                i++;
            }

            studentWorkerListView.BeginUpdate();
            studentWorkerListView.Items.Clear();
            studentWorkerListView.Items.AddRange(swItems.ToArray());
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
            //DisplayStudentWorkers();
        }

        private void StudentWorkerListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int checkedID = StudentWorker.allStudentWorkers[e.Item.Index].StudentID;
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

        private void ViewAllWorkers_Shown(object sender, EventArgs e)
        {            
            DisplayStudentWorkers();
        }
    }
}
