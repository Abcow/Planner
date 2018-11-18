using System;
using System.Collections.Generic;

namespace Planner.Models.Recurrence
{
    public interface IRecurrenceRule
    {
        IEnumerable<System.DateTime> GetOccurences(System.DateTime start, System.DateTime end);
    }
}
