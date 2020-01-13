using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    class DatabaseManager
    {
        private static string connectionString = "server=localhost;user=root;database=tutorscheduler;port=3306;SSLMode=none";
        private static MySqlConnection conn = new MySqlConnection(connectionString);

        public static bool Login(string username, string pword)
        {
            bool success = false;
            try
            {
                Console.Write("Connecting to MySql...");
                conn.Open();
                string sql = @"SELECT pword FROM Manager WHERE username = @username;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader reader = cmd.ExecuteReader(); 
                
                string hash = null;
                if (reader.Read())
                {
                    hash = reader["pword"].ToString();
                }

                reader.Dispose();

                sql = @"SELECT PASSWORD(@pword) as 'entered';";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pword", pword);
                reader = cmd.ExecuteReader();                
                if (reader.Read())
                {
                    if (hash == reader["entered"].ToString())
                    {
                        success = true;
                    }
                }
                cmd.Dispose();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return success;
        }

        public static void AddSubjectTutored(int subjectID, int studentID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"INSERT INTO subjecttutored (studentID, subjectID) values (@studentID, @subjectID);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.Parameters.AddWithValue("subjectID", subjectID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }            

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }       

        /// <summary>
        /// Load the class or work schedule from the database for the specified student worker.
        /// </summary>
        /// <param name="studentID">The studentID of the student worker whose schedule will be loaded</param>
        /// <returns>Schedule of class or work events for the specified student worker</returns>
        public static IndividualSchedule GetSchedule(int studentID, int scheduleType)
        {
            DataTable table = new DataTable();

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT eventID, eventType, startHour, startMinute, endHour, endMinute, 
                            day, Details, eventName, studentName, sw.studentID, displayColor
                            FROM studentworker sw JOIN scheduleevent e ON e.studentID = sw.studentID JOIN EventDetails d ON e.Details = d.EventDetailsID
                            WHERE sw.studentID = @id AND e.eventType = @scheduleType 
                                AND e.ScheduleID = (SELECT (ScheduleID) FROM CurrentSchedule);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", studentID);
                cmd.Parameters.AddWithValue("@scheduleType", scheduleType);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(table);                
                cmd.Dispose();
                myAdapter.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            IndividualSchedule newSchedule = new IndividualSchedule();

            foreach (DataRow row in table.Rows)
            {
                string eventName = row["eventName"].ToString();
                int eventID = (int)row["eventID"];
                int eventType = (int)row["eventType"];
                int startHour = (int)row["startHour"];
                int startMinute = (int)row["startMinute"];
                int endHour = (int)row["endHour"];
                int endMinute = (int)row["endMinute"];
                int day = (int)row["day"];
                string studentName = row["studentName"].ToString();
                int newStudentID = (int)row["studentID"];
                int displayColor = (int)row["displayColor"];
                int details = (int)row["Details"];
                Time startTime = new Time(startHour, startMinute);
                Time endTime = new Time(endHour, endMinute);
                CalendarEvent newEvent = new CalendarEvent(eventName, startTime, endTime, day, eventType, studentName, newStudentID, displayColor);

                // set the EventDetailsID for the new event
                newEvent.DetailsID = details;

                newEvent.EventID = eventID;
                newSchedule.AddEvent(newEvent);
            }

            table.Dispose();                      
            return newSchedule;
        }        

        /// <summary>
        /// Queries the database for all of the subjects tutored by a single student worker
        /// </summary>
        /// <param name="studentID">The ID of the student worker whose subjects you want</param>
        /// <returns>A list of the subjects the student worker tutors</returns>
        public static List<Subject> GetStudentWorkersSubjects(int studentID)
        {
            List<Subject> subjects = new List<Subject>();
            DataTable table = new DataTable();

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT subject.subjectID, subject.subName, subject.abbreviation, subject.subNum
                                FROM subject JOIN subjecttutored on subject.subjectID = subjecttutored.subjectID
                                WHERE subjecttutored.studentID = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", studentID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);                         
                myAdapter.Fill(table);
                cmd.Dispose();
                myAdapter.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            foreach (DataRow row in table.Rows)
            {
                int id = (int)(row["subjectID"]);
                String name = row["subName"].ToString();
                String abbr = row["abbreviation"].ToString();
                int num = (int)(row["subNum"]);
                Subject subj = new Subject(id, abbr, num, name);
                subjects.Add(subj);
            }

            table.Dispose();
            return subjects;
        }

        public static StudentWorker[] GetStudentWorkerByID(int studentID)
        {
            StudentWorker [] studentWorkers = new StudentWorker[1];

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT studentName, displayColor, jobPosition 
                                FROM studentworker WHERE studentID = @studentID AND studentID IN 
	                                (SELECT StudentWorkerID FROM StudentWorkerSchedule 
		                            WHERE ScheduleID = (SELECT ScheduleID FROM CurrentSchedule)
	                                );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                MySqlDataReader reader = cmd.ExecuteReader();
               
                if (reader.Read())
                {
                    string name = reader["studentName"].ToString();
                    string jobPosition = reader["jobPosition"].ToString();
                    int displayColor = (int)reader["displayColor"];
                    studentWorkers[0] = new StudentWorker(studentID, name, jobPosition, displayColor);                    
                }


                cmd.Dispose();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
                        
            return studentWorkers;
        }

        public static List<StudentWorker> GetStudentWorkers()
        {
            List<StudentWorker> studentWorkers = new List<StudentWorker>();
            DataTable table = new DataTable();

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT studentID, studentName, displayColor, jobPosition 
                                FROM studentworker WHERE studentID IN 
	                                (SELECT StudentWorkerID FROM StudentWorkerSchedule 
		                            WHERE ScheduleID = (SELECT ScheduleID FROM CurrentSchedule)
	                                );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);               
                myAdapter.Fill(table);
                cmd.Dispose();
                myAdapter.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            foreach (DataRow row in table.Rows)
            {                
                string name = row["studentName"].ToString();                
                string jobPosition = row["jobPosition"].ToString();
                int displayColor = (int)row["displayColor"];
                int studentID = (int)row["studentID"];
                StudentWorker sw = new StudentWorker(studentID, name, jobPosition, displayColor);
                studentWorkers.Add(sw);
            }

            table.Dispose();
            return studentWorkers;
        }

        /// <summary>
        /// Retrieves all the subjects from the database
        /// </summary>
        /// <returns>List of all subjects</returns>
        public static List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            DataTable table = new DataTable();

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT subjectID, abbreviation, subNum, subName FROM subject ORDER BY abbreviation;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);                
                myAdapter.Fill(table);
                cmd.Dispose();
                myAdapter.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            foreach (DataRow row in table.Rows)
            {
                string name = row["subName"].ToString();
                string abbreviation = row["abbreviation"].ToString();
                int subNum = (int)row["subNum"];
                int subjectID = (int)row["subjectID"];
                Subject sub = new Subject(subjectID, abbreviation, subNum, name);
                subjects.Add(sub);
            }

            table.Dispose();
            return subjects;
        }

        /// <summary>
        /// Retrieves a list of studentIDs of the student workers who tutor a selected subject
        /// </summary>
        /// <param name="subjectID">The id of the subject</param>
        /// <returns>A list of integers containing the studentIDs of the students who tutor the subject</returns>
        public static List<StudentWorker> GetTutorsForSubject(int subjectID)
        {
            List<StudentWorker> tutorList = new List<StudentWorker>();
            DataTable table = new DataTable();

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT sw.studentID, sw.studentName
                              FROM studentworker sw JOIN subjecttutored sub on sw.studentID = sub.studentID
                              WHERE sub.subjectID = @subID	
	                              AND sw.studentID IN 
                                  (SELECT StudentWorkerID FROM StudentWorkerSchedule 
                                    WHERE ScheduleID = (SELECT ScheduleID FROM CurrentSchedule)
                                  );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subID", subjectID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);                
                myAdapter.Fill(table);
                cmd.Dispose();
                myAdapter.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            foreach (DataRow row in table.Rows)
            {
                int studentID = (int)row["studentID"];
                string name = row["studentName"].ToString();
                StudentWorker tutor = new StudentWorker(studentID, name);
                tutorList.Add(tutor);
            }

            table.Dispose();
            return tutorList;
        }


        public static List<string> GetTutorIDsForSubject(int subjectID)
        {
            List<string> tutorList = new List<string>();
            DataTable table = new DataTable();

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT sw.studentID
                              FROM studentworker sw JOIN subjecttutored sub on sw.studentID = sub.studentID
                              WHERE sub.subjectID = @subID	
	                              AND sw.studentID IN 
                                  (SELECT StudentWorkerID FROM StudentWorkerSchedule 
                                    WHERE ScheduleID = (SELECT ScheduleID FROM CurrentSchedule)
                                  );";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subID", subjectID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(table);
                cmd.Dispose();
                myAdapter.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            foreach (DataRow row in table.Rows)
            {
                string studentID = row["studentID"].ToString();
                tutorList.Add(studentID);
            }

            table.Dispose();
            return tutorList;
        }

        /// <summary>
        /// Removes a student worker from the current schedule
        /// </summary>
        /// <param name="studentID"></param>
        public static void RemoveStudentWorker(int studentID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"DELETE FROM StudentWorkerSchedule 
                                WHERE StudentWorkerID = @studentID
                                AND ScheduleID = (SELECT ScheduleID FROM CurrentSchedule);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine("Student Worker removed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Deletes all events belonging to a student worker for the current schedule
        /// </summary>
        /// <param name="studentID">The ID of the student worker</param>
        public static void RemoveStudentWorkersSchedules(int studentID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"DELETE FROM scheduleevent WHERE studentID = @studentID
                                AND ScheduleID = (SELECT ScheduleID FROM CurrentSchedule);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// [UNUSED]
        /// Deletes all subjects tutored belonging to a student worker from the database
        /// </summary>
        /// <param name="studentID">The ID of the student worker</param>
        public static void RemoveStudentWorkersSubjects(int studentID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"DELETE FROM subjecttutored where studentID=@studentID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Deletes subject with given ID from the database 
        /// </summary>
        /// <param name="subjectID">The ID of the subject to be deleted</param>
        public static void RemoveSubject(int subjectID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"DELETE FROM subject where subjectID=@subjectID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subjectID", subjectID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine("Subject removed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        } 
   
        /// <summary>
        /// Removes subject from the list of subjects a student worker tutors
        /// </summary>
        /// <param name="subjectID">The subject to be removed</param>
        public static void RemoveSubjectTutored(int subjectID, int studentID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"DELETE FROM subjecttutored WHERE subjectID=@subjectID AND studentID=@studentID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subjectID", subjectID);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine("Subject removed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Removes subject from the list of subjects a student worker tutors
        /// </summary>
        /// <param name="subjectID">The subject to be removed</param>
        public static void RemoveFromSubjectTutoredTable(int subjectID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"DELETE FROM subjecttutored WHERE subjectID=@subjectID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subjectID", subjectID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine("Subject removed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Create the EventDetails entry for the class or work event
        /// </summary>
        /// <returns></returns>
        public static int CreateEventDetails(string eventName)
        {
            int lastID = -1;
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();

                // create new EventDetails entry
                string sql = @"INSERT INTO EventDetails (EventName) VALUES (@eventName);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eventName", eventName);
                cmd.ExecuteNonQuery();

                // get ID of the new entry
                sql = @"SELECT LAST_INSERT_ID() AS 'LastID';";
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {                    
                    lastID = Convert.ToInt32(reader["LastID"]);                    
                }        
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            return lastID;
        }

        /// <summary>
        /// Saves a new event to the database
        /// </summary>
        /// <param name="studentID">The ID of the student worker who the event belongs to</param>
        /// <param name="newEvent">The CalendarEvent to save for the specified student worker</param>
        public static void SaveEvent(int studentID, CalendarEvent newEvent, int eventDetailsID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();               
                                
                string sql = @"INSERT INTO scheduleevent 
                            (studentID, eventType, startHour, startMinute, endHour, endMinute, `day`, Details, ScheduleID) 
                             VALUES (@studentID, @type, @startHour, @startMin, @endHour, @endMin, @day, @details, 
                                (SELECT (ScheduleID) FROM CurrentSchedule));";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.Parameters.AddWithValue("@type", newEvent.type);
                cmd.Parameters.AddWithValue("@startHour", newEvent.StartTime.hours);
                cmd.Parameters.AddWithValue("@startMin", newEvent.StartTime.minutes);
                cmd.Parameters.AddWithValue("@endHour", newEvent.EndTime.hours);
                cmd.Parameters.AddWithValue("@endMin", newEvent.EndTime.minutes);
                cmd.Parameters.AddWithValue("@day", newEvent.Day);
                cmd.Parameters.AddWithValue("@details", eventDetailsID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine("Event created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Saves a new student worker in the database, and add them to the current schedule
        /// </summary>
        /// <param name="student">A student worker object containing the information for the new student worker</param>
        /// <returns>True if the save was successful. False if there was an error.</returns>
        public static bool SaveStudentWorker(StudentWorker student)
        {
            bool success = false;
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"REPLACE studentworker (studentID, studentName, displayColor, jobPosition) 
                                VALUES (@studentID, @name, @color, @position);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", student.StudentID);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@color", student.DisplayColor);
                cmd.Parameters.AddWithValue("@position", student.JobPosition);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                // add student worker to the current schedule
                sql = @"INSERT INTO StudentWorkerSchedule (StudentWorkerID, ScheduleID)
                        VALUES (@studentID, (SELECT (ScheduleID) FROM CurrentSchedule));";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", student.StudentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine("Student Worker created.");
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
            return success;
        }

        /// <summary>
        /// Creates a record for a subject in the database
        /// </summary>
        /// <param name="subject">The new subject to be saved in the database</param>
        public static void SaveSubject(Subject subject)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"INSERT INTO subject (abbreviation, subNum, subName) VALUES (@abbreviation, @num, @name);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@abbreviation", subject.abbreviation);
                cmd.Parameters.AddWithValue("@num", subject.subjectNumber);
                cmd.Parameters.AddWithValue("@name", subject.name);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine("Subject created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        public static void UpdateStudentInfo(int studentID, string name, string position, int color)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"UPDATE studentworker 
                                SET studentName = @name, displayColor = @color, jobPosition = @position
                                WHERE studentID = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@id", studentID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        public static void UpdateEvent(CalendarEvent selectedEvent)
        {
            if (selectedEvent.EventID == -1)
            {
                return;
            }
            try
            {
                Console.Write("Connecting to MySQL... ");
                conn.Open();
                string sql = @"UPDATE scheduleevent
                               SET startHour = @startHour, startMinute = @startMinute, endHour = @endHour, endMinute = @endMinute
                               WHERE eventID = @eventID;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@startHour", selectedEvent.StartTime.hours);
                cmd.Parameters.AddWithValue("@startMinute", selectedEvent.StartTime.minutes);
                cmd.Parameters.AddWithValue("@endHour", selectedEvent.EndTime.hours);
                cmd.Parameters.AddWithValue("@endMinute", selectedEvent.EndTime.minutes);
                cmd.Parameters.AddWithValue("@eventID", selectedEvent.EventID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Remove the ScheduleEvent entry from the database, and remove the EventDetails entry if no more ScheduleEvents are related to it.
        /// </summary>
        /// <param name="selectedEvent">The ScheduleEvent to remove</param>
        public static void RemoveEvent(CalendarEvent selectedEvent)
        {
            try
            {
                Console.Write("Connecting to MySql... ");

                // remove the selected ScheduleEvent
                conn.Open();
                string sql = @"DELETE FROM scheduleevent where eventID = @eventID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eventID", selectedEvent.EventID);
                cmd.ExecuteNonQuery();

                // remove entries from EventDetails that have no corresponding ScheduleEvents
                sql = @"DELETE FROM EventDetails
                        WHERE NOT EXISTS (
	                        SELECT * FROM ScheduleEvent
	                        WHERE Details = EventDetailsID);";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                Console.WriteLine("Event removed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Opens the specified schedule by setting CurrentSchedule to the scheduleID in the database         
        /// </summary>
        /// <param name="scheduleID"></param>
        public static void OpenSchedule(string scheduleID) {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();

                // remove CurrentSchedule entry
                string sql = @"DELETE FROM CurrentSchedule;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                // enter specified scheduleID as the new CurrentSchedule
                sql = @"INSERT INTO CurrentSchedule(CurrentScheduleID, ScheduleID) VALUES (1, @scheduleID);";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@scheduleID", scheduleID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Console.WriteLine("Current schedule updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Retrieve all full schedules including name and ID for opening a different schedule
        /// </summary>
        /// <returns>A list of arrays containing the id and name of each schedule</returns>
        public static List<string[]> GetFullSchedules()
        {
            List<string[]> schedules = new List<string[]>();
            DataTable table = new DataTable();
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT * FROM Schedule";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(table);                                
                cmd.Dispose();
                myAdapter.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                table.Dispose();
                return schedules;
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            foreach (DataRow row in table.Rows)
            {
                schedules.Add(new string[] { row["ScheduleID"].ToString(), row["Name"].ToString() });
            }
            table.Dispose();

            return schedules;
        }

        public static void CreateSchedule(string name)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();

                // create new Schedule entry with specified name
                string sql = @"INSERT INTO Schedule (Name) VALUES (@name);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();                

                // get the id of the Schedule entry just created
                sql = @"SELECT LAST_INSERT_ID() AS lastID;";
                cmd.CommandText = sql;                
                MySqlDataReader reader = cmd.ExecuteReader();
                string lastID = null;
                if (reader.Read())
                {
                    lastID = reader["lastID"].ToString();
                }
                reader.Dispose();
                if (lastID == null)
                {
                    Console.WriteLine("Failed to retrieve last insert id for new schedule.");
                    cmd.Dispose();
                    conn.Close();
                    return;
                }

                // assign all student workers on the current schedule to the new schedule
                sql = @"INSERT INTO StudentWorkerSchedule (StudentWorkerID, ScheduleID)
	                    SELECT StudentWorkerID, @lastID
		                    FROM StudentWorkerSchedule
		                    WHERE ScheduleID = (SELECT (ScheduleID) FROM CurrentSchedule);";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lastID", lastID);
                cmd.ExecuteNonQuery();

                // remove the CurrentSchedule entry
                sql = @"DELETE FROM CurrentSchedule;";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                // update the CurrentSchedule to the new Schedule
                sql = @"INSERT INTO CurrentSchedule (CurrentScheduleID, ScheduleID) VALUES (1, @lastID);";
                cmd.CommandText = sql;                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
                Console.WriteLine("Current schedule updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Get the name of the current schedule to display in the main form title
        /// </summary>
        /// <returns>The name of the current schedule</returns>
        public static string GetCurrentScheduleName()
        {
            string currentName = null;
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                
                string sql = @"SELECT (Name) FROM Schedule 
                                WHERE ScheduleID = (SELECT (ScheduleID) FROM CurrentSchedule);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);                                                
                MySqlDataReader reader = cmd.ExecuteReader();                
                if (reader.Read())
                {
                    currentName = reader["Name"].ToString();
                }
                reader.Dispose();
                cmd.Dispose();                                                            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            if (currentName == null)
            {
                Console.WriteLine("Failed to retrieve current schedule name.");
                return "";
            }
            else
            {
                return currentName;
            }
        }
    }
}
