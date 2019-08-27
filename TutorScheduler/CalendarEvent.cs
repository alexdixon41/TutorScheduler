using System;
using System.Collections.Generic;
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
        internal Time StartTime { get => StartTime; set => StartTime = value; }
        internal Time EndTime { get => EndTime; set => StartTime = value; }

        public CalendarEvent(Time startTime, Time endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }               
    }
}
