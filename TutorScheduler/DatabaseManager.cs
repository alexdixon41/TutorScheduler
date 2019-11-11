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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        public static bool GetManager(string email, string pass)
        {
            bool result = false;
            try
            {
                // TODO - cryptography
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT pword FROM manager WHERE email = @emailAddr;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@emailAddr", email);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                string pword = null;

                if (reader.Read())
                {                   
                    pword = reader["pword"].ToString();
                }            

                if (pword.Equals(pass))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            // close MySql connection
            conn.Close();
            Console.WriteLine("Done.");

            return result;
        }

        /// <summary>
        /// Load the class or work schedule from the database for the specified student worker.
        /// </summary>
        /// <param name="studentID">The studentID of the student worker whose schedule will be loaded</param>
        /// <returns>Schedule of class or work events for the specified student worker</returns>
        public static Schedule GetSchedule(int studentID, int scheduleType)
        {
            DataTable table = new DataTable();

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT eventID, eventType, startHour, startMinute, endHour, endMinute, 
                            monday, tuesday, wednesday, thursday, friday, studentName, displayColor
                            FROM studentworker sw JOIN scheduleevent e ON e.studentID = sw.studentID
                            WHERE sw.studentID = @id AND e.eventType = @scheduleType;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", studentID);
                cmd.Parameters.AddWithValue("@scheduleType", scheduleType);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(table);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            Schedule newSchedule = new Schedule();

            foreach (DataRow row in table.Rows)
            {
                int eventID = (int)row["eventID"];
                int eventType = (int)row["eventType"];
                int startHour = (int)row["startHour"];
                int startMinute = (int)row["startMinute"];
                int endHour = (int)row["endHour"];
                int endMinute = (int)row["endMinute"];
                bool[] days = new bool[] {(bool)row["monday"], (bool)row["tuesday"], (bool)row["wednesday"],
                    (bool)row["thursday"], (bool)row["friday"] };
                string studentName = row["studentName"].ToString();
                int displayColor = (int)row["displayColor"];
                Time startTime = new Time(startHour, startMinute);
                Time endTime = new Time(endHour, endMinute);
                for (int i = 0; i < 5; i++)
                {
                    if (days[i])
                    {
                        CalendarEvent newEvent = new CalendarEvent(startTime, endTime, i, eventType, studentName, displayColor);
                        newSchedule.AddEvent(newEvent);
                    }
                }
            }
                       
            return newSchedule;
        }

        public static StudentWorker GetStudentWorkerByID(int studentID)
        {
            StudentWorker sw = null;           // the student worker to be retrieved from the database

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT studentName, displayColor, jobPosition FROM studentworker WHERE studentID = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", studentID);
                MySqlDataReader reader = cmd.ExecuteReader();    

                if (reader.Read())
                {
                    string name = reader["studentName"].ToString();
                    string jobPosition = reader["jobPosition"].ToString();
                    int displayColor = (int) reader["displayColor"];
                    sw = new StudentWorker(studentID, name, jobPosition, displayColor);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            // close connection
            conn.Close();
            Console.WriteLine("Done.");

            return sw;
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

            return subjects;
        }

        public static List<StudentWorker> GetStudentWorkers()
        {
            List<StudentWorker> studentWorkers = new List<StudentWorker>();
            DataTable table = new DataTable();

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT studentID, studentName, displayColor, jobPosition FROM studentworker;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(table);
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

            return subjects;
        }

        /// <summary>
        /// Retrieves a list of studentIDs of the student workers who tutor a selected subject
        /// </summary>
        /// <param name="subjectID">The id of the subject</param>
        /// <returns>A list of integers containing the studentIDs of the students who tutor the subject</returns>
        public static List<StudentWorker> getTutorsForSubject(int subjectID)
        {
            List<StudentWorker> tutorList = new List<StudentWorker>();
            DataTable table = new DataTable();

            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"SELECT sw.studentID, sw.studentName
                                FROM studentworker sw JOIN subjecttutored sub on sw.studentID = sub.studentID
                                WHERE sub.subjectID = @subID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subID", subjectID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(table);
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

            return tutorList;
        }

        /// <summary>
        /// Deletes a student worker from the database 
        /// </summary>
        /// <param name="studentID"></param>
        public static void RemoveStudentWorker(int studentID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"DELETE FROM studentworker where studentID=@studentID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
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
        
        public static void RemoveSubjectTutored(int subjectID)
        {
            try
            {
                Console.Write("Connecting to MySql... ");
                conn.Open();
                string sql = @"DELETE FROM subjecttutored where subjectID=@subjectID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subjectID", subjectID);
                cmd.ExecuteNonQuery();
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
        /// Saves a new student worker in the database
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
                string sql = @"INSERT INTO studentworker (studentID, studentName, displayColor, jobPosition) VALUES (@studentID, @name, @color, @position);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentID", student.StudentID);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@color", student.DisplayColor);
                cmd.Parameters.AddWithValue("@position", student.JobPosition);
                cmd.ExecuteNonQuery();
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
    }
}
