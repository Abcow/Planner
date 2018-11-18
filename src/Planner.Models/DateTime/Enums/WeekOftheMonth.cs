using System;

namespace Planner.Models.DateTime
{
    public enum WeekOfTheMonth
    {
        Week1 = 0,
        Week2 = 1,
        Week3 = 2,
        Week4 = 3,
        Week5 = 4,
    }

    public static class WeekOfTheMonthEx
    {
        public static int ToInt(this WeekOfTheMonth weekOfTheMonth)
        {
            return (int)weekOfTheMonth + 1;
        }

        public static WeekOfTheMonth FromInt(int i)
        {
            if (i > 5 || i < 1) throw new ArgumentException($"Invalid week of the month: {i}");
            return (WeekOfTheMonth)(i - 1);
        }

        public static string ToString(this WeekOfTheMonth weekOfTheMonth)
        {
            int numeral = weekOfTheMonth.ToInt();

            return $"Week {numeral}";
        }
    }
}
