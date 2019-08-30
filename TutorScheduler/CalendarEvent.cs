using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    /// <summary>
    /// An event to display on the schedule calendar. 
    /// </summary>
    class CalendarEvent
    {        
        private int day;
        private Time startTime;
        private Time endTime;
        private Rectangle bounds;

        internal Time StartTime { get => startTime; set => startTime = value; }
        internal Time EndTime { get => endTime; set => endTime = value; }
        
        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public void SetBounds(Rectangle bounds)
        {
            this.bounds = bounds;
        }

        public CalendarEvent(Time startTime, Time endTime, int day)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.day = day;
        }               
    }
}
