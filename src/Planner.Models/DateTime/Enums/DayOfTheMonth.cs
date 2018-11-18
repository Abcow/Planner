using System;

namespace Planner.Models.DateTime
{
    public enum DayOfTheMonth
    {
        Day01 = 0,
        Day02 = 1,
        Day03 = 2,
        Day04 = 3,
        Day05 = 4,
        Day06 = 5,
        Day07 = 6,
        Day08 = 7,
        Day09 = 8,
        Day10 = 9,
        Day11 = 10,
        Day12 = 11,
        Day13 = 12,
        Day14 = 13,
        Day15 = 14,
        Day16 = 15,
        Day17 = 16,
        Day18 = 17,
        Day19 = 18,
        Day20 = 19,
        Day21 = 20,
        Day22 = 21,
        Day23 = 22,
        Day24 = 23,
        Day25 = 24,
        Day26 = 25,
        Day27 = 26,
        Day28 = 27,
        Day29 = 28,
        Day30 = 29,
        Day31 = 30
    }

    public static class DayOfTheMonthEx
    {
        public static int ToInt(this DayOfTheMonth dayOfTheMonth)
        {
            return (int)dayOfTheMonth + 1;
        }

        public static DayOfTheMonth FromInt(int i)
        {
            if (i > 31 || i < 1) throw new ArgumentException($"Invalid day of the month: {i}");
            return (DayOfTheMonth)(i - 1);
        }

        public static string ToString(this DayOfTheMonth dayOfTheMonth)
        {
            int numeral = dayOfTheMonth.ToInt();
            string suffix;

            if (numeral % 10 == 1)
            {
                suffix = "st";
            }
            else if (numeral % 10 == 2)
            {
                suffix = "nd";
            }
            else if (numeral % 10 == 3)
            {
                suffix = "rd";
            }
            else
            {
                suffix = "th";
            }
            return $"{numeral}{suffix}";
        }
    }
}
