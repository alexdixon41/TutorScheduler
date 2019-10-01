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
        Label[] dayLabels;                              // the weekday labels on top of the calendar
        bool weekView = true;                           // whether the calendar view mode is set to week view or day view
        DayOfWeek dayShown = DayOfWeek.Monday;          // which day of the week is shown when in day view mode

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {            
            this.MinimumSize = new Size(800, 600);    
            
            dayLabels = new Label[] { mondayLabel, tuesdayLabel, wednesdayLabel, thursdayLabel, fridayLabel };            

            ResizeHandler handler = new ResizeHandler(ResizeDayLabels);
            calendarWeekView1.resizeEvent += handler;
            calendarDayView1.resizeEvent += handler;

            calendarPanel.MouseWheel += new MouseEventHandler(CalendarPanel_MouseWheel);        // add the MouseWheel event handler to calendarPanel

            // scroll down until 7am is at the top of the panel when the form is first shown
            ScrollPosition = new Point(0, 592);
            calendarPanel.AutoScrollPosition = ScrollPosition;            

            StudentWorker alex = new StudentWorker("Alex Dixon");

            // add schedule to calendar view
            Schedule schedule = new Schedule(CalendarEvent.CLASS);
            schedule.AddEvent(new CalendarEvent(new Time(10, 10), new Time(11, 0), (int)Day.Monday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(10, 10), new Time(11, 0), (int)Day.Wednesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(10, 10), new Time(11, 0), (int)Day.Friday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(11, 15), new Time(12, 5), (int)Day.Monday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(11, 15), new Time(12, 5), (int)Day.Wednesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(14, 30), new Time(17, 15), (int)Day.Wednesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(12, 30), new Time(13, 45), (int)Day.Tuesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(12, 30), new Time(13, 45), (int)Day.Thursday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(14, 0), new Time(15, 15), (int)Day.Tuesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(14, 0), new Time(15, 15), (int)Day.Thursday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(16, 45), new Time(18, 0), (int)Day.Tuesday, CalendarEvent.CLASS, alex.Name));
            schedule.AddEvent(new CalendarEvent(new Time(16, 45), new Time(18, 0), (int)Day.Thursday, CalendarEvent.CLASS, alex.Name));

            
            alex.SetClassSchedule(schedule);

            calendarWeekView1.AddEvents(schedule.events);
            calendarDayView1.AddEvents(schedule.events);

            alex.BuildAvailabilitySchedule();

            calendarWeekView1.AddEvents(alex.GetAvailabilitySchedule().events);
            calendarDayView1.AddEvents(alex.GetAvailabilitySchedule().events);
        }

        private void ResizeDayLabels(object sender, CalendarResizedEventArgs e)
        {
            // set position and width for each day label upon repaint
            for (int i = 0; i < e.dayStartPositions.Length - 1; i++)
            {                
                dayLabels[i].Left = e.dayStartPositions[i];
                dayLabels[i].Width = e.dayStartPositions[i + 1] - e.dayStartPositions[i] + 1;
            }

            // restore scroll position
            calendarPanel.AutoScrollPosition = ScrollPosition;
        }
        

        private void CalendarPanel_Scroll(object sender, ScrollEventArgs e)
        {
            // save scroll position          
            ScrollPosition = new Point(0, Math.Abs(calendarPanel.AutoScrollPosition.Y));           
        }

        private void CalendarPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            // save scroll position
            ScrollPosition = new Point(0, Math.Abs(calendarPanel.AutoScrollPosition.Y));            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // restore scroll position
            calendarPanel.AutoScrollPosition = ScrollPosition;            
        }

        //Add a student worker is clicked
        private void AddStudentWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new StudentWorkerInfoForm().Show();
        }

        //View all student workers is clicked
        private void ViewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewAllWorkers().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calendarPanel.AutoScrollPosition = ScrollPosition;
        }    

        private void Form1_Activated(object sender, EventArgs e)
        {
            calendarPanel.AutoScrollPosition = ScrollPosition;           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            calendarPanel.AutoScrollPosition = ScrollPosition;
        }

        private void MenuStrip1_MenuActivate(object sender, EventArgs e)
        {
            calendarPanel.AutoScrollPosition = ScrollPosition;
        }

        private void MenuStrip1_MenuDeactivate(object sender, EventArgs e)
        {
            calendarPanel.AutoScrollPosition = ScrollPosition;
        }

        //View all subjects is clicked 
        private void ViewAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ViewAllSubjects().Show();
        }

        private void AddSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddNewSubject().Show();
        }

        private void CalendarWeekView1_Click(object sender, EventArgs e)
        {
            new AddNewWorkShift().Show();
        }

        // switch between week view and day view
        private void DayViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (weekView)
            {
                weekView = false;
                dayLabels = new Label[] { mondayLabel };
                foreach (Label l in dayLabelPanel.Controls)
                {
                    if (dayLabels.Contains<Label>(l)) {
                        l.Visible = true;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        l.Visible = false;
                    }
                }
                calendarDayView1.Invalidate();
                calViewToolStripMenuItem.Text = "Switch to Week View";            // change the menu item text to switch back to week view
                calendarWeekView1.Visible = false;
                calendarDayView1.Visible = true;
            }
            else
            {
                weekView = true;
                dayLabels = new Label[] { mondayLabel, tuesdayLabel, wednesdayLabel, thursdayLabel, fridayLabel };
                foreach (Label l in dayLabels)
                {
                    l.Visible = true;
                    l.TextAlign = ContentAlignment.MiddleLeft;
                }
                calViewToolStripMenuItem.Text = "Switch to Day View";             // change the menu item text to switch to day view
                calendarDayView1.Visible = false;
                calendarWeekView1.Visible = true;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SelectStudentWorkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DisplayStudentWorkers().Show();
        }
    }
}
