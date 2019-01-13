using static Planner.Calendar.Constants;

namespace Planner.Calendar
{
    public class WDHMDuration : IDuration
    {
        public static readonly WDHMDuration ZERO = new WDHMDuration(weeks: 0, days: 0, hours: 0, minutes: 0);

        public WDHMDuration(int weeks = 0, int days = 0, int hours = 0, int minutes = 0)
        {
            TotalMinutes =
                minutes
                + hours * MINUTES_IN_AN_HOUR
                + days * MINUTES_IN_A_DAY
                + weeks * MINUTES_IN_A_WEEK;

            TotalDays = TotalMinutes / MINUTES_IN_A_DAY;
            TotalHours = TotalMinutes / MINUTES_IN_AN_HOUR;
            TotalWeeks = TotalMinutes / MINUTES_IN_A_WEEK;

            DaysComponent = TotalDays % DAYS_IN_A_WEEK;
            HoursComponent = TotalHours % HOURS_IN_A_DAY;
            MinutesComponent = TotalMinutes % MINUTES_IN_AN_HOUR;
        }

        public static WDHMDuration operator +(WDHMDuration wdhm1, WDHMDuration wdhm2) =>
            new WDHMDuration(minutes: wdhm1.TotalMinutes + wdhm2.TotalMinutes);
        
        public static WDHMDuration operator -(WDHMDuration wdhm1, WDHMDuration wdhm2) =>
            new WDHMDuration(minutes: wdhm1.TotalMinutes - wdhm2.TotalMinutes);

        public static WDHMDuration operator -(WDHMDuration wdhm) =>
            new WDHMDuration(minutes: -wdhm.TotalMinutes);

        public static CompositeDuration operator +(WDHMDuration wdhm, YMDuration ym) =>
            new CompositeDuration(ym, wdhm);

        public static CompositeDuration operator -(WDHMDuration wdhm, YMDuration ym) =>
            new CompositeDuration(-ym, wdhm);

        public static implicit operator CompositeDuration(WDHMDuration wdhm) =>
            new CompositeDuration(YMDuration.ZERO, wdhm);

        public static WDHMDuration operator *(WDHMDuration wdhm, double n) =>
            new WDHMDuration(minutes: (int)(wdhm.TotalMinutes * n));

        public static WDHMDuration operator /(WDHMDuration wdhm, double n) =>
            new WDHMDuration(minutes: (int)(wdhm.TotalMinutes / n));

        public int WeeksComponent => TotalWeeks;
        public int DaysComponent { get; }
        public int HoursComponent { get; }
        public int MinutesComponent { get; }

        public int TotalWeeks { get; }
        public int TotalDays { get; }
        public int TotalHours { get; }
        public int TotalMinutes { get; }

        public bool IsPositive =>
            WeeksComponent > 0 || WeeksComponent == 0 && (
                DaysComponent > 0 || DaysComponent == 0 && (
                    HoursComponent > 0 || HoursComponent == 0 && (
                        MinutesComponent > 0)));

        public bool IsNegative =>
            WeeksComponent < 0 || WeeksComponent == 0 && (
                DaysComponent < 0 || DaysComponent == 0 && (
                    HoursComponent < 0 || HoursComponent == 0 && (
                        MinutesComponent < 0)));

        public bool IsZero => WeeksComponent == 0 && DaysComponent == 0 && HoursComponent == 0 && MinutesComponent == 0;

        public YMDuration GetUpperBoundYM()
        {
            var months = MaxMonthsInDays(TotalDays);
            return new YMDuration(months: months);
        }

        public YMDuration GetLowerBoundYM()
        {
            var months = MinMonthsInDays(TotalDays);
            return new YMDuration(months: months);
        }
    }
}
