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
    public class CalendarEvent
    {
        public const int CLASS = 0;
        public const int WORK = 1;
        public const int AVAILABILITY = 2;

        private readonly int type;                    // the type of event (class or work)
        private int day;
        private Rectangle bounds;

        internal bool BoundsSet = false;
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
            BoundsSet = true;
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

        public CalendarEvent(Time startTime, Time endTime, int day, int type, string primaryText, int baseColor)
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

            // convert baseColor to RGB values
            int red = baseColor / 256 / 256;
            int green = baseColor % (256 * 256) / 256;
            int blue = baseColor % 256;            

            // set background color and text
            switch (type)
            {
                case CLASS:
                    BackgroundColor = Color.FromArgb(255, red, green, blue);
                    SecondaryText = "Class";
                    break;
                case WORK:                    
                    BackgroundColor = Color.FromArgb(200, red, green, blue);
                    SecondaryText = "Work";
                    break;
                case AVAILABILITY:
                    BackgroundColor = Color.FromArgb(120, red, green, blue);
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

        #region Static Methods

        public static bool Overlap(List<CalendarEvent> overlappingEvents, CalendarEvent e) {
            bool result = false;
            foreach (CalendarEvent overlappingEvent in overlappingEvents)
            {
                if (Overlap(overlappingEvent, e))
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool Overlap(CalendarEvent event1, CalendarEvent event2)
        {
            if (event2 < event1)
            {
                CalendarEvent t = event1;
                event1 = event2;
                event2 = t;
            }
            return event1.Day == event2.Day && event2.StartTime < event1.EndTime;
        }

        public static bool operator <(CalendarEvent m1, CalendarEvent m2)
        {
            return m1.Day < m2.Day || (m1.Day == m2.Day && m1.StartTime < m2.StartTime);
        }

        public static bool operator >(CalendarEvent m1, CalendarEvent m2)
        {
            return m1.Day > m2.Day || (m1.Day == m2.Day && m1.StartTime > m2.StartTime);
        }

        #endregion
    }
}
