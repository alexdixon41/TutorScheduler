using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingAlgorithm
{
    /// <summary>
    /// A single meeting time of a class on one day of the week. All times must be multiples of 5 minutes.
    /// </summary>
    class Meeting
    {
        // day name constants       
        public const int MONDAY = 0;
        public const int TUESDAY = 1;
        public const int WEDNESDAY = 2;
        public const int THURSDAY = 3;
        public const int FRIDAY = 4;       

        // meeting type constants
        public const int CLASS = 0;
        public const int WORK = 1;
        public const int AVAILABILITY = 2;

        public Time startTime;
        public Time endTime;
        public int day;
        public int type;                    // the type of meeting (class or work)

        public static bool operator <(Meeting m1, Meeting m2)
        {
            return m1.startTime < m2.startTime;
        }

        public static bool operator >(Meeting m1, Meeting m2)
        {
            return m1.startTime > m2.startTime;
        }

        /// <summary>
        /// Construct a ClassMeeting for a single meeting time of a class
        /// </summary>
        /// <param name="startTime">The start time of the class</param>
        /// <param name="endTime">The end time of the class</param>
        /// <param name="days">The day of the week the class meeting occurs on specified by one of the day name int constants</param>
        public Meeting(Time startTime, Time endTime, int day, int meetingType)
        {
            if (startTime.minutes % 5 != 0 || endTime.minutes % 5 != 0)
            {
                throw new Exception("All times must be a multiple of 5 minutes");
            }

            this.startTime = startTime;
            this.endTime = endTime;
            this.day = day;
            this.type = meetingType;
        }
    }
}
