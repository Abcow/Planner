using System;

namespace Planner.Calendar
{
    public class Duration
    {
        internal Duration(int years = 0, int months = 0, int weeks = 0, int days = 0, int hours = 0, int minutes = 0)
        {
            var normalisedMonths = years * 12 + months;

            Years = normalisedMonths / 12;
            Months = normalisedMonths % 12;

            var normalisedDays = days + (hours + minutes / 60) / 24;

            Weeks = weeks + normalisedDays / 7;
            Days = normalisedDays % 7;
            Hours = hours % 24;
            Minutes = minutes % 60;
        }

        public static Duration operator +(Duration duration1, Duration duration2) => new Duration(
            duration1.Years + duration2.Years,
            duration1.Months + duration2.Months,
            duration1.Weeks + duration2.Weeks,
            duration1.Days + duration2.Days,
            duration1.Hours + duration2.Hours,
            duration1.Minutes + duration2.Minutes);
        
        public static Duration operator -(Duration duration1, Duration duration2) => new Duration(
            duration1.Years - duration2.Years,
            duration1.Months - duration2.Months,
            duration1.Weeks - duration2.Weeks,
            duration1.Days - duration2.Days,
            duration1.Hours - duration2.Hours,
            duration1.Minutes - duration2.Minutes);

        public int Years { get; }
        public int Months { get; }
        public int Weeks { get; }
        public int Days { get; }
        public int Hours { get; }
        public int Minutes { get; }

        public bool IsZero => 
            Years == 0 &&
            Months == 0 &&
            Weeks == 0 &&
            Days == 0 &&
            Hours == 0 &&
            Minutes == 0;
        
        public bool IsAmbiguous => !(IsPositive || IsNegative || IsZero);

        public bool IsPositive
        {
            get
            {
                if (IsZero) return false;

                var days = Days + Weeks * 7;
                var months = Months + Years * 12;
                
                if (months > 0)
                {
                    days += AbsUpperBound();
                }
                else if (months < 0)
                {
                    days -= AbsLowerBound();
                }

                if (days != 0) return days > 0;
                else return (Minutes + Hours * 60) > 0;
            }
        }

        public bool IsNegative
        {
            get
            {
                if (IsZero) return false;

                var days = Days + Weeks * 7;
                var months = Months + Years * 12;
                
                if (months > 0)
                {
                    days += AbsLowerBound();
                }
                else if (months < 0)
                {
                    days -= AbsUpperBound();
                }

                if (days != 0) return days < 0;
                else return (Minutes + Hours * 60) < 0;
            }
        }

        // Upper bound for absolute number of days covered by the Months and Years components
        private int AbsUpperBound()
        {
            int leapYears = (Math.Abs(Years) + 3) / 4;
            leapYears = leapYears - (leapYears / 25) + ((leapYears + 75) / 100);

            int days = Math.Abs(Years) * 365 + leapYears;

            switch (Math.Abs(Months) % 12)
            {
                case 0: return days;
                case 1: return days + 31;
                case 2: return days + 62;
                case 3: return days + 92;
                case 4: return days + 123;
                case 5: return days + 153;
                case 6: return days + 184;
                case 7: return days + 215;
                case 8: return days + 245;
                case 9: return days + 276;
                case 10: return days + 306;
                case 11: return days + 337;
            }

            throw new Exception($"Error calcuating upper-bound in Duration");
        }

        // Lower bound for absolute number of days covered by the Months and Years components
        private int AbsLowerBound()
        {
            int leapYears = Math.Abs(Years) / 4;
            leapYears = leapYears - ((leapYears + 24) / 25) + (leapYears / 100);

            int days = Math.Abs(Years) * 365 + leapYears;

            switch (Math.Abs(Months) % 12)
            {
                case 0: return days;
                case 1: return days + 28;
                case 2: return days + 59;
                case 3: return days + 89;
                case 4: return days + 120;
                case 5: return days + 150;
                case 6: return days + 181;
                case 7: return days + 212;
                case 8: return days + 242;
                case 9: return days + 273;
                case 10: return days + 303;
                case 11: return days + 334;
            }

            throw new Exception($"Error calcuating lower-bound in Duration");
        }
    }
}
