using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    public class RefreshCalendars
    {
        public static event Action RefreshCalendarsEvent;

        public static void Refresh()
        {
            RefreshCalendarsEvent();
        }
    }
   
}
