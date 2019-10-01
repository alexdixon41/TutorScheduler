using System;
using System.Collections.Generic;
using System.Text;

namespace TutorScheduler
{
    class StudentWorker
    {
        public string Name;
        private Schedule classSchedule;                 // the student's class schedule
        private Schedule availability = new Schedule(CalendarEvent.AVAILABILITY);           // the student's work availability schedule

        public StudentWorker(string name)
        {
            Name = name;
        }

        public void SetClassSchedule(Schedule schedule)
        {
            this.classSchedule = schedule;
        }

        public Schedule GetClassSchedule()
        {
            return classSchedule;
        }

        public Schedule GetAvailabilitySchedule()
        {
            return availability;
        }

        /// <summary>
        /// Build the schedule of available work times for the student from their class schedule, if it is set.
        /// </summary>
        public void BuildAvailabilitySchedule()
        {
            if (classSchedule == null)
            {
                return;
            }

            List<CalendarEvent>[] dailyEvents = new List<CalendarEvent>[]
            {
                new List<CalendarEvent>(),
                new List<CalendarEvent>(),
                new List<CalendarEvent>(),
                new List<CalendarEvent>(),
                new List<CalendarEvent>()
            };

            foreach (CalendarEvent classMeeting in classSchedule.events)
            {
                dailyEvents[(int)classMeeting.Day].Add(classMeeting);
            }

            int day = 0;

            foreach (List<CalendarEvent> dayClasses in dailyEvents)
            {
                for (int i = 0; i < dayClasses.Count; i++)
                {
                    // TODO schedule available time for each day of the week - before all classes, between classes, and after all classes

                    if (i == 0)
                    {
                        // check if at least 1.75 hours between opening time and start of first class
                        if (dayClasses[i].StartTime - WorkLocation.openingTimes[(int)day] >= new Time(1, 45))
                        {
                            Time availableStart = WorkLocation.openingTimes[(int)day];
                            Time availableStop = Schedule.GetPrecedingStopTime(dayClasses[i].StartTime);
                            availability.AddEvent(new CalendarEvent(availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name));
                        }
                    }
                    else            // attempt to schedule availability between classes
                    {
                        // check if at least 2 hours between end of previous class and start of this class
                        if (dayClasses[i].StartTime.SubtractTime(dayClasses[i - 1].EndTime) >= new Time(2, 0))
                        {
                            Time availableStart = Schedule.GetSucceedingStartTime(dayClasses[i - 1].EndTime);
                            Time availableStop = Schedule.GetPrecedingStopTime(dayClasses[i].StartTime);
                            availability.AddEvent(new CalendarEvent(availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name));
                        }
                    }

                    if (i == dayClasses.Count - 1)         // attempt to schedule availability between latest class and closing time
                    {
                        // check if at least 1.75 hours between end of this class and closing time
                        if (WorkLocation.closingTimes[day].SubtractTime(dayClasses[i].EndTime) >= new Time(1, 45))
                        {
                            Time availableStart = Schedule.GetSucceedingStartTime(dayClasses[i].EndTime);
                            Time availableStop = WorkLocation.closingTimes[day];
                            availability.AddEvent(new CalendarEvent(availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name));
                        }
                    }
                }
                day++;
            }
        }
    }
}
