namespace Planner.Calendar
{
    public class CompositeDuration
    {
        private readonly YMDuration _ym;
        private readonly WDHMDuration _wdhm;

        public CompositeDuration(int years = 0, int months = 0, int weeks = 0, int days = 0, int hours = 0, int minutes = 0)
        {
            _ym = new YMDuration(years, months);
            _wdhm = new WDHMDuration(weeks, days, hours, minutes);
        }

        public CompositeDuration(YMDuration ym, WDHMDuration wdhm)
            : this()
        {
            _ym = ym;
            _wdhm = wdhm;
        }

        public static CompositeDuration operator +(CompositeDuration duration1, CompositeDuration duration2) => new CompositeDuration(
            duration1.YearsComponent + duration2.YearsComponent,
            duration1.MonthsComponent + duration2.MonthsComponent,
            duration1.WeeksComponent + duration2.WeeksComponent,
            duration1.DaysComponent + duration2.DaysComponent,
            duration1.HoursComponent + duration2.HoursComponent,
            duration1.MinutesComponent + duration2.MinutesComponent);

        public static CompositeDuration operator -(CompositeDuration duration1, CompositeDuration duration2) => new CompositeDuration(
            duration1.YearsComponent - duration2.YearsComponent,
            duration1.MonthsComponent - duration2.MonthsComponent,
            duration1.WeeksComponent - duration2.WeeksComponent,
            duration1.DaysComponent - duration2.DaysComponent,
            duration1.HoursComponent - duration2.HoursComponent,
            duration1.MinutesComponent - duration2.MinutesComponent);

        public static CompositeDuration operator *(CompositeDuration duration, double n) =>
            new CompositeDuration(duration._ym * n, duration._wdhm * n);

        public static CompositeDuration operator /(CompositeDuration duration, double n) =>
            new CompositeDuration(duration._ym / n, duration._wdhm / n);

        YMDuration GetUpperBoundYM() => _ym + _wdhm.GetUpperBoundYM();
        YMDuration GetLowerBoundYM() => _ym + _wdhm.GetLowerBoundYM();
        WDHMDuration GetUpperBoundWDHM() => _wdhm + _ym.GetUpperBoundWDHM();
        WDHMDuration GetLowerBoundWDHM() => _wdhm + _ym.GetLowerBoundWDHM();

        public int YearsComponent { get; }
        public int MonthsComponent { get; }
        public int WeeksComponent { get; }
        public int DaysComponent { get; }
        public int HoursComponent { get; }
        public int MinutesComponent { get; }

        public bool IsZero => _ym.IsZero && _wdhm.IsZero;

        public bool IsAmbiguous
        {
            get
            {
                if (IsZero) return false;
                if (_ym.IsNegative && _wdhm.IsNegative) return false;
                if (_ym.IsPositive && _wdhm.IsPositive) return false;
                if (GetLowerBoundYM().IsNegative && GetUpperBoundYM().IsPositive) return true;
                if (GetLowerBoundWDHM().IsNegative && GetUpperBoundWDHM().IsPositive) return true;
                return false;
            }
        }

        public bool IsPositive
        {
            get
            {
                if (IsZero) return false;
                if (_ym.IsNegative && _wdhm.IsNegative) return true;
                if (GetLowerBoundWDHM().IsPositive && GetLowerBoundYM().IsPositive) return true;
                return false;
            }
        }

        public bool IsNegative
        {
            get
            {
                if (IsZero) return false;
                if (_ym.IsPositive && _wdhm.IsPositive) return true;
                if (GetLowerBoundWDHM().IsNegative && GetLowerBoundYM().IsNegative) return true;
                return false;
            }
        }
    }
}
