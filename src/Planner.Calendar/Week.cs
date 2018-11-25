using Planner.Framework;
using System;

namespace Planner.Calendar
{
    public class Week : DayRange
    {
        private readonly Day _thursday;

        private static Week GetWeekContaining(Day day)
        {
            int thursdayOffset = -(int)day.DayOfTheWeek; // Thursday == 0
            if (day.DayOfTheWeek >= DateTimeScheme.FirstDayOfTheWeek)
            {
                thursdayOffset += 7;
            }
            var thursday = day + thursdayOffset;
            var firstDay = thursday + ((int)DateTimeScheme.FirstDayOfTheWeek).Mod(-7);
            var lastDay = firstDay + 6;

            return new Week(firstDay, lastDay, thursday);
        }

        private Week(Day firstDay, Day lastDay, Day thursday)
            : base(firstDay, lastDay)
        {
            _thursday = thursday;
        }

        public static implicit operator Week(System.DateTime dateTime) => GetWeekContaining(dateTime);
        public static implicit operator Week(Day day) => GetWeekContaining(day);

        public static implicit operator string(Week week) => week.ToString();

        public static Week operator +(Week week, int increment) => week._thursday + (7 * increment);
        public static Week operator -(Week week, int decrement) => week._thursday - (7 * decrement);
        public static int operator -(Week week1, Week week2) => Convert.ToInt32((week1._thursday - week2._thursday).Weeks);

        public static bool operator <(Week week1, Week week2) => week2 - week1 < 0;
        public static bool operator >(Week week1, Week week2) => week1 - week2 > 0;
        public static bool operator ==(Week week1, Week week2) => week1 - week2 == 0;
        public static bool operator !=(Week week1, Week week2) => !(week1 == week2);
        public static bool operator <=(Week week1, Week week2) => !(week1 > week2);
        public static bool operator >=(Week week1, Week week2) => !(week1 < week2);

        public WeekOfTheYear WeekOfTheYear => (WeekOfTheYear)((int)_thursday.DayOfTheYear / 7);

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
