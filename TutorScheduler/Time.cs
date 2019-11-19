using System;
using System.Collections.Generic;
using System.Text;

namespace TutorScheduler
{
    /// <summary>
    /// Simple time representation for 24-hour times
    /// </summary>
    public class Time
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

        public override string ToString()
        {
            string timeStr = "";
            string amOrPM = " a.m.";
            if (hours >= 12)
            {
                amOrPM = " p.m.";
            }
            if (hours > 12)
            {
                timeStr += hours % 12 + ":";
            }
            else
            {
                timeStr += hours + ":";
            }
            if (minutes < 10)
            {
                timeStr += "0";
            }
            return timeStr + minutes + amOrPM;
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

        public static bool operator >=(Time t1, Time t2)
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

        public static Time operator -(Time t1, Time t2)
        {
            Time laterTime;
            Time earlierTime;
            if (t1 < t2)
            {
                laterTime = t2;
                earlierTime = t1;
            }
            else
            {
                laterTime = t1;
                earlierTime = t2;
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

        public static Time operator +(Time t1, Time t2)
        {
            int carryHours = 0;             // set to 1 if an additional hour should be added due to a carry
            int newMinutes = t1.minutes + t2.minutes;
            if (newMinutes >= 60)
            {
                carryHours = 1;
                newMinutes -= 60;
            }

            int newHours = t1.hours + t2.hours + carryHours;
            if (newHours > 24)
            {
                throw new Exception("Resulting time should not exceed 24 hours");
            }

            return new Time(newHours, newMinutes);
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
        
        /// <summary>
        /// Returns the smaller (earliest) time
        /// </summary>
        /// <param name="t1">One of the times you want to compare</param>
        /// <param name="t2">The other time you want to compare</param>
        /// <returns></returns>
        public static Time Min(Time t1, Time t2)
        {
            if (t1 < t2)
                return t1;
            return t2;
        }

        /// <summary>
        /// Returns the larger (latest) time
        /// </summary>
        /// <param name="t1">One of the times you want to compare</param>
        /// <param name="t2">The other time you want to compare</param>
        /// <returns></returns>
        public static Time Max(Time t1, Time t2)
        {
            if (t1 > t2)
                return t1;
            return t2;
        }
    }
}
