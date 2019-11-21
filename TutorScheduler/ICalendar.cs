using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorScheduler
{
    /// <summary>
    /// Represents a calendar view to be implemented as a user control. For example, a week calendar view or day calendar view.
    /// </summary>
    internal interface ICalendar
    {
        void AddSchedule(IndividualSchedule schedule);
        CalendarEvent EventAt(System.Drawing.Point p);        
        void DrawCalendarEvents(System.Windows.Forms.PaintEventArgs pe);
        void DrawCalendarFrame(System.Windows.Forms.PaintEventArgs pe);
        string GetHourLabel(int hours);

        /// <summary>
        /// Clear all events from the calendar
        /// </summary>
        void Clear();
    }
}
