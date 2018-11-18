using System;

namespace Planner.Models
{
    public struct TimeSlot
    {
        public TimeSlot(System.DateTime start, System.DateTime end)
        {
            StartDate = start.Date;

            if (end.Date > start.Date)
            {
                EndDate = end.Date;
            }
            start.time
                start.
        }

        DateTime StartDate { get; }
        DateTime EndDate { get; }


    }
}
