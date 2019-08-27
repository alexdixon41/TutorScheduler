using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingAlgorithm
{
    /// <summary>
    /// Represents a location where student workers will be scheduled to work
    /// </summary>
    class WorkLocation
    {
        // TODO - add configuration option to change the location hours
        
        // array of opening times for each weekday
        public static Time[] openingTimes = new Time[]
        {
            new Time(8, 0),             // monday
            new Time(8, 0),             // tuesday
            new Time(8, 0),             // wednesday
            new Time(8, 0),             // thursday
            new Time(8, 0)              // friday
        };

        // array of closing times for each weekday
        public static Time[] closingTimes = new Time[]
        {
            new Time(20, 0),
            new Time(20, 0),
            new Time(20, 0),
            new Time(17, 0),
            new Time(16, 30)
        };
    }
}
