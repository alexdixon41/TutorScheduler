using System;
using System.Collections.Generic;
using System.Text;

namespace TutorScheduler
{
    /// <summary>
    /// A weekly schedule of available work times organized by lists of Meetings for each weekday
    /// </summary>
    class AvailabilitySchedule
    {
        // list of meetings to represent available times 
        public List<CalendarEvent> availableTimes = new List<CalendarEvent>();

        // add an availability meeting time to the schedule
        public void AddAvailableTime(CalendarEvent newMeeting)
        {
            availableTimes.Add(newMeeting);
        }
    }
}
