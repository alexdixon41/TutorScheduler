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
        public int subjectNumber;
        public string name;

        public Subject(int subID, string subAbbreviation, int subNumber, string subName)
        {
            subjectID = subID;
            abbreviation = subAbbreviation;
            subjectNumber = subNumber;
            name = subName;
        }

        public Subject(string subAbbreviation, int subNumber, string subName)
        {
            abbreviation = subAbbreviation;
            subjectNumber = subNumber;
            name = subName;
        }

        public List<StudentWorker> GetTutors()
        {
            return DatabaseManager.GetTutorsForSubject(subjectID);
        }

        public void RemoveSubject()
        {
            DatabaseManager.RemoveSubject(subjectID);
            DatabaseManager.RemoveSubjectTutored(subjectID);
        }

        #region Static Functions

        public static void Create(string subAbbreviation, int subNumber, string subName)
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
