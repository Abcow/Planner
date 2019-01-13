using Planner.Framework;
using System;

namespace Planner.Calendar
{
    public static class Constants
    {
        public const int DAYS_IN_A_WEEK = 7;
        public const int MONTHS_IN_A_YEAR = 12;
        public const int DAYS_IN_A_NON_LEAP_YEAR = 365;
        public const int DAYS_IN_A_LEAP_YEAR = 366;

        public const int HOURS_IN_A_DAY = 24;
        public const int HOURS_IN_A_WEEK = HOURS_IN_A_DAY * DAYS_IN_A_WEEK;

        public const int MINUTES_IN_AN_HOUR = 60;
        public const int MINUTES_IN_A_DAY = MINUTES_IN_AN_HOUR * HOURS_IN_A_DAY;
        public const int MINUTES_IN_A_WEEK = MINUTES_IN_AN_HOUR * HOURS_IN_A_WEEK;

        public const int MAX_WEEKS_IN_A_MONTH = 5;
        public const int MIN_WEEKS_IN_A_MONTH = 4;

        public const int MAX_WEEKS_IN_A_YEAR = 53;
        public const int MIN_WEEKS_IN_A_YEAR = 52;

        public const int MAX_DAYS_IN_A_YEAR = DAYS_IN_A_LEAP_YEAR;
        public const int MIN_DAYS_IN_A_YEAR = DAYS_IN_A_NON_LEAP_YEAR;
        public const double AVERAGE_DAYS_IN_A_YEAR = 365.25;

        public const int MAX_DAYS_IN_A_MONTH = 31;
        public const int MAX_DAYS_IN_TWO_MONTHS = 62;
        public const int MAX_DAYS_IN_THREE_MONTHS = 92;
        public const int MAX_DAYS_IN_FOUR_MONTHS = 123;
        public const int MAX_DAYS_IN_FIVE_MONTHS = 153;
        public const int MAX_DAYS_IN_SIX_MONTHS = 184;
        public const int MAX_DAYS_IN_SEVEN_MONTHS = 215;
        public const int MAX_DAYS_IN_EIGHT_MONTHS = 245;
        public const int MAX_DAYS_IN_NINE_MONTHS = 276;
        public const int MAX_DAYS_IN_TEN_MONTHS = 306;
        public const int MAX_DAYS_IN_ELEVEN_MONTHS = 337;

        public const int MIN_DAYS_IN_A_MONTH = 28;
        public const int MIN_DAYS_IN_TWO_MONTHS = 59;
        public const int MIN_DAYS_IN_THREE_MONTHS = 89;
        public const int MIN_DAYS_IN_FOUR_MONTHS = 120;
        public const int MIN_DAYS_IN_FIVE_MONTHS = 150;
        public const int MIN_DAYS_IN_SIX_MONTHS = 181;
        public const int MIN_DAYS_IN_SEVEN_MONTHS = 212;
        public const int MIN_DAYS_IN_EIGHT_MONTHS = 242;
        public const int MIN_DAYS_IN_NINE_MONTHS = 273;
        public const int MIN_DAYS_IN_TEN_MONTHS = 303;
        public const int MIN_DAYS_IN_ELEVEN_MONTHS = 334;

        public static int MinDaysInMonths(int numberOfMonths)
        {
            if (numberOfMonths < 0)
            {
                return -MaxDaysInMonths(-numberOfMonths);
            }

            int numberOfYears = numberOfMonths / MONTHS_IN_A_YEAR;
            int excessMonths = numberOfMonths % MONTHS_IN_A_YEAR;

            int numberOfDays = MinDaysInYears(numberOfYears);

            if (excessMonths == 11) numberOfDays += MIN_DAYS_IN_ELEVEN_MONTHS;
            else if (excessMonths == 10) numberOfDays += MIN_DAYS_IN_TEN_MONTHS;
            else if (excessMonths == 9) numberOfDays += MIN_DAYS_IN_NINE_MONTHS;
            else if (excessMonths == 8) numberOfDays += MIN_DAYS_IN_EIGHT_MONTHS;
            else if (excessMonths == 7) numberOfDays += MIN_DAYS_IN_SEVEN_MONTHS;
            else if (excessMonths == 6) numberOfDays += MIN_DAYS_IN_SIX_MONTHS;
            else if (excessMonths == 5) numberOfDays += MIN_DAYS_IN_FIVE_MONTHS;
            else if (excessMonths == 4) numberOfDays += MIN_DAYS_IN_FOUR_MONTHS;
            else if (excessMonths == 3) numberOfDays += MIN_DAYS_IN_THREE_MONTHS;
            else if (excessMonths == 2) numberOfDays += MIN_DAYS_IN_TWO_MONTHS;
            else if (excessMonths == 1) numberOfDays += MIN_DAYS_IN_A_MONTH;

            return numberOfDays;
        }

        public static int MaxDaysInMonths(int numberOfMonths)
        {
            if (numberOfMonths < 0)
            {
                return -MinDaysInMonths(-numberOfMonths);
            }

            int numberOfYears = numberOfMonths / MONTHS_IN_A_YEAR;
            int excessMonths = numberOfMonths %  MONTHS_IN_A_YEAR;

            int numberOfDays = MaxDaysInYears(numberOfYears);

            if (excessMonths == 11) numberOfDays += MAX_DAYS_IN_ELEVEN_MONTHS;
            else if (excessMonths == 10) numberOfDays += MAX_DAYS_IN_TEN_MONTHS;
            else if (excessMonths == 9) numberOfDays += MAX_DAYS_IN_NINE_MONTHS;
            else if (excessMonths == 8) numberOfDays += MAX_DAYS_IN_EIGHT_MONTHS;
            else if (excessMonths == 7) numberOfDays += MAX_DAYS_IN_SEVEN_MONTHS;
            else if (excessMonths == 6) numberOfDays += MAX_DAYS_IN_SIX_MONTHS;
            else if (excessMonths == 5) numberOfDays += MAX_DAYS_IN_FIVE_MONTHS;
            else if (excessMonths == 4) numberOfDays += MAX_DAYS_IN_FOUR_MONTHS;
            else if (excessMonths == 3) numberOfDays += MAX_DAYS_IN_THREE_MONTHS;
            else if (excessMonths == 2) numberOfDays += MAX_DAYS_IN_TWO_MONTHS;
            else if (excessMonths == 1) numberOfDays += MAX_DAYS_IN_A_MONTH;

            return numberOfDays;
        }

        public static int MinMonthsInDays(int numberOfDays)
        {
            if (numberOfDays < 0)
            {
                return -MaxMonthsInDays(-numberOfDays);
            }

            int numberOfYears = numberOfDays / DAYS_IN_A_NON_LEAP_YEAR;
            int excessDays = numberOfDays % DAYS_IN_A_NON_LEAP_YEAR;
            int numberOfLeapYears = MaxLeapYearsInYears(numberOfYears);

            if (excessDays < numberOfLeapYears)
            {
                numberOfYears -= 1;
                excessDays += DAYS_IN_A_NON_LEAP_YEAR;
                numberOfLeapYears = MaxLeapYearsInYears(numberOfYears);
            }
            excessDays -= numberOfLeapYears;
            int numberOfMonths = numberOfYears * MONTHS_IN_A_YEAR;

            if (excessDays >= MAX_DAYS_IN_ELEVEN_MONTHS) numberOfMonths += 11;
            else if (excessDays >= MAX_DAYS_IN_TEN_MONTHS) numberOfMonths += 10;
            else if (excessDays >= MAX_DAYS_IN_NINE_MONTHS) numberOfMonths += 9;
            else if (excessDays >= MAX_DAYS_IN_EIGHT_MONTHS) numberOfMonths += 8;
            else if (excessDays >= MAX_DAYS_IN_SEVEN_MONTHS) numberOfMonths += 7;
            else if (excessDays >= MAX_DAYS_IN_SIX_MONTHS) numberOfMonths += 6;
            else if (excessDays >= MAX_DAYS_IN_FIVE_MONTHS) numberOfMonths += 5;
            else if (excessDays >= MAX_DAYS_IN_FOUR_MONTHS) numberOfMonths += 4;
            else if (excessDays >= MAX_DAYS_IN_THREE_MONTHS) numberOfMonths += 3;
            else if (excessDays >= MAX_DAYS_IN_TWO_MONTHS) numberOfMonths += 2;
            else if (excessDays >= MAX_DAYS_IN_A_MONTH) numberOfMonths += 1;

            return numberOfMonths;
        }

        public static int MaxMonthsInDays(int numberOfDays)
        {
            if (numberOfDays < 0)
            {
                return -MinMonthsInDays(-numberOfDays);
            }

            int numberOfYears = numberOfDays / DAYS_IN_A_NON_LEAP_YEAR;
            int excessDays = numberOfDays % DAYS_IN_A_NON_LEAP_YEAR;
            int numberOfLeapYears = MinLeapYearsInYears(numberOfYears);

            if (excessDays < numberOfLeapYears)
            {
                numberOfYears -= 1;
                excessDays += DAYS_IN_A_NON_LEAP_YEAR;
                numberOfLeapYears = MinLeapYearsInYears(numberOfYears);
            }
            excessDays -= numberOfLeapYears;
            int numberOfMonths = numberOfYears * MONTHS_IN_A_YEAR;

            if (excessDays >= MIN_DAYS_IN_ELEVEN_MONTHS) numberOfMonths += 11;
            else if (excessDays >= MIN_DAYS_IN_TEN_MONTHS) numberOfMonths += 10;
            else if (excessDays >= MIN_DAYS_IN_NINE_MONTHS) numberOfMonths += 9;
            else if (excessDays >= MIN_DAYS_IN_EIGHT_MONTHS) numberOfMonths += 8;
            else if (excessDays >= MIN_DAYS_IN_SEVEN_MONTHS) numberOfMonths += 7;
            else if (excessDays >= MIN_DAYS_IN_SIX_MONTHS) numberOfMonths += 6;
            else if (excessDays >= MIN_DAYS_IN_FIVE_MONTHS) numberOfMonths += 5;
            else if (excessDays >= MIN_DAYS_IN_FOUR_MONTHS) numberOfMonths += 4;
            else if (excessDays >= MIN_DAYS_IN_THREE_MONTHS) numberOfMonths += 3;
            else if (excessDays >= MIN_DAYS_IN_TWO_MONTHS) numberOfMonths += 2;
            else if (excessDays >= MIN_DAYS_IN_A_MONTH) numberOfMonths += 1;

            return numberOfMonths;
        }

        public static int MinDaysInYears(int numberOfYears)
        {
            if (numberOfYears < 0)
            {
                return -MaxDaysInYears(-numberOfYears);
            }

            int numberOfLeapYears = MinLeapYearsInYears(numberOfYears);
            return numberOfYears * DAYS_IN_A_NON_LEAP_YEAR + numberOfLeapYears;
        }

        public static int MaxDaysInYears(int numberOfYears)
        {
            if (numberOfYears < 0)
            {
                return -MinDaysInYears(-numberOfYears);
            }

            int numberOfLeapYears = MaxLeapYearsInYears(numberOfYears);
            return numberOfYears * DAYS_IN_A_NON_LEAP_YEAR + numberOfLeapYears;
        }

        public static int MinYearsInDays(int numberOfDays)
        {
            if (numberOfDays < 0)
            {
                return -MaxYearsInDays(-numberOfDays);
            }

            int numberOfYears = numberOfDays / DAYS_IN_A_NON_LEAP_YEAR;
            int excessDays = numberOfDays % DAYS_IN_A_NON_LEAP_YEAR;
            int numberOfLeapYears = MaxLeapYearsInYears(numberOfYears);

            if (excessDays < numberOfLeapYears)
            {
                numberOfYears -= 1;
            }
            return numberOfYears;
        }

        public static int MaxYearsInDays(int numberOfDays)
        {
            if (numberOfDays < 0)
            {
                return -MinYearsInDays(-numberOfDays);
            }

            int numberOfYears = numberOfDays / DAYS_IN_A_NON_LEAP_YEAR;
            int excessDays = numberOfDays % DAYS_IN_A_NON_LEAP_YEAR;
            int numberOfLeapYears = MinLeapYearsInYears(numberOfYears);

            if (excessDays < numberOfLeapYears)
            {
                numberOfYears -= 1;
            }
            return numberOfYears;
        }

        public static int MinLeapYearsInYears(int numberOfYears)
        {
            int numberOfLeapYears = numberOfYears.Abs() / 4;
            numberOfLeapYears = numberOfLeapYears - ((numberOfLeapYears + 24) / 25) + (numberOfLeapYears / 100);
            return numberOfLeapYears;
        }


        public static int MaxLeapYearsInYears(int numberOfYears)
        {
            int numberOfLeapYears = (numberOfYears.Abs() + 3) / 4;
            numberOfLeapYears = numberOfLeapYears - (numberOfLeapYears / 25) + ((numberOfLeapYears + 75) / 100);
            return numberOfLeapYears;
        }
    }
}
