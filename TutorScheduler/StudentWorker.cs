using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public IndividualSchedule ClassSchedule { get; set; }                           // the student's class schedule
        public IndividualSchedule WorkSchedule { get; set; }
        public IndividualSchedule Availability { get; set; } = new IndividualSchedule();           // the student's work availability schedule

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

        public bool Equals(StudentWorker other)
        {
            return other != null && StudentID == other.StudentID;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StudentWorker);
        }

        public override int GetHashCode()
        {
            return StudentID;
        }        

        public IndividualSchedule GetAvailabilitySchedule()
        {
            return Availability;
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
            Availability.Clear();

            if (ClassSchedule == null)
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

            foreach (CalendarEvent classMeeting in ClassSchedule.Events)
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
                    Availability.AddEvent(new CalendarEvent("Availability", availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name, DisplayColor));
                }
                for (int i = 0; i < dayClasses.Count; i++)
                {                   
                    if (i == 0)
                    {
                        // check if at least 1.75 hours between opening time and start of first class
                        if (dayClasses[i].StartTime - WorkLocation.openingTimes[(int)day] >= new Time(1, 45))
                        {
                            Time availableStart = WorkLocation.openingTimes[(int)day];
                            Time availableStop = IndividualSchedule.GetPrecedingStopTime(dayClasses[i].StartTime);
                            Availability.AddEvent(new CalendarEvent("Availability", availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name, DisplayColor));
                        }
                    }
                    else            // attempt to schedule availability between classes
                    {
                        // check if at least 2 hours between end of previous class and start of this class
                        if (dayClasses[i].StartTime.SubtractTime(dayClasses[i - 1].EndTime) >= new Time(2, 0))
                        {
                            Time availableStart = IndividualSchedule.GetSucceedingStartTime(dayClasses[i - 1].EndTime);
                            Time availableStop = IndividualSchedule.GetPrecedingStopTime(dayClasses[i].StartTime);

                            // check that available stop time is before closing time; if not, set available stop time to the closing time
                            if (availableStop > WorkLocation.closingTimes[day])
                            {
                                availableStop = WorkLocation.closingTimes[day];

                                // if available time was set to the closing time, make sure the shift is still at least 1.5 hours long
                                if (availableStop.SubtractTime(availableStart) >= new Time(1, 30))
                                {
                                    Availability.AddEvent(new CalendarEvent("Availability", availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name, DisplayColor));
                                }
                            }
                            else
                            {
                                Availability.AddEvent(new CalendarEvent("Availability", availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name, DisplayColor));
                            }
                        }
                    }

                    if (i == dayClasses.Count - 1)         // attempt to schedule availability between latest class and closing time
                    {
                        // check if at least 1.75 hours between end of this class and closing time
                        if (WorkLocation.closingTimes[day].SubtractTime(dayClasses[i].EndTime) >= new Time(1, 45))
                        {
                            Time availableStart = IndividualSchedule.GetSucceedingStartTime(dayClasses[i].EndTime);
                            Time availableStop = WorkLocation.closingTimes[day];
                            Availability.AddEvent(new CalendarEvent("Availability", availableStart, availableStop, day, CalendarEvent.AVAILABILITY, Name, DisplayColor));
                        }
                    }
                }
                day++;
            }
        }

        /// <summary>
        /// Retrieve the student worker's class schedule from the database
        /// </summary>
        public void FetchClassSchedule()
        {
            ClassSchedule = DatabaseManager.GetSchedule(StudentID, CalendarEvent.CLASS);
        }

        /// <summary>
        /// Retrieve the student worker's work schedule from the database
        /// </summary>
        public void FetchWorkSchedule()
        {
            WorkSchedule = DatabaseManager.GetSchedule(StudentID, CalendarEvent.WORK);
        }
        
        /// <summary>
        /// Deletes the student worker and all information belonging to them from the database
        /// </summary>
        public void RemoveStudentWorker()
        {
            //Remove the student worker, their schedules, and the subjects they tutor
            DatabaseManager.RemoveStudentWorker(StudentID);
            DatabaseManager.RemoveStudentWorkersSchedules(StudentID);            
        }

        public void RemoveSubjectTutored(int subjectID)
        {
            DatabaseManager.RemoveSubjectTutored(subjectID);
        }

        public void UpdateInformation(string newName, string newPosition, int newColor)
        {
            Name = newName;
            JobPosition = newPosition;
            DisplayColor = newColor;
            DatabaseManager.UpdateStudentInfo(StudentID, Name, JobPosition, DisplayColor);
        }


        #region Static Methods and Fields

        // TODO - use this field instead of calling GetStudentWorkers everytime we need the list; this only needs to be updated on launch
        //        and if we need to reset all student workers for some reason
        // the global list of all student worker objects - every access to all student workers should be through this field
        public static List<StudentWorker> allStudentWorkers = GetStudentWorkers();

        public static List<StudentWorker> GetStudentWorkers()
        {
            // the selected worker IDs from application settings
            StringCollection selectedWorkers = Properties.Settings.Default.SelectedWorkers;
            
            List<StudentWorker> studentWorkers = DatabaseManager.GetStudentWorkers();            
            foreach (StudentWorker sw in studentWorkers)
            {
                // set the class and work schedule of the student worker
                sw.ClassSchedule = DatabaseManager.GetSchedule(sw.StudentID, CalendarEvent.CLASS);
                sw.WorkSchedule = DatabaseManager.GetSchedule(sw.StudentID, CalendarEvent.WORK);
                sw.BuildAvailabilitySchedule();

                // set selected student workers as selected
                if (selectedWorkers.Contains(sw.StudentID.ToString()))
                {
                    sw.Selected = true;
                }
            }                       

            return studentWorkers;
        }
        
        public static bool CreateStudentWorker(int studentID, string name, string position, int color)
        {
            StudentWorker newStudentWorker = new StudentWorker(studentID, name, position, color);
            newStudentWorker.Selected = true;               // display the new student worker by default
            //Call save function from DBMgr
            bool success = DatabaseManager.SaveStudentWorker(newStudentWorker);

            if (success)
            {
                // go ahead and add student worker so the database does not need to be queried for all student workers immediately
                allStudentWorkers.Add(newStudentWorker);
            }
            return success;
        }

        public static bool VerifyID(string idString)
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
            catch
            {
                new AlertDialog("Student ID can only contain numbers.").ShowDialog();
                return false;
            }
        }

        #endregion 
    }
}
