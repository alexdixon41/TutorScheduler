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
        Subject selectedSubject;

        public ViewSubjectFlyer(Subject selected)
        {
            InitializeComponent();
            selectedSubject = selected;
        }

        private void setFlyer() {
            List<StudentWorker> tutorList = selectedSubject.GetTutors();
            IndividualSchedule subjectSchedule = new IndividualSchedule();
            IndividualSchedule tutorSchedule = new IndividualSchedule();
            subjectLabel.Text = selectedSubject.abbreviation + " " + selectedSubject.subjectNumber;

            resetLabels();

            foreach (StudentWorker tutor in tutorList)
            {
                tutor.GetWorkSchedule();
                foreach(CalendarEvent newEvent in tutor.WorkSchedule.Events)
                {
                    tutorSchedule.AddEvent(newEvent);
                }
            }

            foreach(CalendarEvent shift in tutorSchedule.Events)
            {
                if (!subjectSchedule.Contains(shift))
                {
                    if (!subjectSchedule.CoverageOverlaps(shift))
                    {
                        subjectSchedule.AddEvent(shift);
                    }
                    else
                    {
                        subjectSchedule.Merge(shift);
                    }
                }
            }

            setLabels(subjectSchedule);

        }

        private void setLabels(IndividualSchedule subjectSchedule)
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

        private void resetLabels()
        {
            mondayLabel.Text = "Monday:  ";
            tuesdayLabel.Text = "Tuesday:  ";
            wednesdayLabel.Text = "Wednesday:  ";
            thursdayLabel.Text = "Thursday:  ";
            fridayLabel.Text = "Friday:  ";
        }

        private void ViewSubjectFlyer_Load(object sender, EventArgs e)
        {
            setFlyer();
        }
    }
}
