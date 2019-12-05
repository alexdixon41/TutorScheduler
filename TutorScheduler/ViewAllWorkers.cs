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
using System.Diagnostics;

namespace TutorScheduler
{
    public partial class ViewAllWorkers : Form
    {        
        public ViewAllWorkers()
        {
            InitializeComponent();            
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
                swItems.Add(new ListViewItem(""));
                swItems[i].SubItems.Add(student.Name);
                swItems[i].SubItems.Add(student.JobPosition);
                swItems[i].SubItems.Add(GetSubjectString(student));                

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
            DisplayStudentWorkers();
        }       

        private void ViewAllWorkers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.SelectedWorkers.Clear();
            for (int i = 0; i < studentWorkerListView.Items.Count; i++)
            {
                bool itemChecked = studentWorkerListView.Items[i].Checked;
                if (itemChecked)
                {
                    Properties.Settings.Default.SelectedWorkers.Add(StudentWorker.allStudentWorkers[i].StudentID.ToString());
                }
                StudentWorker.allStudentWorkers[i].Selected = itemChecked;
            }
            Properties.Settings.Default.Save();
            RefreshCalendars.Refresh();
        }

        private void StudentWorkerListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(studentWorkerListView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                studentWorkerListView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in studentWorkerListView.Items)
                    item.Checked = !value;                    

                studentWorkerListView.Invalidate();
            }
            else if (e.Column == 1)
            {
                // sort the list of student workers by first name
                StudentWorker.allStudentWorkers.Sort((x, y) => x.Name.CompareTo(y.Name));
                DisplayStudentWorkers();
            }
            else if (e.Column == 2)
            {
                // sort the list of student workers by position
                StudentWorker.allStudentWorkers.Sort((x, y) => x.JobPosition.CompareTo(y.JobPosition));
                DisplayStudentWorkers();
            }
        }      

        private void StudentWorkerListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void StudentWorkerListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void StudentWorkerListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void StudentWorkerListView_DoubleClick(object sender, EventArgs e)
        {
            if (studentWorkerListView.SelectedIndices.Count != 0)
            {
                StudentWorker selectedStudentWorker = StudentWorker.allStudentWorkers[studentWorkerListView.SelectedItems[0].Index];
                new StudentWorkerInfoForm(selectedStudentWorker).ShowDialog();
                StudentWorker.allStudentWorkers = StudentWorker.GetStudentWorkers();
                DisplayStudentWorkers();
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
