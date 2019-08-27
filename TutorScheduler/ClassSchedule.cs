using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingAlgorithm
{
    /// <summary>
    /// A weekly schedule of class meeting times organized by lists of Meetings for each day of the week.
    /// </summary>
    class ClassSchedule
    {
        // lists of class meetings for each weekday, ordered by start time ascending
        public List<Meeting> mondayClassMeetings = new List<Meeting>();         
        public List<Meeting> tuesdayClassMeetings = new List<Meeting>();
        public List<Meeting> wednesdayClassMeetings = new List<Meeting>();
        public List<Meeting> thursdayClassMeetings = new List<Meeting>();
        public List<Meeting> fridayClassMeetings = new List<Meeting>();

        /// <summary>
        /// Add a class meeting to the schedule, maintaining the start time ordering for the appropriate weekday meeting list.
        /// </summary>
        /// <param name="newClass">The new class meeting to add to the schedule</param>
        public void AddClassMeeting(Meeting newClass)
        {
            List<Meeting> dayMeetings;          // which meeting list to add the class meeting to

            // set the correct list by day of the week
            switch (newClass.day)
            {
                case Meeting.MONDAY:
                    dayMeetings = mondayClassMeetings;
                    break;
                case Meeting.TUESDAY:
                    dayMeetings = tuesdayClassMeetings;
                    break;
                case Meeting.WEDNESDAY:
                    dayMeetings = wednesdayClassMeetings;
                    break;
                case Meeting.THURSDAY:
                    dayMeetings = thursdayClassMeetings;
                    break;
                case Meeting.FRIDAY:
                    dayMeetings = fridayClassMeetings;
                    break;
                default:
                    return;
            }

            // add the new class meeting to the schedule at the correct index to maintain the sequential ordering by start time
            if (dayMeetings.Count == 0)
            {
                dayMeetings.Add(newClass);
            }
            else
            {
                int index = dayMeetings.Count - 1;                
                while (newClass < dayMeetings[index] && index >= 0)
                {
                    index--;
                }               
                dayMeetings.Insert(index + 1, newClass);
            }
        }

        /// <summary>
        /// Add an array of meetings to the schedule by iteratively calling the AddClassMeeting function.
        /// </summary>
        /// <param name="newClasses">Array of meetings to add to the class schedule</param>
        public void AddClassMeetings(Meeting[] newClasses)
        {
            foreach (Meeting classMeeting in newClasses)
            {
                AddClassMeeting(classMeeting);
            }
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

        //public int SumAvailableHours()
        //{
            
        //}
    }
}
