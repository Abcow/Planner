using System;

namespace Planner.Models.DateTime
{
    public enum HourOfTheDay
    {
        Hour00 = 0,
        Hour01 = 1,
        Hour02 = 2,
        Hour03 = 3,
        Hour04 = 4,
        Hour05 = 5,
        Hour06 = 6,
        Hour07 = 7,
        Hour08 = 8,
        Hour09 = 9,
        Hour10 = 10,
        Hour11 = 11,
        Hour12 = 12,
        Hour13 = 13,
        Hour14 = 14,
        Hour15 = 15,
        Hour16 = 16,
        Hour17 = 17,
        Hour18 = 18,
        Hour19 = 19,
        Hour20 = 20,
        Hour21 = 21,
        Hour22 = 22,
        Hour23 = 23,
    }

    public static class HourOfTheDayEx
    {
        public static int ToInt(this HourOfTheDay hourOfTheDay)
        {
            return (int)hourOfTheDay;
        }

        public static HourOfTheDay FromInt(int i)
        {
            if (i > 23 || i < 0) throw new ArgumentException($"Invalid hour of the day: {i}");
            return (HourOfTheDay)i;
        }

        public static string ToString(this HourOfTheDay hourOfTheDay)
        {
            int numeral = hourOfTheDay.ToInt();

            if (DateTimeScheme.TwentyFourHourTime)
            {
                return $"{numeral:D2}:00";
            }

            if (numeral < 12)
            {
                if (numeral == 0) numeral = 12;

                return $"{numeral:D2}:00 AM";
            }
            else
            {
                if (numeral != 12) numeral -= 12;

                return $"{numeral:D2}:00 PM";
            }
        }
    }
}
