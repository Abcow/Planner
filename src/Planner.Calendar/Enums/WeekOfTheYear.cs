using System;

namespace Planner.Calendar
{
    public enum WeekOfTheYear
    {
        Week01 = 0,
        Week02 = 1,
        Week03 = 2,
        Week04 = 3,
        Week05 = 4,
        Week06 = 5,
        Week07 = 6,
        Week08 = 7,
        Week09 = 8,
        Week10 = 9,
        Week11 = 10,
        Week12 = 11,
        Week13 = 12,
        Week14 = 13,
        Week15 = 14,
        Week16 = 15,
        Week17 = 16,
        Week18 = 17,
        Week19 = 18,
        Week20 = 19,
        Week21 = 20,
        Week22 = 21,
        Week23 = 22,
        Week24 = 23,
        Week25 = 24,
        Week26 = 25,
        Week27 = 26,
        Week28 = 27,
        Week29 = 28,
        Week30 = 29,
        Week31 = 30,
        Week32 = 31,
        Week33 = 32,
        Week34 = 33,
        Week35 = 34,
        Week36 = 35,
        Week37 = 36,
        Week38 = 37,
        Week39 = 38,
        Week40 = 39,
        Week41 = 40,
        Week42 = 41,
        Week43 = 42,
        Week44 = 43,
        Week45 = 44,
        Week46 = 45,
        Week47 = 46,
        Week48 = 47,
        Week49 = 48,
        Week50 = 49,
        Week51 = 50,
        Week52 = 51,
        Week53 = 52
    }

    public static class WeekOfTheYearEx
    {
        public static int ToInt(this WeekOfTheYear weekOfTheYear)
        {
            return (int)weekOfTheYear + 1;
        }

        public static WeekOfTheYear FromInt(int i)
        {
            if (i > 53 || i < 1) throw new ArgumentException($"Invalid week of the year: {i}");
            return (WeekOfTheYear)(i - 1);
        }

        public static string ToString(this WeekOfTheYear weekOfTheYear)
        {
            int numeral = weekOfTheYear.ToInt();

            return $"Week {numeral}";
        }
    }
}
