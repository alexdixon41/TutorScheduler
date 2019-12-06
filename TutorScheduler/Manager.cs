using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    class Manager
    {
        private string name;

        public static bool Login(string username, string pword)
        {
            return DatabaseManager.Login(username, pword);
        }
    }
}
