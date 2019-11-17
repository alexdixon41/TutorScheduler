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
        bool showAvailability = true;                   // whether to show availability times on the calendar  
        bool showClasses = true;                        // whether to show class times on the calendar
        Button leftDayButton, rightDayButton;
        Label selectedDayLabel;                         // save the selected day for day view

        string[] dayLabelText = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

        List<StudentWorker> studentWorkers = new List<StudentWorker>();

        public Form1()
        {
            InitializeComponent();

            // create day selection buttons for day view
            rightDayButton = new Button();
            leftDayButton = new Button();
            
            rightDayButton.Height = 36;
            rightDayButton.Width = 80;
            rightDayButton.Margin = new Padding(0);
            rightDayButton.Text = "Next";
            rightDayButton.Visible = false;
            rightDayButton.Location = new Point(0, 0);            
            leftDayButton.Height = 36;
            leftDayButton.Width = 80;
            leftDayButton.Margin = new Padding(0);
            leftDayButton.Text = "Previous";
            leftDayButton.Visible = false;
            leftDayButton.Location = new Point(0, 0);

            Controls.Add(leftDayButton);
            Controls.Add(rightDayButton);

            dayLabels = new Label[] { mondayLabel, tuesdayLabel, wednesdayLabel, thursdayLabel, fridayLabel };
            selectedDayLabel = dayLabels[0];

            // hide day labels until they are fully loaded
            dayLabelPanel.Hide();

            // configure and add day change buttons to the dayLabelPanel for easier positioning
            leftDayButton.Top = selectedDayLabel.Top;
            leftDayButton.Click += new EventHandler(LeftDayButton_Click);
            dayLabelPanel.Controls.Add(leftDayButton);
            rightDayButton.Top = selectedDayLabel.Top;
            rightDayButton.Click += new EventHandler(RightDayButton_Click);
            dayLabelPanel.Controls.Add(rightDayButton);

            ResizeHandler handler = new ResizeHandler(ResizeDayLabels);
            calendarWeekView1.resizeEvent += handler;
            calendarDayView1.resizeEvent += handler;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {            
            this.MinimumSize = new Size(800, 600);
                              
            calendarPanel.MouseWheel += new MouseEventHandler(CalendarPanel_MouseWheel);        // add the MouseWheel event handler to calendarPanel

            // scroll down until 7am is at the top of the panel when the form is first shown
            ScrollPosition = new Point(0, 592);
            calendarPanel.AutoScrollPosition = ScrollPosition;

            // get all student workers and their schedules from database
            studentWorkers = StudentWorker.allStudentWorkers;
           
            // load events into the calendar
            PopulateCalendars(studentWorkers);            

            calendarWeekView1.Invalidate();

            // show the day label panel after day labels are sized properly
            dayLabelPanel.Show();                  
        }

        private void PopulateCalendars(List<StudentWorker> studentWorkers)
        {
            calendarWeekView1.Clear();
            calendarDayView1.Clear();
            // TODO - only get selected student workers
            foreach (StudentWorker sw in studentWorkers)
            {
                //if (!sw.Selected)
                //{
                //    continue;
                //}
                // Show work schedule
                Schedule w = sw.GetWorkSchedule();
                calendarWeekView1.AddSchedule(w);
                calendarDayView1.AddSchedule(w);

                // include class schedule only if enabled
                if (showClasses)
                {
                    Schedule s = sw.GetClassSchedule();
                    calendarWeekView1.AddSchedule(s);
                    calendarDayView1.AddSchedule(s);
                }

                // include availability schedule only if enabled
                if (showAvailability)
                {
                    Schedule a = sw.GetAvailabilitySchedule();
                    calendarWeekView1.AddSchedule(a);
                    calendarDayView1.AddSchedule(a);
                }                
            }
                      
            calendarWeekView1.Invalidate();
            calendarDayView1.Invalidate();
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
            new AddNewWorkShift().ShowDialog();
            //Refresh the schedule
            studentWorkers = StudentWorker.allStudentWorkers;
            PopulateCalendars(studentWorkers);

        }

        // switch between week view and day view
        private void DayViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (weekView)
            {
                weekView = false;            

                // draw day labels
                //dayLabels = new Label[] { selectedDayLabel };

                // hide all day labels except selected one
                for (int i = 0; i < dayLabels.Length; i++)
                {
                    if (dayLabels[i] != selectedDayLabel)
                    {
                        Console.WriteLine(i);
                        dayLabels[i].Visible = false;
                    }
                }

                //for (int i = 0; i < dayLabelPanel.Controls.Count; i++)
                //{
                //    if (dayLabelPanel.Controls[i].GetType() == typeof(Label)) 
                //    {
                //        if (dayLabelPanel.Controls[i] != selectedDayLabel)
                //        {
                //            dayLabelPanel.Controls[i].Visible = false;
                //        }                     
                //    }
                //}
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

                // reconfigure day labels before switching back to week view
                dayLabels = new Label[] { mondayLabel, tuesdayLabel, wednesdayLabel, thursdayLabel, fridayLabel };
                int i = 0;
                foreach (Label l in dayLabels)
                {
                    l.Text = dayLabelText[i];
                    l.Visible = true;
                    l.TextAlign = ContentAlignment.MiddleLeft;
                    i++;
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

        private void AvailabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAvailability = !showAvailability;
            PopulateCalendars(studentWorkers);
        }

        private void LeftDayButton_Click(object sender, EventArgs e)
        {
            // move back one day
            if (calendarDayView1.SelectedDay > (int)Day.Monday)
            {
                calendarDayView1.SetDay(calendarDayView1.SelectedDay - 1);
                selectedDayLabel.Text = dayLabelText[calendarDayView1.SelectedDay];
            }
        }

        private void ClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showClasses = !showClasses;
            PopulateCalendars(studentWorkers);
        }

        private void CalendarDayView1_Click(object sender, EventArgs e)
        {
            new AddNewWorkShift().ShowDialog();
            //Refresh the schedule
            studentWorkers = StudentWorker.allStudentWorkers;
            PopulateCalendars(studentWorkers);
        }

        private void RightDayButton_Click(object sender, EventArgs e)
        {
            // move forward one day
            if (calendarDayView1.SelectedDay < (int)Day.Friday)
            {
                calendarDayView1.SetDay(calendarDayView1.SelectedDay + 1);
                selectedDayLabel.Text = dayLabelText[calendarDayView1.SelectedDay];
            }
        }
    }
}
