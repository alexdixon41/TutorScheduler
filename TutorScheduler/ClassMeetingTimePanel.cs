using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorScheduler
{
    public partial class ClassMeetingTimePanel : UserControl
    {        
        private Time StartTime, EndTime;
        private int[] Days;

        public ClassMeetingTimePanel()
        {
            InitializeComponent();
        }

        public void SetMeetingTime(Time startTime, Time endTime, int[] days)
        {
            StartTime = startTime;
            EndTime = endTime;
            Days = days;

            string[] dayLabels = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            string timeText = StartTime.ToString() + " - " + EndTime.ToString() + " ";
            int i = 0;
            foreach (int day in Days)
            {
                timeText += (i == 0 ? "" : ", ") + dayLabels[day];
                i += 1;
            }

            timeLabel.Text = timeText;            
        }      

        private void EditButton_Click(object sender, EventArgs e)
        {
            (ParentForm as EditClass).EditTimePanel(this, StartTime, EndTime, Days);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {            
            (ParentForm as EditClass).RemoveTimePanel(this);            
        }
    }
}
