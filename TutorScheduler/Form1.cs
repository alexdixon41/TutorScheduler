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
        Button leftDayButton, rightDayButton;
        Label selectedDayLabel;                         // save the selected day for day view

        public Form1()
        {
            InitializeComponent();

            // create day selection buttons for day view
            rightDayButton = new Button();
            leftDayButton = new Button();

            rightDayButton.Height = 40;
            rightDayButton.Width = 80;
            rightDayButton.Text = "Next";
            rightDayButton.Visible = false;
            rightDayButton.Location = new Point(0, 0);
            leftDayButton.Height = 40;
            leftDayButton.Width = 80;
            leftDayButton.Text = "Previous";
            leftDayButton.Visible = false;
            leftDayButton.Location = new Point(0, 0);

            Controls.Add(leftDayButton);
            Controls.Add(rightDayButton);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {            
            this.MinimumSize = new Size(800, 600);    
            
            dayLabels = new Label[] { mondayLabel, tuesdayLabel, wednesdayLabel, thursdayLabel, fridayLabel };
            selectedDayLabel = dayLabels[0];

            // add day change buttons to the dayLabelPanel for easier positioning
            dayLabelPanel.Controls.Add(leftDayButton);
            dayLabelPanel.Controls.Add(rightDayButton);
            leftDayButton.Top = selectedDayLabel.Top;
            rightDayButton.Top = selectedDayLabel.Top;

            ResizeHandler handler = new ResizeHandler(ResizeDayLabels);
            calendarWeekView1.resizeEvent += handler;
            calendarDayView1.resizeEvent += handler;

            calendarPanel.MouseWheel += new MouseEventHandler(CalendarPanel_MouseWheel);        // add the MouseWheel event handler to calendarPanel

            // scroll down until 7am is at the top of the panel when the form is first shown
            ScrollPosition = new Point(0, 592);
            calendarPanel.AutoScrollPosition = ScrollPosition;

            // TODO only show schedule of selected student workers
            // get all student workers and their schedules from database
            List<StudentWorker> studentWorkers = StudentWorker.GetStudentWorkers();

            // TODO - in separate thread, load events for selected student workers into a list
            // in this thread, add the list of events to week view and day view

            PopulateCalendars(studentWorkers);            

            calendarWeekView1.Invalidate();
            calendarDayView1.Invalidate();            
        }

        private void PopulateCalendars(List<StudentWorker> studentWorkers)
        {
            // TODO - only get selected student workers
            foreach (StudentWorker sw in studentWorkers)
            {
                sw.BuildAvailabilitySchedule();
                calendarWeekView1.AddSchedule(sw.GetClassSchedule());               
                calendarWeekView1.AddSchedule(sw.GetAvailabilitySchedule());
            }
        }

        private void ResizeDayLabels(object sender, CalendarResizedEventArgs e)
        {
            // set position and width for each day label upon repaint
            for (int i = 0; i < e.dayStartPositions.Length - 1; i++)
            {                
                dayLabels[i].Left = e.dayStartPositions[i];
                dayLabels[i].Width = e.dayStartPositions[i + 1] - e.dayStartPositions[i] + 1;
            }

            if (weekView)
            {
                // hide day change button for week view
                leftDayButton.Visible = false;
                rightDayButton.Visible = false;
            }
            else
            {
                // show day change buttons for day view
                rightDayButton.Left = e.dayStartPositions[0] + selectedDayLabel.Width + 60;
                rightDayButton.Visible = true;
                leftDayButton.Left = e.dayStartPositions[0] - 60 - rightDayButton.Width;
                leftDayButton.Visible = true;
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

                // draw day labels
                dayLabels = new Label[] { selectedDayLabel };

                for (int i = 0; i < dayLabelPanel.Controls.Count; i++)
                {
                    if (dayLabelPanel.Controls[i].GetType() == typeof(Label)) 
                    {
                        if (dayLabelPanel.Controls[i] != selectedDayLabel)
                        {
                            dayLabelPanel.Controls[i].Visible = false;
                        }                     
                    }
                }
                selectedDayLabel.Visible = true;
                selectedDayLabel.TextAlign = ContentAlignment.MiddleCenter;
               
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
