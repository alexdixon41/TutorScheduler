using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarWeekView
{
    public partial class CalendarWeekView : Control
    {
        public CalendarWeekView()
        {
            InitializeComponent();
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint,                             
                true);
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            DrawCalendarFrame();
        }

        /// <summary>
        /// Draw the day/hour grid and hour labels for the frame of the calendar
        /// </summary>
        private void DrawCalendarFrame()
        {
            int leftBorder = 60;
            int rightBorder = 10;
            int topBorder = 30;                       
            int width = this.ClientRectangle.Width - leftBorder - rightBorder;
            int height = 1920;
            int left = this.ClientRectangle.Left + leftBorder;
            int top = this.ClientRectangle.Top + topBorder;
            int right = left + width;
            int bottom = top + height;            

            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.LightGray);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();            

            // draw vertical divider lines of calendar
            formGraphics.DrawLine(pen, new Point(left, top), new Point(left, bottom));                      // left vertical border line
            formGraphics.DrawLine(pen, new Point(left + width / 5, top), new Point(left + width / 5, bottom));    
            formGraphics.DrawLine(pen, new Point(left + 2 * width / 5, top), new Point(left + 2 * width / 5, bottom));
            formGraphics.DrawLine(pen, new Point(left + 3 * width / 5, top), new Point(left + 3 * width / 5, bottom));
            formGraphics.DrawLine(pen, new Point(left + 4 * width / 5, top), new Point(left + 4 * width / 5, bottom));
            formGraphics.DrawLine(pen, new Point(right, top), new Point(right, bottom));                    // right vertical border line

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
                    startX = 60;
                }
                formGraphics.DrawLine(pen, new Point(startX, top + 40 * i), new Point(right, top + 40 * i));
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
                formGraphics.DrawString(GetHourLabel(i), drawFont, brush, 0, top + 80 * i, drawFormat);
            }

            // dispose of string drawing resources
            drawFont.Dispose();
            brush.Dispose();
            drawFormat.Dispose();

            // dispose of graphics resource
            formGraphics.Dispose();
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
