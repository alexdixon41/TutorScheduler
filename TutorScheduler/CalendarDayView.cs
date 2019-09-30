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
    public partial class CalendarDayView : Control
    {
        public event ResizeHandler resizeEvent;

        public const int leftMargin = 60;           // distance from left side of client rectangle to left vertical border of Monday
        public const int rightMargin = 10;
        public const int topMargin = 30;

        private int day = (int)Day.Monday;                            // the currently-selected day to display

        private List<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

        public CalendarDayView()
        {         
            InitializeComponent();
            ResizeRedraw = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint, true);         
        }      

        internal void AddEvents(List<CalendarEvent> events)
        {
            CalendarEvents.AddRange(events);
        }

        internal CalendarEvent EventAt(Point p)
        {
            foreach (CalendarEvent calendarEvent in CalendarEvents)
            {
                if (calendarEvent.GetBounds().Contains(p))
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

        protected override void OnPaint(PaintEventArgs pe)
        {           
            DrawCalendarFrame(pe);
            DrawCalendarEvents(pe);
            pe.Graphics.Flush();           
        }       

        /// <summary>
        /// Draw each calendar event in CalendarEvents on the calendar view
        /// </summary>
        /// <param name="pe">PaintEventArgs for drawing graphics on the control</param>
        private void DrawCalendarEvents(PaintEventArgs pe)
        {
            if (CalendarEvents == null)
            {
                return;
            }
            int width = this.ClientRectangle.Width - leftMargin - rightMargin;
            foreach (CalendarEvent calendarEvent in CalendarEvents)
            {
                if (calendarEvent.Day == day)
                {
                    Console.WriteLine(day);
                    SolidBrush brush = new SolidBrush(calendarEvent.BackgroundColor);

                    Time eventDuration = calendarEvent.EndTime - calendarEvent.StartTime;

                    // size and position of event rectangle
                    int eventLeft = leftMargin;
                    int eventTop = 80 * calendarEvent.StartTime.hours + 4 * calendarEvent.StartTime.minutes / 3 + topMargin;
                    int eventWidth = width - 10;
                    int eventHeight = 80 * eventDuration.hours + 4 * eventDuration.minutes / 3;

                    calendarEvent.SetBounds(new Rectangle(eventLeft, eventTop, eventWidth, eventHeight));

                    pe.Graphics.FillRectangle(brush, new Rectangle(eventLeft, eventTop, eventWidth, eventHeight));

                    // draw event text
                    brush.Color = calendarEvent.TextColor;
                    System.Drawing.Font font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);

                    // draw text to fit within event bounds with no wrap - just cut off characters that don't fit
                    pe.Graphics.DrawString(calendarEvent.PrimaryText, font, brush,
                        new RectangleF(eventLeft + 5, eventTop + 5, eventWidth, eventHeight), new StringFormat(StringFormatFlags.NoWrap));

                    // draw secondary text below primary text in the same way, just not bold
                    font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                    pe.Graphics.DrawString(calendarEvent.SecondaryText, font, brush,
                        new RectangleF(eventLeft + 5, eventTop + 25, eventWidth, eventHeight), new StringFormat(StringFormatFlags.NoWrap));


                    brush.Dispose();
                }
            }
        }

        /// <summary>
        /// Draw the day/hour grid and hour labels for the frame of the calendar
        /// </summary>
        /// <param name="pe">PaintEventArgs for drawing graphics on the control</param>        
        private void DrawCalendarFrame(PaintEventArgs pe)
        {                                                       
            int width = this.ClientRectangle.Width - leftMargin - rightMargin;
            int height = 1920;
            int left = this.ClientRectangle.Left + leftMargin;
            int top = this.ClientRectangle.Top + topMargin;
            int right = left + width;
            int bottom = top + height;            

            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.LightGray);
            
            // fire the resize event with the needed positions for the day dividers
            CalendarResizedEventArgs r = new CalendarResizedEventArgs
            {
                dayStartPositions = new int[] {left + 2 * width / 5, left + 3 * width / 5 },                
            };            
            resizeEvent?.Invoke(this, r);            

            // draw vertical divider lines of calendar
            pe.Graphics.DrawLine(pen, new Point(left, top), new Point(left, bottom));                      // left vertical border line
            //pe.Graphics.DrawLine(pen, new Point(left + width / 5, top), new Point(left + width / 5, bottom));    
            //pe.Graphics.DrawLine(pen, new Point(left + 2 * width / 5, top), new Point(left + 2 * width / 5, bottom));
            //pe.Graphics.DrawLine(pen, new Point(left + 3 * width / 5, top), new Point(left + 3 * width / 5, bottom));
            //pe.Graphics.DrawLine(pen, new Point(left + 4 * width / 5, top), new Point(left + 4 * width / 5, bottom));
            pe.Graphics.DrawLine(pen, new Point(right, top), new Point(right, bottom));                    // right vertical border line

            // draw horizontal divider lines of calendar
            int startX;
            for (int i = 0; i <= 48; i++)
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

            // finished with pen for drawing, so dispose
            pen.Dispose();

            // prepare to draw hour divider labels (using SolidBrush)
            System.Drawing.Font drawFont = new System.Drawing.Font("Segoe UI", 12);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();

            // draw label for each hour
            for (int i = 0; i < 24; i++)
            {
                pe.Graphics.DrawString(GetHourLabel(i), drawFont, brush, 0, top + 80 * i, drawFormat);
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
    }
}
