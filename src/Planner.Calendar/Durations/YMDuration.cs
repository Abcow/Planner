using static Planner.Calendar.Constants;

namespace Planner.Calendar
{
    public class YMDuration
    {
        public static readonly YMDuration ZERO = new YMDuration(years: 0, months: 0);

        public YMDuration(int years = 0, int months = 0)
        {
            TotalMonths = MONTHS_IN_A_YEAR * years + months;
            TotalYears = TotalMonths / MONTHS_IN_A_YEAR;

            MonthsComponent = TotalMonths % MONTHS_IN_A_YEAR;
        }

        public static YMDuration operator +(YMDuration ym1, YMDuration ym2) =>
            new YMDuration(months: ym1.TotalMonths + ym2.TotalMonths);
        
        public static YMDuration operator -(YMDuration ym1, YMDuration ym2) =>
            new YMDuration(months: ym1.TotalMonths - ym2.TotalMonths);

        public static YMDuration operator -(YMDuration ym) =>
            new YMDuration(months: -ym.TotalMonths);

        public static CompositeDuration operator +(YMDuration ym, WDHMDuration wdhm) =>
            new CompositeDuration(ym, wdhm);

        public static CompositeDuration operator -(YMDuration ym, WDHMDuration wdhm) =>
            new CompositeDuration(ym, -wdhm);

        public static implicit operator CompositeDuration(YMDuration ym) =>
            new CompositeDuration(ym, WDHMDuration.ZERO);

        public static YMDuration operator *(YMDuration ym, double n) =>
            new YMDuration(months: (int)(ym.TotalMonths * n));

        public static YMDuration operator /(YMDuration ym, double n) =>
            new YMDuration(months: (int)(ym.TotalMonths / n));

        public int YearsComponent => TotalYears;
        public int MonthsComponent { get; }

        public int TotalYears { get; }
        public int TotalMonths { get; }

        public bool IsPositive =>
            YearsComponent > 0 ||
            (YearsComponent == 0 && MonthsComponent > 0);

        public bool IsNegative =>
            YearsComponent < 0 ||
            (YearsComponent == 0 && MonthsComponent < 0);

        public bool IsZero => YearsComponent == 0 && MonthsComponent == 0;

        public WDHMDuration GetUpperBoundWDHM()
        {
            int days = MaxDaysInMonths(TotalMonths);
            return new WDHMDuration(days: days);
        }

        public WDHMDuration GetLowerBoundWDHM()
        {
            int days = MinDaysInMonths(TotalMonths);
            return new WDHMDuration(days: days);
        }
    }
}
