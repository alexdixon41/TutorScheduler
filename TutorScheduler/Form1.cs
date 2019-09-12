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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // scroll down until 7am is at the top of the panel when the form is first shown
            calendarPanel.AutoScrollPosition = new Point(0, 592);

            // add schedule to calendar view
            ClassSchedule schedule = new ClassSchedule();
            schedule.AddClassMeeting(new CalendarEvent(new Time(10, 10), new Time(11, 0), (int)Day.Monday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(10, 10), new Time(11, 0), (int)Day.Wednesday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(10, 10), new Time(11, 0), (int)Day.Friday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(11, 15), new Time(12, 5), (int)Day.Monday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(11, 15), new Time(12, 5), (int)Day.Wednesday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(14, 30), new Time(17, 15), (int)Day.Wednesday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(12, 30), new Time(13, 45), (int)Day.Tuesday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(12, 30), new Time(13, 45), (int)Day.Thursday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(14, 0), new Time(15, 15), (int)Day.Tuesday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(14, 0), new Time(15, 15), (int)Day.Thursday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(16, 45), new Time(18, 0), (int)Day.Tuesday, CalendarEvent.CLASS));
            schedule.AddClassMeeting(new CalendarEvent(new Time(16, 45), new Time(18, 0), (int)Day.Thursday, CalendarEvent.CLASS));

            StudentWorker alex = new StudentWorker();
            alex.SetClassSchedule(schedule);

            calendarWeekView1.AddEvents(schedule.classMeetings);

            alex.BuildAvailabilitySchedule();

            calendarWeekView1.AddEvents(alex.GetAvailabilitySchedule().availableTimes);
        }
    }
}
