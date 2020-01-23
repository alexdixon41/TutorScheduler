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
    public partial class ViewSubjectFlyer : Form
    {
        Subject SelectedSubject;

        public ViewSubjectFlyer(Subject selected)
        {
            InitializeComponent();     
            
            SelectedSubject = selected;
            ResetLabels();
            subjectLabel.Text = SelectedSubject.abbreviation + " " + SelectedSubject.subjectNumber;
            SetLabels(SelectedSubject.SetFlyer());
        }
        
        private void SetLabels(IndividualSchedule subjectSchedule)
        {
            Label[] labels = { mondayLabel, tuesdayLabel, wednesdayLabel, thursdayLabel, fridayLabel };
            foreach( CalendarEvent workEvent in subjectSchedule.Events)
            {
                labels[workEvent.Day].Text += workEvent.StartTime.ToString() + " - " + workEvent.EndTime.ToString() + "; ";
            }
            foreach(Label label in labels)
            {
                label.Text = label.Text.Substring(0, label.Text.Length - 2);
            }
        }

        private void ResetLabels()
        {
            mondayLabel.Text = "Monday:  ";
            tuesdayLabel.Text = "Tuesday:  ";
            wednesdayLabel.Text = "Wednesday:  ";
            thursdayLabel.Text = "Thursday:  ";
            fridayLabel.Text = "Friday:  ";
        }
    }
}
