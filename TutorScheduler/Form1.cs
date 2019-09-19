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
        Point ScrollPosition = new Point(0, 0);         // save the scroll position so it can be restored when panel is resized

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {            
            this.MinimumSize = new Size(800, 600);

            // scroll down until 7am is at the top of the panel when the form is first shown
            ScrollPosition = new Point(0, 592);            
            calendarPanel.AutoScrollPosition = ScrollPosition;

            calendarPanel.MouseWheel += new MouseEventHandler(CalendarPanel_MouseWheel);        // add the MouseWheel event handler to calendarPanel

            StudentWorker alex = new StudentWorker("Alex Dixon");

            // add schedule to calendar view
            ClassSchedule schedule = new ClassSchedule();
            schedule.AddClassMeeting(new CalendarEvent(new Time(10, 10), new Time(11, 0), (int)Day.Monday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(10, 10), new Time(11, 0), (int)Day.Wednesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(10, 10), new Time(11, 0), (int)Day.Friday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(11, 15), new Time(12, 5), (int)Day.Monday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(11, 15), new Time(12, 5), (int)Day.Wednesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(14, 30), new Time(17, 15), (int)Day.Wednesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(12, 30), new Time(13, 45), (int)Day.Tuesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(12, 30), new Time(13, 45), (int)Day.Thursday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(14, 0), new Time(15, 15), (int)Day.Tuesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(14, 0), new Time(15, 15), (int)Day.Thursday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(16, 45), new Time(18, 0), (int)Day.Tuesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddClassMeeting(new CalendarEvent(new Time(16, 45), new Time(18, 0), (int)Day.Thursday, CalendarEvent.CLASS, alex.Name));

            
            alex.SetClassSchedule(schedule);

            calendarWeekView1.AddEvents(schedule.classMeetings);

            alex.BuildAvailabilitySchedule();

            calendarWeekView1.AddEvents(alex.GetAvailabilitySchedule().availableTimes);
        }

        private void CalendarPanel_Scroll(object sender, ScrollEventArgs e)
        {
            // save scroll position          
            ScrollPosition = new Point(0, calendarPanel.AutoScrollPosition.Y * -1);           
        }

        private void CalendarPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            // save scroll position
            ScrollPosition = new Point(0, calendarPanel.AutoScrollPosition.Y * -1);            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // restore scroll position
            calendarPanel.AutoScrollPosition = ScrollPosition;          
        }

        //Add a student worker is clicked
        private void AddStudentWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        //View all student workers is clicked
        private void ViewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllWorkers form = new ViewAllWorkers();
            form.Show();
        }
    }
}
