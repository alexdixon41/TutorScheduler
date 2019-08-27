using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingAlgorithm
{
    /// <summary>
    /// A weekly schedule of available work times organized by lists of Meetings for each weekday
    /// </summary>
    class AvailabilitySchedule
    {
        // list of meetings to represent available times for each weekday
        public List<Meeting> mondayAvailableTime = new List<Meeting>();
        public List<Meeting> tuesdayAvailableTime = new List<Meeting>();
        public List<Meeting> wednesdayAvailableTime = new List<Meeting>();
        public List<Meeting> thursdayAvailableTime = new List<Meeting>();
        public List<Meeting> fridayAvailableTime = new List<Meeting>();

        // add an availability meeting time to the schedule
        public void AddAvailableTime(Meeting newMeeting)
        {           
            switch (newMeeting.day)
            {
                case Meeting.MONDAY:
                    mondayAvailableTime.Add(newMeeting);
                    break;
                case Meeting.TUESDAY:
                    tuesdayAvailableTime.Add(newMeeting);
                    break;
                case Meeting.WEDNESDAY:
                    wednesdayAvailableTime.Add(newMeeting);
                    break;
                case Meeting.THURSDAY:
                    thursdayAvailableTime.Add(newMeeting);
                    break;
                case Meeting.FRIDAY:
                    fridayAvailableTime.Add(newMeeting);
                    break;
                default:
                    break;
            }            
        }
    }
}
