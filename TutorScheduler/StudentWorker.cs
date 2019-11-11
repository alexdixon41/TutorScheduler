using System;
using System.Collections.Generic;
using System.Text;

namespace TutorScheduler
{
    public class StudentWorker
    {
        public int StudentID { get; private set; }
        public string Name;
        public string JobPosition;
        public int DisplayColor;
        public bool Selected;
        private Schedule classSchedule;                           // the student's class schedule
        private Schedule workSchedule;
        private Schedule availability = new Schedule();           // the student's work availability schedule


        public StudentWorker(string name)
        {
            Name = name;
        }

        public StudentWorker(int id, string name)
        {
            StudentID = id;
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

        public List<Subject> GetSubjectsTutored()
        {
            List<Subject> subjects = DatabaseManager.GetStudentWorkersSubjects(StudentID);
            return subjects;
        }

        /// <summary>
        /// Add a subject to the list of subjects the student worker tutors
        /// </summary>
        /// <param name="subjectID">The ID of the subject to be added to the list</param>
        public void AddSubjectTutored(int subjectID)
        {
            DatabaseManager.AddSubjectTutored(subjectID, StudentID);
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


        public void fetchWorkSchedule()
        {
            workSchedule = DatabaseManager.GetSchedule(StudentID, CalendarEvent.WORK);
        }
        
        /// <summary>
        /// Deletes the student worker and all information belonging to them from the database
        /// </summary>
        public void removeStudentWorker()
        {
            //Remove the student worker, their schedules, and the subjects they tutor
            DatabaseManager.RemoveStudentWorker(StudentID);
            DatabaseManager.RemoveStudentWorkersSchedules(StudentID);
            DatabaseManager.RemoveStudentWorkersSubjects(StudentID);
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

        
        public static bool createStudentWorker(int studentID, string name, string position, int color)
        {
            StudentWorker newStudentWorker = new StudentWorker(studentID, name, position, color);
            //Call save function from DBMgr
            bool success = DatabaseManager.SaveStudentWorker(newStudentWorker);
            return success;
        }

        public static bool verifyID(string idString)
        {
            //ID must be 9 digits long
            if (idString.Length != 9)
            {
                new AlertDialog("Student ID must contain 9 numbers.").ShowDialog();
                return false;
            }
            //ID must only contain numbers
            try
            {
                Int32.Parse(idString);
                return true;
            }
            catch (Exception e)
            {
                new AlertDialog("Student ID can only contain numbers.").ShowDialog();
                return false;
            }
        }

        #endregion 
    }
}
