using System;
using Planner.Framework;

namespace Planner.Models.DateTime
{
    public class Year : DayRange
    {
        private System.DateTime _dateTime;

        private static Year GetYearContaining(Day day)
        {
            var firstDay = new System.DateTime(day.DateTime.Year, 1, 1);
            var lastDay = new System.DateTime(day.DateTime.Year, 12, 31);

            return new Year(firstDay, lastDay);
       }

        private Year(Day firstDay, Day lastDay)
            : base(firstDay, lastDay)
        { }
        
        public static implicit operator Year(Day day) => GetYearContaining(day);
        public static implicit operator Year(System.DateTime dateTime) => GetYearContaining(dateTime);

        public static implicit operator string(Year year) => year.ToString();

        public static Year operator +(Year year, int increment) => year._dateTime.AddYears(increment);
        public static Year operator -(Year year, int decrement) => year._dateTime.AddYears(-decrement);
        public static int operator -(Year year1, Year year2) => Convert.ToInt32((year1.FirstDay - year2.FirstDay) / 365.25);

        public static bool operator <(Year year1, Year year2) => year2 - year1 < 0;
        public static bool operator >(Year year1, Year year2) => year1 - year2 > 0;
        public static bool operator ==(Year year1, Year year2) => year1 - year2 == 0;
        public static bool operator !=(Year year1, Year year2) => !(year1 == year2);
        public static bool operator <=(Year year1, Year year2) => !(year1 > year2);
        public static bool operator >=(Year year1, Year year2) => !(year1 < year2);
        
        public int Number => _dateTime.Year;

        public bool IsLeapYear => System.DateTime.IsLeapYear(_dateTime.Year);
        public int DayCount => IsLeapYear ? 366 : 365;
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

        public Month GetMonth(MonthOfTheYear month) => new System.DateTime(_dateTime.Year, month.ToInt(), 1);

        public Week GetWeek(WeekOfTheYear week)
        {
            if (week.ToInt() > WeekCount) return null;
            var firstThursdayOffset = (-(int)FirstDay.DayOfTheWeek).Mod(7);
            var dayInWeek = FirstDay + firstThursdayOffset + (int)week * 7;
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
