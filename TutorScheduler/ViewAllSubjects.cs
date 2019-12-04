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
    public partial class ViewAllSubjects : Form
    {
        private List<Subject> subjectList = Subject.GetSubjects();
        
        public ViewAllSubjects()
        {
            InitializeComponent();                       
        }
       
        private void AddSubjectButton_Click(object sender, EventArgs e)
        {
            new AddNewSubject().ShowDialog();
            updateSubjectList();
            displaySubjects();
        }

        //Remove button is clicked
        private void RemoveSubject_Click(object sender, EventArgs e)
        {
            if (subjectListView.SelectedIndices.Count != 0)
            {
                Subject selectedSubject = subjectList[subjectListView.SelectedItems[0].Index];
                DialogResult dialogResult = new ConfirmationPopup("Are you sure you want to remove " + selectedSubject.abbreviation + " " + selectedSubject.subjectNumber, "This will remove it from all student workers.").ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    selectedSubject.RemoveSubject();
                    //TODO: Remove subject from all student workers

                    updateSubjectList();
                    displaySubjects();
                }
            }
        }       

        //View subject flyer button is clicked
        private void ViewFlyerButton_Click(object sender, EventArgs e)
        {
            if (subjectListView.SelectedIndices.Count != 0)
            {
                Subject selectedSubject = subjectList[subjectListView.SelectedItems[0].Index];
                new ViewSubjectFlyer(selectedSubject).Show();
            }
        }

        private void displaySubjects()
        {
            subjectListView.Items.Clear();
            int i = 0;
            foreach (Subject subject in subjectList)
            {
                string subString = subject.abbreviation + " " + subject.subjectNumber;
                subjectListView.Items.Add("");
                subjectListView.Items[i].SubItems.Add(subString);
                subjectListView.Items[i].SubItems.Add(subject.name);
                i++;
            }
        }

        private void updateSubjectList()
        {
            subjectList = Subject.GetSubjects();
        }

        private void ViewAllSubjects_Load(object sender, EventArgs e)
        {
            displaySubjects();
        }

        private void SubjectListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void SubjectListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void SubjectListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void SubjectListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(subjectListView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                subjectListView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in subjectListView.Items)
                    item.Checked = !value;

                subjectListView.Invalidate();
            }
        }

        private void ViewAllSubjects_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool subjSelected = false;
            //Get list of all student workers who tutor the selected subjects
            List<string> tutorList = new List<string>();
             for (int i = 0; i < subjectListView.Items.Count; i++)
            {
                if (subjectListView.Items[i].Checked)
                {
                    subjSelected = true;
                    tutorList.AddRange(subjectList[i].GetTutorIDs());
                }
            }
            tutorList = tutorList.Distinct().ToList();

            //Update properties
            if (subjSelected)
            {
                Properties.Settings.Default.SelectedWorkers.Clear();
                Properties.Settings.Default.SelectedWorkers.AddRange(tutorList.ToArray());
                Properties.Settings.Default.Save();
                RefreshCalendars.Refresh();
                
            }
        }
    }
}
