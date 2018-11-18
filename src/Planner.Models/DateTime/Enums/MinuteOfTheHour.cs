using System;

namespace Planner.Models.DateTime
{
    public enum MinuteOfTheHour
    {
        Minute00 = 0,
        Minute01 = 1,
        Minute02 = 2,
        Minute03 = 3,
        Minute04 = 4,
        Minute05 = 5,
        Minute06 = 6,
        Minute07 = 7,
        Minute08 = 8,
        Minute09 = 9,
        Minute10 = 10,
        Minute11 = 11,
        Minute12 = 12,
        Minute13 = 13,
        Minute14 = 14,
        Minute15 = 15,
        Minute16 = 16,
        Minute17 = 17,
        Minute18 = 18,
        Minute19 = 19,
        Minute20 = 20,
        Minute21 = 21,
        Minute22 = 22,
        Minute23 = 23,
        Minute24 = 24,
        Minute25 = 25,
        Minute26 = 26,
        Minute27 = 27,
        Minute28 = 28,
        Minute29 = 29,
        Minute30 = 30,
        Minute31 = 31,
        Minute32 = 32,
        Minute33 = 33,
        Minute34 = 34,
        Minute35 = 35,
        Minute36 = 36,
        Minute37 = 37,
        Minute38 = 38,
        Minute39 = 39,
        Minute40 = 40,
        Minute41 = 41,
        Minute42 = 42,
        Minute43 = 43,
        Minute44 = 44,
        Minute45 = 45,
        Minute46 = 46,
        Minute47 = 47,
        Minute48 = 48,
        Minute49 = 49,
        Minute50 = 50,
        Minute51 = 51,
        Minute52 = 52,
        Minute53 = 53,
        Minute54 = 54,
        Minute55 = 55,
        Minute56 = 56,
        Minute57 = 57,
        Minute58 = 58,
        Minute59 = 59,
    }

    public static class MinuteOfTheHourEx
    {
        public static int ToInt(this MinuteOfTheHour minuteOfTheHour)
        {
            return (int)minuteOfTheHour;
        }

        public static MinuteOfTheHour FromInt(int i)
        {
            if (i > 59 || i < 0) throw new ArgumentException($"Invalid minute of the hour: {i}");
            return (MinuteOfTheHour)i;
        }

        public static string ToString(this MinuteOfTheHour minuteOfTheHour)
        {
            int numeral = minuteOfTheHour.ToInt();

            return $"{numeral} minutes past";
        }
    }
}
