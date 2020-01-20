using System;
using System.Drawing;
using System.Windows.Forms;

namespace TutorScheduler
{
    public partial class Form1 : Form
    {              
        Label[] dayLabels;                              // the weekday labels on top of the calendar
        bool weekView = true;                           // whether the calendar view mode is set to week view or day view
        bool showAvailability = false;                   // whether to show availability times on the calendar  
        bool showClasses = true;                        // whether to show class times on the calendar
        Button leftDayButton, rightDayButton;
        Label selectedDayLabel;                         // save the selected day for day view

        string[] dayLabelText = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };        

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
            rightDayButton.Font = new Font("Microsoft Sans Serif", 10);
            rightDayButton.FlatStyle = FlatStyle.Flat;
            rightDayButton.BackColor = SystemColors.ControlLightLight;
            rightDayButton.FlatAppearance.BorderColor = SystemColors.ControlDark;
            rightDayButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 98, 107);
            rightDayButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(205, 169, 169);
            rightDayButton.Visible = false;
            rightDayButton.Location = new Point(0, 0);            
            leftDayButton.Height = 36;
            leftDayButton.Width = 80;
            leftDayButton.Margin = new Padding(0);
            leftDayButton.Text = "Previous";
            leftDayButton.Font = new Font("Microsoft Sans Serif", 10);
            leftDayButton.FlatStyle = FlatStyle.Flat;
            leftDayButton.BackColor = SystemColors.ControlLightLight;
            leftDayButton.FlatAppearance.BorderColor = SystemColors.ControlDark;
            leftDayButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 98, 107);
            leftDayButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(205, 169, 169);
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

            // set PopulateCalendars as the handler of the RefreshCalendarsEvent
            RefreshCalendars.RefreshCalendarsEvent += new Action(PopulateCalendars);

            // set ResizeDayLabels as the handler of the ResizeHandler of both calendar views
            ResizeHandler handler = new ResizeHandler(ResizeDayLabels);
            calendarWeekView1.ResizeEvent += handler;
            calendarDayView1.resizeEvent += handler;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {            
            this.MinimumSize = new Size(800, 600);                                          

            // scroll down until 7am is at the top of the panel when the form is first shown            
            calendarPanel.AutoScrollPosition = new Point(0, 592);

            // update the Form title
            string scheduleName = DatabaseManager.GetCurrentScheduleName();
            if (scheduleName == "")
            {
                Text = "Tutor Scheduler";
            }
            else
            {
                Text = "Tutor Scheduler - " + scheduleName;
            }

            // load events into the calendar
            RefreshCalendars.Refresh();            

            // show the day label panel after day labels are sized properly
            dayLabelPanel.Show();                  
        }

        private void PopulateCalendars()
        {            
            // refresh student workers from the database
            StudentWorker.allStudentWorkers = StudentWorker.GetStudentWorkers();

            calendarWeekView1.Clear();
            calendarDayView1.Clear();
           
            // TODO - only get selected student workers
            foreach (StudentWorker sw in StudentWorker.allStudentWorkers)
            {
                if (!sw.Selected)
                {
                    continue;
                }
                // Show work schedule
                IndividualSchedule w = sw.WorkSchedule;
                calendarWeekView1.AddSchedule(w);
                calendarDayView1.AddSchedule(w);

                // include class schedule only if enabled
                if (showClasses)
                {
                    IndividualSchedule s = sw.ClassSchedule;
                    calendarWeekView1.AddSchedule(s);
                    calendarDayView1.AddSchedule(s);
                }

                // include availability schedule only if enabled
                if (showAvailability)
                {
                    IndividualSchedule a = sw.GetAvailabilitySchedule();
                    calendarWeekView1.AddSchedule(a);
                    calendarDayView1.AddSchedule(a);
                }                
            }
            
            calendarWeekView1.Invalidate(false);                        
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
        }             

        //View all student workers is clicked
        private void ViewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewAllWorkers().ShowDialog();
        }

        //View all subjects is clicked 
        private void ViewAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ViewAllSubjects().ShowDialog();
        }

        private void AddSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddNewSubject().ShowDialog();
        }

        private void CalendarWeekView1_Click(object sender, EventArgs e)
        {                        
            // Refresh the schedule           
            RefreshCalendars.Refresh();
        }

        private void CalendarDayView1_Click(object sender, EventArgs e)
        {            
            // Refresh the schedule            
            RefreshCalendars.Refresh();
        }

        // switch between week view and day view
        private void DayViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (weekView)
            {
                weekView = false;
                
                selectedDayLabel.Text = dayLabelText[calendarDayView1.SelectedDay];

                // hide all day labels except selected one
                for (int i = 0; i < dayLabels.Length; i++)
                {
                    if (dayLabels[i] != selectedDayLabel)
                    {                        
                        dayLabels[i].Visible = false;
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
            RefreshCalendars.Refresh();
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

        private void RightDayButton_Click(object sender, EventArgs e)
        {
            // move forward one day
            if (calendarDayView1.SelectedDay < (int)Day.Friday)
            {
                calendarDayView1.SetDay(calendarDayView1.SelectedDay + 1);
                selectedDayLabel.Text = dayLabelText[calendarDayView1.SelectedDay];
            }
        }

        private void ClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showClasses = !showClasses;
            RefreshCalendars.Refresh();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OpenScheduleForm().ShowDialog();

            // update schedule name in title
            string scheduleName = DatabaseManager.GetCurrentScheduleName();
            if (scheduleName == "")
            {
                Text = "Tutor Scheduler";
            }
            else
            {
                Text = "Tutor Scheduler - " + scheduleName;
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewScheduleForm().ShowDialog();

            // update schedule name in title
            string scheduleName = DatabaseManager.GetCurrentScheduleName();
            if (scheduleName == "")
            {
                Text = "Tutor Scheduler";
            }
            else
            {
                Text = "Tutor Scheduler - " + scheduleName;
            }
        }               
    }
}
