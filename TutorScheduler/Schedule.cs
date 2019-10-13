using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    class Schedule
    {        
        public List<CalendarEvent> events = new List<CalendarEvent>();          // list of events on the schedule       

        /// <summary>
        /// Add an event to the schedule, maintaining sequential ordering of events by start time and day
        /// </summary>
        /// <param name="newEvent">The CalendarEvent to add to the schedule</param>
        public void AddEvent(CalendarEvent newEvent)
        {
            // add events to the schedule in the correct location to maintain sequential order by start time and day
            if (events.Count == 0)
            {
                events.Add(newEvent);
            }
            else
            {
                int index = events.Count - 1;
                while (newEvent < events[index])                // CalendarEvent operator overload (<)
                {
                    index--;
                }
                events.Insert(index + 1, newEvent);
            }
        }

        /// <summary>
        /// Add an array of events to the schedule by iteratively calling AddEvent
        /// </summary>
        /// <param name="newEvents">Array of events to add to the schedule</param>
        public void AddEvents(CalendarEvent[] newEvents)
        {
            foreach (CalendarEvent cEvent in newEvents)
            {
                AddEvent(cEvent);
            }
        }

        /// <summary>
        /// Set the list of events on the schedule, overwriting previous events if any
        /// </summary>
        /// <param name="allEvents">The list of events on the schedule</param>
        public void SetEvents(List<CalendarEvent> allEvents)
        {
            events = allEvents;
        }

        /// <summary>
        /// Get the latest time ending in a multiple of 15 that a worker can stop work before a scheduled class.
        /// Must be at least 15 minutes before the scheduled class. 
        /// </summary>
        /// <returns>A Time object representing the computed stop work time</returns>
        public static Time GetPrecedingStopTime(Time scheduledClassStartTime)
        {
            Time newTime = scheduledClassStartTime.SubtractTime(new Time(0, 15));
            if (newTime.minutes % 15 == 0)
            {
                return newTime;
            }
            if (newTime.minutes % 15 == 5)
            {
                return newTime.SubtractTime(new Time(0, 5));            // if minutes are a multiple of 10 but not a multiple of 15, subtract 5 minutes
            }
            return newTime.SubtractTime(new Time(0, 10));       // if minutes are not a multiple of 15 or 10, subtract 10 minutes
        }

        /// <summary>
        /// Get the earliest time ending in a multiple of 15 that a worker can start work after a scheduled class.
        /// Must be at least 15 minutes after the scheduled class.
        /// </summary>
        /// <returns>A Time object representing the computed start work time</returns>
        public static Time GetSucceedingStartTime(Time scheduledClassEndTime)
        {
            Time newTime = scheduledClassEndTime.AddTime(new Time(0, 15));
            if (newTime.minutes % 15 == 0)
            {
                return newTime;
            }
            if (newTime.minutes % 15 == 5)
            {
                return newTime.AddTime(new Time(0, 10));            // if minutes are a multiple of 10 but not 15, add 10 minutes
            }
            return newTime.AddTime(new Time(0, 5));                 // if minutes are not a multiple of 15 or 10, add 5 minutes
        }

    }
}
