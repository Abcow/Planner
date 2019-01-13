using Planner.Framework;
using System;
using System.ComponentModel;

namespace Planner.Calendar
{
    public enum DayOfTheWeek
    {
        Thursday  = 0,
        Friday    = 1,
        Saturday  = 2,
        Sunday    = 3,
        Monday    = 4,
        Tuesday   = 5,
        Wednesday = 6
    }

    public static class DayOfTheWeekEx
    {
        public static int ToInt(this DayOfTheWeek dayOfTheWeek)
        {
            int dayIndex = (int)dayOfTheWeek - (int)CalendarScheme.FirstDayOfTheWeek;
            dayIndex = dayIndex.DMod(7);
            return dayIndex + 1;
        }

        public static DayOfTheWeek FromInt(int i)
        {
            if (i > 7 || i < 1) throw new ArgumentException($"Invalid day of the week: {i}");
            int dayIndex = (int)CalendarScheme.FirstDayOfTheWeek + i - 1;
            dayIndex = dayIndex.DMod(7);
            return (DayOfTheWeek)dayIndex;
        }

        public static DayOfTheWeek FromDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return DayOfTheWeek.Monday;
                case DayOfWeek.Tuesday:
                    return DayOfTheWeek.Tuesday;
                case DayOfWeek.Wednesday:
                    return DayOfTheWeek.Wednesday;
                case DayOfWeek.Thursday:
                    return DayOfTheWeek.Thursday;
                case DayOfWeek.Friday:
                    return DayOfTheWeek.Friday;
                case DayOfWeek.Saturday:
                    return DayOfTheWeek.Saturday;
                case DayOfWeek.Sunday:
                    return DayOfTheWeek.Sunday;
                default:
                    throw new InvalidEnumArgumentException(nameof(dayOfWeek), (int)dayOfWeek, dayOfWeek.GetType());
            }
        }

        public static DayOfWeek ToDayOfWeek(this DayOfTheWeek dayOfTheWeek)
        {
            switch (dayOfTheWeek)
            {
                case DayOfTheWeek.Monday:
                    return DayOfWeek.Monday;
                case DayOfTheWeek.Tuesday:
                    return DayOfWeek.Tuesday;
                case DayOfTheWeek.Wednesday:
                    return DayOfWeek.Wednesday;
                case DayOfTheWeek.Thursday:
                    return DayOfWeek.Thursday;
                case DayOfTheWeek.Friday:
                    return DayOfWeek.Friday;
                case DayOfTheWeek.Saturday:
                    return DayOfWeek.Saturday;
                case DayOfTheWeek.Sunday:
                    return DayOfWeek.Sunday;
                default:
                    throw new InvalidEnumArgumentException(nameof(dayOfTheWeek), (int)dayOfTheWeek, dayOfTheWeek.GetType());
            }
        }
    }
}
