using Planner.Framework;

namespace Planner.Models.DateTime
{
    public class Month : DayRange
    {
        private static Month GetMonthContaining(Day day)
        {
            var firstDay = new System.DateTime(day.DateTime.Year, day.DateTime.Month, 1);
            var lastDay = new System.DateTime(
                day.DateTime.Year,
                day.DateTime.Month,
                System.DateTime.DaysInMonth(day.DateTime.Year, day.DateTime.Month));

            return new Month(firstDay, lastDay);
        }

        private Month(Day firstDay, Day lastDay)
            : base(firstDay, lastDay)
        { }

        public static implicit operator Month(Day day) => GetMonthContaining(day);
        public static implicit operator Month(System.DateTime dateTime) => GetMonthContaining(dateTime);

        public static implicit operator string(Month month) => month.ToString();

        public static Month operator +(Month month, int increment) => month.FirstDay.AddMonths(increment);
        public static Month operator -(Month month, int decrement) => month.FirstDay.AddMonths(-decrement);
        public static int operator -(Month month1, Month month2) => 12 * (month1.Year.Number - month2.Year.Number) + (month1.MonthOfTheYear - month2.MonthOfTheYear);

        public static bool operator <(Month month1, Month month2) => month2 - month1 < 0;
        public static bool operator >(Month month1, Month month2) => month1 - month2 > 0;
        public static bool operator ==(Month month1, Month month2) => month1 - month2 == 0;
        public static bool operator !=(Month month1, Month month2) => !(month1 == month2);
        public static bool operator <=(Month month1, Month month2) => !(month1 > month2);
        public static bool operator >=(Month month1, Month month2) => !(month1 < month2);

        public MonthOfTheYear MonthOfTheYear => MonthOfTheYearEx.FromInt(FirstDay.DateTime.Month);
        
        public Year Year => FirstDay;

        public int DayCount => System.DateTime.DaysInMonth(Year.Number, MonthOfTheYear.ToInt());
        public int WeekCount
        {
            get
            {
                switch (FirstDay.DayOfTheWeek)
                {
                    case DayOfTheWeek.Tuesday:
                        if (DayCount >= 31) return 5;
                        break;

                    case DayOfTheWeek.Wednesday:
                        if (DayCount >= 30) return 5;
                        break;

                    case DayOfTheWeek.Thursday:
                        if (DayCount >= 29) return 5;
                        break;
                }

                return 4;
            }
        }

        public Week GetWeek(WeekOfTheMonth week)
        {
            if (week.ToInt() > WeekCount) return null;
            var firstThursdayOffset = (-(int)FirstDay.DayOfTheWeek).Mod(7);
            var dayInWeek = FirstDay + firstThursdayOffset + (int)week * 7;
            return dayInWeek.Week;
        }

        public Day GetDay(DayOfTheMonth day)
        {
            if (day.ToInt() > DayCount) return null;
            return FirstDay + (int)day;
        }

        public override string ToString()
        {
            return $"{MonthOfTheYear} {Year}";
        }

        public override bool Equals(object obj)
        {
            var month = obj as Month;
            return month != null &&
                   MonthOfTheYear == month.MonthOfTheYear &&
                   Year == month.Year;
        }

        public override int GetHashCode()
        {
            var hashCode = -1865746542;
            hashCode = hashCode * -1521134295 + MonthOfTheYear.GetHashCode();
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            return hashCode;
        }
    }
}
