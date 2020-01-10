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

        public int type { get; private set; }                    // the type of event (class or work)
        private int day { get; set; }
        private Rectangle bounds;

        internal bool BoundsSet = false;
        internal Color BackgroundColor { get; set; }
        internal Color TextColor;
        internal string PrimaryText;
        internal string SecondaryText;
        internal string EventName = "";                          // if class event, stores the class name; otherwise, just stores the type

        internal Time StartTime { get; set; }
        internal Time EndTime { get; set; }

        internal int EventID { get; set; } = -1;    
        internal int StudentID { get; set; }

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
        /// Called when the work event was clicked on the calendar view (only work events are editable)
        /// </summary>
        public void OnClick()
        {
            if (type == WORK)
            {
                new EditWorkEventForm(this).ShowDialog();
            }
            else
            {
                Console.WriteLine("Attempted to edit non-WORK type event.");
            }
        }

        public CalendarEvent(string eventName, Time startTime, Time endTime, int day, int type, string primaryText, int studentID, int baseColor)
        {
            if (startTime.minutes % 5 != 0 || endTime.minutes % 5 != 0)
            {
                new AlertDialog("All times must be a multiple of 5 minutes").ShowDialog();
            }            
            
            StartTime = startTime;
            EndTime = endTime;
            this.day = day;
            this.type = type;
            this.StudentID = studentID;
            PrimaryText = primaryText;

            this.EventName = eventName;

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

        public void UpdateEvent(int startHour, int startMinute, int endHour, int endMinute)
        {
            if (type == WORK)
            {
                StartTime = new Time(startHour, startMinute);
                EndTime = new Time(endHour, endMinute);
                DatabaseManager.UpdateEvent(this);
            }
            Console.WriteLine("ERROR: called CalendarEvent.UpdateEvent on non-WORK type event.");
        }

        public void RemoveEvent()
        {
            DatabaseManager.RemoveEvent(this);
        }

        #region Static Methods     

        /// <summary>
        /// Check if event 2 overlaps event 1 chronologically
        /// </summary>
        /// <param name="event1">The earlier event</param>
        /// <param name="event2">The later event</param>
        /// <returns>True if event2 overlaps event 1, otherwise false</returns>
        public static bool Overlap(CalendarEvent event1, CalendarEvent event2)
        {
            if (event2 < event1)
            {
                // swap event1 and event2 so event1 always starts before event2
                CalendarEvent t = event1;
                event1 = event2;
                event2 = t;
            }
            return event1.Day == event2.Day && event2.StartTime < event1.EndTime;
        }

        public static bool CoverageOverlap(CalendarEvent event1, CalendarEvent event2)
        {
            if (event2 < event1)
            {
                // swap event1 and event2 so event1 always starts before event2
                CalendarEvent t = event1;
                event1 = event2;
                event2 = t;
            }
            return event1.Day == event2.Day && event2.StartTime <= event1.EndTime;
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
