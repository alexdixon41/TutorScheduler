using System;
using System.Collections.Generic;
using System.Text;

namespace TutorScheduler
{
    /// <summary>
    /// Simple time representation for 24-hour times
    /// </summary>
    class Time
    {
        public int hours;
        public int minutes;

        /// <summary>
        /// Create time from hours and minutes as integers
        /// </summary>
        /// <param name="hours">Hours as an integer from 1 - 24</param>
        /// <param name="minutes">Minutes as an integer from 0 - 59</param>
        public Time(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }   

        public static bool operator <(Time t1, Time t2)
        {
            return t1.hours < t2.hours || (t1.hours == t2.hours && t1.minutes < t2.minutes);
        }

        public static bool operator >(Time t1, Time t2)
        {
            return t1.hours > t2.hours || (t1.hours == t2.hours && t1.minutes > t2.minutes);
        }

        public static bool operator ==(Time t1, Time t2)
        {
            return t1.hours == t2.hours && t1.minutes == t2.minutes;
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return t1.hours != t2.hours || t1.minutes != t2.minutes;
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return t1 < t2 || t1 == t2;
        }

        public static bool operator >= (Time t1, Time t2)
        {
            return t1 > t2 || t1 == t2;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compute the time difference between the specified time and this time.
        /// </summary>
        /// <param name="timeToSubtract">The time for which to find the difference between this time</param>        
        /// <returns>The difference of the two times</returns>
        public Time SubtractTime(Time timeToSubtract)
        {
            Time laterTime;
            Time earlierTime;
            if (this < timeToSubtract)
            {
                laterTime = timeToSubtract;
                earlierTime = this;
            }
            else
            {
                laterTime = this;
                earlierTime = timeToSubtract;
            }
            int borrowedHours = 0;           // set to 1 if an additional hour should be subtracted due to a borrow
            int newMinutes = laterTime.minutes - earlierTime.minutes;
            if (newMinutes < 0)
            {
                borrowedHours = 1;
                newMinutes += 60;
            }

            int newHours = laterTime.hours - earlierTime.hours - borrowedHours;           

            return new Time(newHours, newMinutes);
        }

        /// <summary>
        /// Add the specified amount of time to the time represented by this object.
        /// </summary>
        /// <param name="intervalToAdd">Time object representing the amount of hours and minutes to add to this time</param>
        /// <returns>The sum of the two times</returns>
        public Time AddTime(Time intervalToAdd)
        {
            int carryHours = 0;             // set to 1 if an additional hour should be added due to a carry
            int newMinutes = this.minutes + intervalToAdd.minutes;
            if (newMinutes >= 60)
            {
                carryHours = 1;
                newMinutes -= 60;
            }

            int newHours = this.hours + intervalToAdd.hours + carryHours;
            if (newHours > 24)
            {
                throw new Exception("Resulting time should not exceed 24 hours");
            }

            return new Time(newHours, newMinutes);
        }        
    }
}
