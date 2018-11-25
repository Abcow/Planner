namespace Planner.Calendar
{
    public class DayRange
    {
        public DayRange(Day firstDay, Day lastDay)
        {
            FirstDay = firstDay;
            LastDay = lastDay;
        }

        public Day FirstDay { get; }
        public Day LastDay { get; }
    }
}
