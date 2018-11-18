using System;

namespace Planner.Models.DateTime
{
    public class Day
    {
        private System.DateTime _date;

        private Day(System.DateTime dateTime)
        {
            _date = dateTime.Date;
        }

        public static implicit operator string(Day day) => day.ToString();
        public static implicit operator Day(System.DateTime dateTime) => new Day(dateTime);
        public static implicit operator System.DateTime(Day day) => day._date;

        public static Day operator +(Day day, int increment) => day.AddDays(increment);
        public static Day operator -(Day day, int decrement) => day.AddDays(-decrement);
        public static Day operator +(Day day, Duration duration) => day.AddYears(duration.Years).AddMonths(duration.Months).AddWeeks(duration.Weeks).AddDays(duration.Days + ((duration.Hours + duration.Minutes / 60) / 24));
        public static Day operator -(Day day, Duration duration) => day.AddYears(-duration.Years).AddMonths(-duration.Months).AddWeeks(-duration.Weeks).AddDays(-duration.Days - ((duration.Hours + duration.Minutes / 60) / 24));
        public static Duration operator -(Day day1, Day day2) => new Duration(days: Convert.ToInt32((day1._date - day2._date).TotalDays));

        public static bool operator <(Day day1, Day day2) => (day1 - day2).IsNegative;
        public static bool operator >(Day day1, Day day2) => (day1 - day2).IsPositive;
        public static bool operator ==(Day day1, Day day2) => (day1 - day2).IsZero;
        public static bool operator !=(Day day1, Day day2) => !(day1 == day2);
        public static bool operator <=(Day day1, Day day2) => !(day1 > day2);
        public static bool operator >=(Day day1, Day day2) => !(day1 < day2);

        public DayOfTheWeek DayOfTheWeek => DayOfTheWeekEx.FromDayOfWeek(_date.DayOfWeek);
        public DayOfTheMonth DayOfTheMonth => DayOfTheMonthEx.FromInt(_date.Day);
        public DayOfTheYear DayOfTheYear => DayOfTheYearEx.FromInt(_date.DayOfYear);

        public Week Week => this;
        public Month Month => this;
        public Year Year => this;
        public System.DateTime DateTime => this;

        public Day AddDays(int days) => _date.AddDays(days);
        public Day AddWeeks(int weeks) => _date.AddDays(weeks * 7);
        public Day AddMonths(int months) => _date.AddMonths(months);
        public Day AddYears(int years) => _date.AddYears(years);

        public override string ToString()
        {
            return $"{DayOfTheMonth} {Month} {Year}";
        }

        public override bool Equals(object obj)
        {
            var day = obj as Day;
            return day != null &&
                   DayOfTheYear == day.DayOfTheYear &&
                   Year == day.Year;
        }

        public override int GetHashCode()
        {
            var hashCode = -789712400;
            hashCode = hashCode * -1521134295 + DayOfTheYear.GetHashCode();
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            return hashCode;
        }
    }
}
