using System;
using System.Collections.Generic;
using System.Text;

namespace TutorScheduler
{
    class StudentWorker
    {
        public ClassSchedule classSchedule;                 // the student's class schedule
        public AvailabilitySchedule availability = new AvailabilitySchedule();           // the student's work availability schedule

        /// <summary>
        /// Build the schedule of available work times for the student from their class schedule, if it is set.
        /// </summary>
        public void BuildAvailabilitySchedule()
        {
            if (classSchedule == null)
            {
                return;
            }

            // store class meetings lists for each weekday in an array
            List<Meeting>[] dayClassLists = new List<Meeting>[]
            {
                classSchedule.mondayClassMeetings,
                classSchedule.tuesdayClassMeetings,
                classSchedule.wednesdayClassMeetings,
                classSchedule.thursdayClassMeetings,
                classSchedule.fridayClassMeetings
            };

            int day = 0;
            foreach (List<Meeting> dayClasses in dayClassLists)
            {
                for (int i = 0; i < dayClasses.Count; i++)
                {
                    if (i == 0)
                    {                        
                        // check if at least 1.75 hours between opening time and start of first class
                        if (dayClasses[i].startTime.SubtractTime(WorkLocation.openingTimes[day]) >= new Time(1, 45))
                        {
                            Time availableStart = WorkLocation.openingTimes[day];
                            Time availableStop = ClassSchedule.GetPrecedingStopTime(dayClasses[i].startTime);
                            availability.AddAvailableTime(new Meeting(availableStart, availableStop, day, Meeting.AVAILABILITY));
                        }
                    }
                    else            // attempt to schedule availability between classes
                    {                        
                        // check if at least 2 hours between end of previous class and start of this class
                        if (dayClasses[i].startTime.SubtractTime(dayClasses[i-1].endTime) >= new Time(2, 0))
                        {
                            Time availableStart = ClassSchedule.GetSucceedingStartTime(dayClasses[i - 1].endTime);
                            Time availableStop = ClassSchedule.GetPrecedingStopTime(dayClasses[i].startTime);
                            availability.AddAvailableTime(new Meeting(availableStart, availableStop, day, Meeting.AVAILABILITY));
                        }
                    }

                    if (i == dayClasses.Count - 1)         // attempt to schedule availability between latest class and closing time
                    {                        
                        // check if at least 1.75 hours between end of this class and closing time
                        if (WorkLocation.closingTimes[day].SubtractTime(dayClasses[i].endTime) >= new Time(1, 45))
                        {
                            Time availableStart = ClassSchedule.GetSucceedingStartTime(dayClasses[i].endTime);
                            Time availableStop = WorkLocation.closingTimes[day];
                            availability.AddAvailableTime(new Meeting(availableStart, availableStop, day, Meeting.AVAILABILITY));
                        }
                    }
                    
                }
                day++;
            }
        }
    }
}
