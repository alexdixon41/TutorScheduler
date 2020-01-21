﻿using System;
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
