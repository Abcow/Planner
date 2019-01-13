using System;
using Planner.Framework;
using static Planner.Calendar.Constants;

namespace Planner.Calendar
{
    public class Year : DayRange
    {
        private readonly DateTime _dateTime;

        private static Year GetYearContaining(Day day)
        {
            var firstDay = new DateTime(day.DateTime.Year, 1, 1);
            var lastDay = new DateTime(day.DateTime.Year, 12, 31);

            return new Year(firstDay, lastDay);
       }

        private Year(Day firstDay, Day lastDay)
            : base(firstDay, lastDay)
        {
            _dateTime = firstDay;
        }
        
        public static implicit operator Year(Day day) => GetYearContaining(day);
        public static implicit operator Year(DateTime dateTime) => GetYearContaining(dateTime);

        public static implicit operator string(Year year) => year.ToString();

        public static Year operator +(Year year, int increment) => year._dateTime.AddYears(increment);
        public static Year operator -(Year year, int decrement) => year._dateTime.AddYears(-decrement);
        public static YMDuration operator -(Year year1, Year year2) => new YMDuration(years: year1.Number - year2.Number);

        public static bool operator <(Year year1, Year year2) => (year1 - year2).IsNegative;
        public static bool operator >(Year year1, Year year2) => (year1 - year2).IsPositive;
        public static bool operator ==(Year year1, Year year2) => (year1 - year2).IsZero;
        public static bool operator !=(Year year1, Year year2) => !(year1 == year2);
        public static bool operator <=(Year year1, Year year2) => !(year1 > year2);
        public static bool operator >=(Year year1, Year year2) => !(year1 < year2);
        
        public int Number => _dateTime.Year;

        public bool IsLeapYear => DateTime.IsLeapYear(_dateTime.Year);
        public int DayCount => IsLeapYear ? DAYS_IN_A_LEAP_YEAR : DAYS_IN_A_NON_LEAP_YEAR;
        public int WeekCount
        {
            get
            {
                if (FirstDay.DayOfTheWeek == DayOfTheWeek.Thursday ||
                   (FirstDay.DayOfTheWeek == DayOfTheWeek.Wednesday && IsLeapYear))
                {
                    return 53;
                }

                return 52;
            }
        }

        public Month GetMonth(MonthOfTheYear month) => new DateTime(_dateTime.Year, month.ToInt(), 1);

        public Week GetWeek(WeekOfTheYear week)
        {
            if (week.ToInt() > WeekCount) return null;
            var firstThursdayOffset = (-(int)FirstDay.DayOfTheWeek).DMod(DAYS_IN_A_WEEK);
            var dayInWeek = FirstDay + firstThursdayOffset + (int)week * DAYS_IN_A_WEEK;
            return dayInWeek.Week;
        }

        public Day GetDay(DayOfTheYear day)
        {
            if (day == DayOfTheYear.Day366 && !IsLeapYear) return null;
            return FirstDay + (int)day;
        }

        public override string ToString()
        {
            if (Number >= 0)
            {
                return Number.ToString();
            }

            return $"{-Number} BCE";
        }

        public override bool Equals(object obj)
        {
            var year = obj as Year;
            return year != null &&
                   Number == year.Number;
        }

        public override int GetHashCode()
        {
            return 187193536 + Number.GetHashCode();
        }
    }
}
