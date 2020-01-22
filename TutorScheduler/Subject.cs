using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    public class Subject
    {
        public int subjectID;
        public string abbreviation;
        public string subjectNumber;
        public string name;

        public Subject(int subID, string subAbbreviation, string subNumber, string subName)
        {
            subjectID = subID;
            abbreviation = subAbbreviation;
            subjectNumber = subNumber;
            name = subName;
        }

        public Subject(string subAbbreviation, string subNumber, string subName)
        {
            abbreviation = subAbbreviation;
            subjectNumber = subNumber;
            name = subName;
        }

        public List<StudentWorker> GetTutors()
        {
            return DatabaseManager.GetTutorsForSubject(subjectID);
        }

        public List<string> GetTutorIDs()
        {
            return DatabaseManager.GetTutorIDsForSubject(subjectID);
        }

        public void RemoveSubject()
        {
            DatabaseManager.RemoveSubject(subjectID);
            DatabaseManager.RemoveFromSubjectTutoredTable(subjectID);
        }

        /// <summary>
        /// Build an IndividualSchedule for all the times a subject is tutored to show on subject flyers
        /// </summary>        
        /// <returns>IndividualSchedule containing all the times the subject is tutored</returns>
        public IndividualSchedule SetFlyer()
        {
            List<StudentWorker> tutorList = GetTutors();
            IndividualSchedule subjectSchedule = new IndividualSchedule();
            IndividualSchedule tutorSchedule = new IndividualSchedule();

            foreach (StudentWorker tutor in tutorList)
            {
                tutor.GetWorkSchedule();
                foreach (CalendarEvent newEvent in tutor.WorkSchedule.Events)
                {
                    tutorSchedule.AddEvent(newEvent);
                }
            }

            foreach (CalendarEvent shift in tutorSchedule.Events)
            {
                if (!subjectSchedule.Contains(shift))
                {
                    if (!subjectSchedule.CoverageOverlaps(shift))
                    {
                        subjectSchedule.AddEvent(shift);
                    }
                    else
                    {
                        subjectSchedule.Merge(shift);
                    }
                }
            }

            return subjectSchedule;
        }

        #region Static Functions        

        public static void Create(string subAbbreviation, string subNumber, string subName)
        {
            //Create new subject
            Subject newSubject = new Subject(subAbbreviation, subNumber, subName);

            //Save new subject
            DatabaseManager.SaveSubject(newSubject);
        }

        public static List<Subject> GetSubjects()
        {
            return DatabaseManager.GetSubjects();
        }

        public static bool VerifyNumber(string numString)
        {
            if (numString.Length != 3)
            {
                new AlertDialog("The subject number should be 3 digits").ShowDialog();
                return false;
            }
            try
            {
                Int32.Parse(numString);
            }
            catch
            {
                new AlertDialog("The subject number should only contain numbers.");
                return false;
            }
            return true;
        }

        public static bool VerifyAbbreviation(string abbreviation)
        {
            if (abbreviation.Length != 3)
            {
                new AlertDialog("The subject's abbreviation should only include 3 letters.").ShowDialog();
                return false;
            }
            return true;
        }
        #endregion
    }
}
