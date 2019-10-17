using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorScheduler
{ 
    public partial class CalendarWeekView : Control, ICalendar
    {
        public event ResizeHandler resizeEvent;

        public const int leftMargin = 60;           // distance from left side of client rectangle to left vertical border of Monday
        public const int rightMargin = 10;
        public const int topMargin = 0;                   

        private List<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

        public CalendarWeekView()
        {         
            InitializeComponent();
            ResizeRedraw = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint, true);         
        }    

        internal void PrintEvents()
        {
            foreach (CalendarEvent e in CalendarEvents)
            {
                Console.WriteLine(e.SecondaryText + " - " + e.StartTime.hours + ":" + e.StartTime.minutes + "  " + e.Day);
            }
            Console.WriteLine("-----------------------");
        }
        
        /// <summary>
        /// Add every event of each schedule to the calendar, maintaining sequential order by merging. Assumes each schedule is sorted.
        /// </summary>
        /// <param name="schedules">List of schedule objects containing events sorted in sequential order</param>
        public void AddSchedule(Schedule schedule)
        {
            int events_index = 0, schedule_index = 0;
            
            // merge events from the schedule with current events on the calendar
            while (events_index < CalendarEvents.Count && schedule_index < schedule.Events.Count)
            {
                
                while (events_index < CalendarEvents.Count && CalendarEvents[events_index] < schedule.Events[schedule_index])
                {                    
                    events_index++;
                }
                CalendarEvents.Insert(events_index, schedule.Events[schedule_index]);
                schedule_index++;
                events_index++;
            }

            // add remaining events on the schedule to the calendar
            for (; schedule_index < schedule.Events.Count; schedule_index++)
            {
                CalendarEvents.Add(schedule.Events[schedule_index]);
            }            
        }

        public CalendarEvent EventAt(Point p)
        {
            foreach (CalendarEvent calendarEvent in CalendarEvents)
            {
                if (calendarEvent.GetBounds().Contains(p) && calendarEvent.type == CalendarEvent.AVAILABILITY)
                {
                    return calendarEvent;
                }
            }
            return null;
        }            

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            CalendarEvent hitEvent = EventAt(e.Location);

            // perform actions on event that was clicked
            if (hitEvent != null)
            {
                hitEvent.OnClick();
                this.Invalidate(hitEvent.GetBounds());
            }
        }

        public void Clear()
        {
            CalendarEvents.Clear();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            DrawCalendarFrame(pe);
            DrawCalendarEvents(pe);
            pe.Graphics.Flush();            
        }                       

        public int MaxOverlap(List<CalendarEvent> events)
        {
            int[] overlaps = new int[events.Count];
            int[] overlappedBy = new int[events.Count];

            for (int i = 0; i < events.Count; i++)
            {
                int k = i + 1;
                while (k < events.Count && CalendarEvent.Overlap(events[i], events[k]))
                {
                    overlappedBy[i] += 1;
                    overlaps[k] += 1;
                    k++;
                }
            }           

            if (overlaps.Length > 0)
            {
                return overlaps.Max() + 1;
            }
            else
            {
                return 1;
            }
        }

        public List<CalendarEvent>[] OverlappedBy(List<CalendarEvent> events)
        {
            List<CalendarEvent>[] overlappedBy = new List<CalendarEvent>[events.Count];            

            for (int i = events.Count - 1; i >= 0; i--)
            {
                int k = i - 1;
                while (k >= 0 && CalendarEvent.Overlap(events[i], events[k]))
                {
                    overlappedBy[k].Add(events[k]);
                    k--;
                }
            }
            
            return overlappedBy;
        }
                
        /// <summary>
        /// Calculate and set bounds for each calendar event, adjusting for overlap as needed
        /// </summary>
        public void CalculateBounds()
        {
            int width = ClientRectangle.Width - leftMargin - rightMargin;             // full width of a day on the calendar

            List<CalendarEvent>[] dayEvents = new List<CalendarEvent>[5];            

            for (int i = 0; i < 5; i++)
            {
                dayEvents[i] = new List<CalendarEvent>();
            }

            foreach (CalendarEvent calendarEvent in CalendarEvents)
            {
                dayEvents[calendarEvent.Day].Add(calendarEvent);
            }

            for (int i = 0; i < 5; i++)
            {
                List<CalendarEvent> toPlace = dayEvents[i];
                int left = i * width / 5 + leftMargin;
                int minWidth = (width / 5 - 10) / MaxOverlap(toPlace);                

                while (toPlace.Count > 0)
                {
                    for (int j = 0; j < toPlace.Count; )
                    {                        
                        int k = j + 1;
                        while (k < toPlace.Count && CalendarEvent.Overlap(toPlace[j], toPlace[k]))
                        {                            
                            k++;
                        }                      
                                                
                        Time eventDuration = toPlace[j].EndTime - toPlace[j].StartTime;
                        int eventTop = 80 * toPlace[j].StartTime.hours + 4 * toPlace[j].StartTime.minutes / 3 + topMargin;
                        int eventHeight = 80 * eventDuration.hours + 4 * eventDuration.minutes / 3;
                        toPlace[j].SetBounds(new Rectangle(left, eventTop, minWidth, eventHeight));

                        toPlace.RemoveAt(j);

                        j = k - 1;
                    }
                    left += minWidth;
                }
            }
        }               

        /// <summary>
        /// Draw each calendar event in CalendarEvents on the calendar view
        /// </summary>
        /// <param name="pe">PaintEventArgs for drawing graphics on the control</param>
        public void DrawCalendarEvents(PaintEventArgs pe)
        {
            if (CalendarEvents == null)
            {
                return;
            }

            CalculateBounds();
            
            foreach (CalendarEvent calendarEvent in CalendarEvents)
            {                              
                Rectangle bounds = calendarEvent.GetBounds();

                SolidBrush brush = new SolidBrush(calendarEvent.BackgroundColor);                
                pe.Graphics.FillRectangle(brush, new Rectangle(bounds.Left + 1, bounds.Top + 1, bounds.Width - 2, bounds.Height - 2));

                // draw event text
                brush.Color = calendarEvent.TextColor;
                Font font = new Font("Segoe UI", 11, FontStyle.Bold);
                
                // draw text to fit within event bounds with no wrap - just cut off characters that don't fit
                pe.Graphics.DrawString(calendarEvent.PrimaryText, font, brush, 
                    new RectangleF(bounds.Left + 5, bounds.Top + 5, bounds.Width, bounds.Height), new StringFormat(StringFormatFlags.NoWrap));

                // draw secondary text below primary text in the same way, just not bold
                font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                pe.Graphics.DrawString(calendarEvent.SecondaryText, font, brush, 
                    new RectangleF(bounds.Left + 5, bounds.Top + 25, bounds.Width, bounds.Height), new StringFormat(StringFormatFlags.NoWrap));
                
                brush.Dispose();
            }
        }

        /// <summary>
        /// Draw the day/hour grid and hour labels for the frame of the calendar
        /// </summary>
        /// <param name="pe">PaintEventArgs for drawing graphics on the control</param>        
        public void DrawCalendarFrame(PaintEventArgs pe)
        {                                                       
            int width = this.ClientRectangle.Width - leftMargin - rightMargin;
            int height = 1920;
            int left = this.ClientRectangle.Left + leftMargin;
            int top = this.ClientRectangle.Top + topMargin;
            int right = left + width;
            int bottom = top + height;                        
            
            // fire the resize event with the needed positions for the day dividers
            CalendarResizedEventArgs r = new CalendarResizedEventArgs
            {
                dayStartPositions = new int[] { left, left + width / 5, left + 2 * width / 5, left + 3 * width / 5, left + 4 * width / 5, right },                
            };
            resizeEvent?.Invoke(this, r);

            Pen pen = new Pen(Color.LightGray);

            // draw horizontal divider lines of calendar
            int startX;
            for (int i = 0; i < 48; i++)
            {
                if (i % 2 == 0)
                {
                    startX = 0;
                }
                else
                {
                    startX = leftMargin;
                }
                pe.Graphics.DrawLine(pen, new Point(startX, top + 40 * i), new Point(right, top + 40 * i));
            }

            pen.Color = Color.Black;

            // draw vertical divider lines of calendar
            pe.Graphics.DrawLine(pen, new Point(left, top), new Point(left, bottom));                      // left vertical border line
            pe.Graphics.DrawLine(pen, new Point(left + width / 5, top), new Point(left + width / 5, bottom));    
            pe.Graphics.DrawLine(pen, new Point(left + 2 * width / 5, top), new Point(left + 2 * width / 5, bottom));
            pe.Graphics.DrawLine(pen, new Point(left + 3 * width / 5, top), new Point(left + 3 * width / 5, bottom));
            pe.Graphics.DrawLine(pen, new Point(left + 4 * width / 5, top), new Point(left + 4 * width / 5, bottom));
            pe.Graphics.DrawLine(pen, new Point(right, top), new Point(right, bottom));                    // right vertical border line                      

            // draw bottom border line
            pen.Width *= 2;
            pe.Graphics.DrawLine(pen, new Point(left, bottom), new Point(right, bottom));

            // finished with pen for drawing, so dispose
            pen.Dispose();

            // prepare to draw hour divider labels (using SolidBrush)
            System.Drawing.Font drawFont = new System.Drawing.Font("Segoe UI", 12);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();

            // draw label for each hour
            for (int i = 0; i < 24; i++)
            {
                pe.Graphics.DrawString(GetHourLabel(i), drawFont, brush, 5, top + 80 * i, drawFormat);
            }

            // dispose of string drawing resources
            drawFont.Dispose();
            brush.Dispose();
            drawFormat.Dispose();
        }

        /// <summary>
        /// Get the label string for a 24-hour integer
        /// </summary>
        /// <param name="hours">Integer from 0 - 23 inclusive to represent an hour from 12am to 11pm</param>
        /// <returns>A string to label the 24-hour integer as a 12-hour time</returns>
        public string GetHourLabel(int hours)
        {
            if (hours == 0)
            {
                return "12 am";
            }
            else if (hours < 12)
            {
                return "" + hours + " am";
            }
            else if (hours == 12)
            {
                return "12 pm";
            }            
            else
            {
                return "" + hours % 12 + " pm";
            }
        }

        // TODO - remove if unused
        public void CalculateEventBounds()
        {
            int width = this.ClientRectangle.Width - leftMargin - rightMargin;              // calendar width
            //int eventWidth = width / 5 - 10;

            foreach (CalendarEvent calendarEvent in CalendarEvents)
            {
                calendarEvent.SetBounds(new Rectangle(calendarEvent.Day * width / 5 + leftMargin, 0, width / 5 - 10, 0));
            }

            List<CalendarEvent> overlappedEvents = new List<CalendarEvent>();           // save events that are overlapped from left to right

            for (int i = 0; i < CalendarEvents.Count; i++)
            {
                CalendarEvent calendarEvent = CalendarEvents[i];

                int eventLeft = calendarEvent.GetBounds().Left;
                int eventWidth = calendarEvent.GetBounds().Width;

                List<CalendarEvent> overlappingEvents = new List<CalendarEvent>() { CalendarEvents[i] };

                int k = i + 1;
                while (k < CalendarEvents.Count && CalendarEvent.Overlap(CalendarEvents[i], CalendarEvents[k]))
                {
                    overlappingEvents.Add(CalendarEvents[k]);
                    k++;
                }

                //foreach (CalendarEvent e in overlappingEvents)
                //{
                //    Console.WriteLine(e.PrimaryText + " - " + e.StartTime.hours + ":" + e.StartTime.minutes + " - " + e.EndTime.hours + ":" + e.EndTime.minutes + "  " + e.Day);
                //}
                //Console.WriteLine("------------------");

                // when moving to the next day, clear overlapped events
                if (i > 0 && CalendarEvents[i].Day > CalendarEvents[i - 1].Day)
                {
                    overlappedEvents.Clear();
                }

                if (overlappingEvents.Count > 1)
                {
                    eventWidth = eventWidth / 2;
                    // first event in overlapping list is overlapped by the others
                    // keep track of this event to check later
                    overlappedEvents.Add(overlappingEvents[0]);
                    //Console.WriteLine("Overlapped events: ");
                    //foreach (CalendarEvent e in overlappedEvents)
                    //{
                    //    Console.WriteLine(e.StartTime.hours + ":" + e.StartTime.minutes + "-" + e.EndTime.hours + ":" + e.EndTime.minutes + "  " + e.Day + "  " + e.PrimaryText);
                    //}
                    //Console.WriteLine("------------------\n");
                }

                // calculate sizes of all overlapping events
                for (int j = 0; j < overlappingEvents.Count; j++)
                {
                    Time eventDuration = overlappingEvents[j].EndTime - overlappingEvents[j].StartTime;
                    int eventTop = 80 * overlappingEvents[j].StartTime.hours + 4 * overlappingEvents[j].StartTime.minutes / 3 + topMargin;
                    int eventHeight = 80 * eventDuration.hours + 4 * eventDuration.minutes / 3;

                    // first event bounds do not change - this is the overlapped event 
                    if (j == 0)
                    {
                        overlappingEvents[j].SetBounds(new Rectangle(eventLeft, eventTop, eventWidth, eventHeight));
                    }
                    else
                    {
                        bool setLeftAbsolute = false;
                        // check if this event still overlaps all the overlapped events
                        for (int m = overlappedEvents.Count - 1; m >= 0; m--)
                        {
                            if (!CalendarEvent.Overlap(overlappedEvents[m], overlappingEvents[j]))
                            {
                                //Console.WriteLine("No overlap with: " + overlappedEvents[m].StartTime.hours + ":" + 
                                //    overlappedEvents[m].StartTime.minutes + "-" + overlappedEvents[m].EndTime.hours + ":" + 
                                //    overlappedEvents[m].EndTime.minutes + "  " + overlappedEvents[m].Day + " - " + overlappedEvents[m].PrimaryText);                                
                                eventWidth = overlappedEvents[m].GetBounds().Width;
                                eventLeft = overlappedEvents[m].GetBounds().Left;
                                overlappedEvents.RemoveAt(m);
                                setLeftAbsolute = true;
                            }
                        }
                        if (setLeftAbsolute)
                        {
                            overlappingEvents[j].SetBounds(new Rectangle(eventLeft, eventTop, eventWidth, eventHeight));
                        }
                        else
                        {
                            overlappingEvents[j].SetBounds(new Rectangle(eventLeft + eventWidth, eventTop, eventWidth, eventHeight));
                        }
                    }
                }
            }
        }
    }
}
