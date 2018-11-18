using System;

namespace Planner.Models.DateTime
{
    public enum MonthOfTheYear
    {
        January   =  0,
        Feburay   =  1,
        March     =  2,
        April     =  3,
        May       =  4,
        June      =  5,
        July      =  6,
        August    =  7,
        September =  8,
        October   =  9,
        November  = 10,
        December  = 11
    }

    public static class MonthOfTheYearEx
    {
        public static int ToInt(this MonthOfTheYear monthOfTheYear)
        {
            return (int)monthOfTheYear + 1;
        }

        public static MonthOfTheYear FromInt(int i)
        {
            if (i > 12 || i < 1) throw new ArgumentException($"Invalid month of the year: {i}");
            return (MonthOfTheYear)(i - 1);
        }
    }
}
