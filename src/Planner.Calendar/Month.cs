using Planner.Framework;
using static Planner.Calendar.Constants;

namespace Planner.Calendar
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
        public static YMDuration operator -(Month month1, Month month2) => new YMDuration(month1.Year.Number - month2.Year.Number, month1.MonthOfTheYear - month2.MonthOfTheYear);

        public static bool operator <(Month month1, Month month2) => (month1 - month2).IsNegative;
        public static bool operator >(Month month1, Month month2) => (month1 - month2).IsPositive;
        public static bool operator ==(Month month1, Month month2) => (month1 - month2).IsZero;
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
                        if (DayCount >= 31) return MAX_WEEKS_IN_A_MONTH;
                        break;

                    case DayOfTheWeek.Wednesday:
                        if (DayCount >= 30) return MAX_WEEKS_IN_A_MONTH;
                        break;

                    case DayOfTheWeek.Thursday:
                        if (DayCount >= 29) return MAX_WEEKS_IN_A_MONTH;
                        break;
                }

                return MIN_WEEKS_IN_A_MONTH;
            }
        }

        public Week GetWeek(WeekOfTheMonth week)
        {
            if (week.ToInt() > WeekCount) return null;
            var firstThursdayOffset = (-(int)FirstDay.DayOfTheWeek).DMod(7);
            var dayInWeek = FirstDay + firstThursdayOffset + (int)week * DAYS_IN_A_WEEK;
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
