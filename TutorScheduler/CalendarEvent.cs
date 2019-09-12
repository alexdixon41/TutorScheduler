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

        private int type;                    // the type of event (class or work)
        private int day;
        private Rectangle bounds;

        internal Time StartTime { get; set; }
        internal Time EndTime { get; set; }
        internal Color Color { get; set; }

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
            if ((type == CLASS && Color.A == 255) || (type == WORK && Color.A == 200))
            {
                Color = Color.FromArgb(Color.A - 90, Color.R, Color.G, Color.B);
            }
        }

        public CalendarEvent(Time startTime, Time endTime, int day, int type)
        {
            if (startTime.minutes % 5 != 0 || endTime.minutes % 5 != 0)
            {
                throw new Exception("All times must be a multiple of 5 minutes");
            }

            this.StartTime = startTime;
            this.EndTime = endTime;
            this.day = day;
            this.type = type;
            
            switch (type)
            {
                case CLASS:
                    Color = Color.Red;
                    break;
                case WORK:
                    Color = Color.FromArgb(200, 255, 0, 0);
                    break;
                case AVAILABILITY:
                    Color = Color.FromArgb(120, 255, 0, 0);
                    break;
                default:
                    Color = Color.Black;
                    break;
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
