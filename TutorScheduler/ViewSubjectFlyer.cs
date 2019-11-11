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
            List<StudentWorker> tutorList = selectedSubject.getTutors();
            foreach (StudentWorker tutor in tutorList)
            {
                tutor.fetchWorkSchedule();
                Schedule tutorSchedule = tutor.GetWorkSchedule();
                //TODO: Combine work schedules into one flyer
            }
        }

    }
}
