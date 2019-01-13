using Planner.Framework;
using System;
using static Planner.Calendar.Constants;

namespace Planner.Calendar
{
    public class Week : DayRange
    {
        private readonly Day _thursday;

        private static Week GetWeekContaining(Day day)
        {
            int thursdayOffset = -(int)day.DayOfTheWeek; // Thursday == 0
            if (day.DayOfTheWeek >= CalendarScheme.FirstDayOfTheWeek)
            {
                thursdayOffset += DAYS_IN_A_WEEK;
            }
            var thursday = day + thursdayOffset;
            var firstDay = thursday + ((int)CalendarScheme.FirstDayOfTheWeek).DMod(-DAYS_IN_A_WEEK);
            var lastDay = firstDay + DAYS_IN_A_WEEK - 1;

            return new Week(firstDay, lastDay, thursday);
        }

        private Week(Day firstDay, Day lastDay, Day thursday)
            : base(firstDay, lastDay)
        {
            _thursday = thursday;
        }

        public static implicit operator Week(DateTime dateTime) => GetWeekContaining(dateTime);
        public static implicit operator Week(Day day) => GetWeekContaining(day);

        public static implicit operator string(Week week) => week.ToString();

        public static Week operator +(Week week, int increment) => week._thursday + (DAYS_IN_A_WEEK * increment);
        public static Week operator -(Week week, int decrement) => week._thursday - (DAYS_IN_A_WEEK * decrement);
        public static WDHMDuration operator -(Week week1, Week week2) => week1._thursday - week2._thursday;

        public static bool operator <(Week week1, Week week2) => (week1 - week2).IsNegative;
        public static bool operator >(Week week1, Week week2) => (week1 - week2).IsPositive;
        public static bool operator ==(Week week1, Week week2) => (week1 - week2).IsZero;
        public static bool operator !=(Week week1, Week week2) => !(week1 == week2);
        public static bool operator <=(Week week1, Week week2) => !(week1 > week2);
        public static bool operator >=(Week week1, Week week2) => !(week1 < week2);

        public WeekOfTheYear WeekOfTheYear => (WeekOfTheYear)((int)_thursday.DayOfTheYear / DAYS_IN_A_WEEK);

        public Year Year => _thursday;
        public Month Month => _thursday;

        public Day GetDay(DayOfTheWeek day) => FirstDay + day.ToInt() - 1;

        public override string ToString()
        {
            return $"{WeekOfTheYear}, {Year}";
        }

        public override bool Equals(object obj)
        {
            var week = obj as Week;
            return week != null &&
                   WeekOfTheYear == week.WeekOfTheYear &&
                   Year == week.Year;
        }

        public override int GetHashCode()
        {
            var hashCode = -840402262;
            hashCode = hashCode * -1521134295 + WeekOfTheYear.GetHashCode();
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            return hashCode;
        }
    }
}
