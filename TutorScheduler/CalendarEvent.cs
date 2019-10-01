using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    enum Day : int
    {
        Monday = 0, Tuesday, Wednesday, Thursday, Friday
    };    

    /// <summary>
    /// An event to display on the schedule calendar. 
    /// </summary>
    class CalendarEvent
    {
        public const int CLASS = 0;
        public const int WORK = 1;
        public const int AVAILABILITY = 2;

        private readonly int type;                    // the type of event (class or work)
        private int day;
        private Rectangle bounds;

        internal Color BackgroundColor { get; set; }
        internal Color TextColor;
        internal string PrimaryText;
        internal string SecondaryText;

        internal Time StartTime { get; set; }
        internal Time EndTime { get; set; }
       

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public void SetBounds(Rectangle bounds)
        {
            this.bounds = bounds;
        }

        public Rectangle GetBounds()
        {
            return bounds;
        }

        /// <summary>
        /// Called when the event was clicked on the calendar view
        /// </summary>
        public void OnClick()
        {
            if ((type == CLASS && BackgroundColor.A == 255) || (type == WORK && BackgroundColor.A == 200))
            {
                BackgroundColor = Color.FromArgb(BackgroundColor.A - 90, BackgroundColor.R, BackgroundColor.G, BackgroundColor.B);
            }
        }

        public CalendarEvent(Time startTime, Time endTime, int day, int type, string primaryText)
        {
            if (startTime.minutes % 5 != 0 || endTime.minutes % 5 != 0)
            {
                throw new Exception("All times must be a multiple of 5 minutes");
            }

            StartTime = startTime;
            EndTime = endTime;
            this.day = day;
            this.type = type;
            PrimaryText = primaryText;
            
            // set background color and text
            switch (type)
            {
                case CLASS:
                    BackgroundColor = Color.Red;
                    SecondaryText = "Class";
                    break;
                case WORK:
                    BackgroundColor = Color.FromArgb(200, 255, 0, 0);
                    SecondaryText = "Work";
                    break;
                case AVAILABILITY:
                    BackgroundColor = Color.FromArgb(120, 255, 0, 0);
                    SecondaryText = "Availability";
                    break;
                default:
                    throw new Exception("Invalid CalendarEvent type");
            }

            // set text color based on background color
            if (BackgroundColor.R * 0.299 + BackgroundColor.G * 0.587 + BackgroundColor.B * 0.114 > 150)
            {
                TextColor = Color.Black;               
            }
            else
            {
                TextColor = Color.White;
            }
        }

        public static bool operator <(CalendarEvent m1, CalendarEvent m2)
        {
            return m1.Day < m2.Day || (m1.Day == m2.Day && m1.StartTime < m2.StartTime);
        }

        public static bool operator >(CalendarEvent m1, CalendarEvent m2)
        {
            return m1.Day > m2.Day || (m1.Day == m2.Day && m1.StartTime > m2.StartTime);
        }
    }
}
