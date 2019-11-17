using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    // custom event to allow calendars to be refreshed from anywhere by calling Refresh
    // the action is registered in Form1 to call the PopulateCalendars function
    public class RefreshCalendars
    {
        public static event Action RefreshCalendarsEvent;

        public static void Refresh()
        {
            RefreshCalendarsEvent();
        }
    }
   
}
