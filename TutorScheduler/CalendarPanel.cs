using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorScheduler
{
    class CalendarPanel : Panel
    {
        protected override System.Drawing.Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
    }
}
