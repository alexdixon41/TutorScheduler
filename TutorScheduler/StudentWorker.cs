using System;
using System.Collections.Generic;
using System.Text;

namespace TutorScheduler
{
    class StudentWorker
    {
        private int StudentID;
        public string Name;
        public string JobPosition;
        public int DisplayColor;        
        private Schedule classSchedule;                           // the student's class schedule
        private Schedule workSchedule;
        private Schedule availability = new Schedule();           // the student's work availability schedule

        public StudentWorker(string name)
        {
            Name = name;
        }

        public StudentWorker(int id, string name, string jobPosition, int displayColor)
        {
            StudentID = id;
            Name = name;
            JobPosition = jobPosition;
            DisplayColor = displayColor;
        }

        public void SetClassSchedule(Schedule schedule)
        {
            classSchedule = schedule;
        }

        public Schedule GetClassSchedule()
        {
            return classSchedule;
        }

        public void SetWorkSchedule(Schedule schedule)
        {
            workSchedule = schedule;
        }

        public Schedule GetWorkSchedule()
        {
            return workSchedule;
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
            availability.Clear();

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

            foreach (CalendarEvent classMeeting in classSchedule.Events)
            {
                dailyEvents[(int)classMeeting.Day].Add(classMeeting);
            }

            int day = 0;

            foreach (List<CalendarEvent> dayClasses in dailyEvents)
            {
                // if no classes for the day, available hours equal open hours
                if (dayClasses.Count == 0)
                {
                    Time availableStart = WorkLocation.openingTimes[(int)day];
                    Time availableStop = WorkLocation.closingTimes[(int)day];
                    availability.AddEvent(new CalendarEvent(availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name, DisplayColor));
                }
                for (int i = 0; i < dayClasses.Count; i++)
                {                   
                    if (i == 0)
                    {
                        // check if at least 1.75 hours between opening time and start of first class
                        if (dayClasses[i].StartTime - WorkLocation.openingTimes[(int)day] >= new Time(1, 45))
                        {
                            Time availableStart = WorkLocation.openingTimes[(int)day];
                            Time availableStop = Schedule.GetPrecedingStopTime(dayClasses[i].StartTime);
                            availability.AddEvent(new CalendarEvent(availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name, DisplayColor));
                        }
                    }
                    else            // attempt to schedule availability between classes
                    {
                        // check if at least 2 hours between end of previous class and start of this class
                        if (dayClasses[i].StartTime.SubtractTime(dayClasses[i - 1].EndTime) >= new Time(2, 0))
                        {
                            Time availableStart = Schedule.GetSucceedingStartTime(dayClasses[i - 1].EndTime);
                            Time availableStop = Schedule.GetPrecedingStopTime(dayClasses[i].StartTime);
                            availability.AddEvent(new CalendarEvent(availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name, DisplayColor));
                        }
                    }

                    if (i == dayClasses.Count - 1)         // attempt to schedule availability between latest class and closing time
                    {
                        // check if at least 1.75 hours between end of this class and closing time
                        if (WorkLocation.closingTimes[day].SubtractTime(dayClasses[i].EndTime) >= new Time(1, 45))
                        {
                            Time availableStart = Schedule.GetSucceedingStartTime(dayClasses[i].EndTime);
                            Time availableStop = WorkLocation.closingTimes[day];
                            availability.AddEvent(new CalendarEvent(availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name, DisplayColor));
                        }
                    }
                }
                day++;
            }
        }

        
        #region StaticMethods
        public static List<StudentWorker> GetStudentWorkers()
        {
            // TODO database query on separate thread
            List<StudentWorker> studentWorkers = DatabaseManager.GetStudentWorkers();            
            foreach (StudentWorker sw in studentWorkers)
            {
                // set the class and work schedule of the student worker
                sw.SetClassSchedule(DatabaseManager.GetSchedule(sw.StudentID, CalendarEvent.CLASS));
                sw.SetWorkSchedule(DatabaseManager.GetSchedule(sw.StudentID, CalendarEvent.WORK));
            }

            return studentWorkers;
        }

        #endregion 
    }
}
