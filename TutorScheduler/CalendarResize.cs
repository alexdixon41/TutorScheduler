using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    public delegate void ResizeHandler(object sender, CalendarResizedEventArgs e);    

    public class CalendarResizedEventArgs : EventArgs
    {
        public int[] dayStartPositions { get; set; }
        public int dayWidth { get; set; }
    }
}
