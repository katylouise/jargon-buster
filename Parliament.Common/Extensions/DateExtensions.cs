
using System;
using System.Collections;
using System.Diagnostics;

namespace Parliament.Common.Extensions
{
    public static class DateExtensions
    {
        [DebuggerStepThrough]
        public static DateTime StartOfMonth(this DateTime selectedDate)
        {
            return new DateTime(selectedDate.Year, selectedDate.Month, 1);
        }

        [DebuggerStepThrough]
        public static DateTime EndOfMonth(this DateTime selectedDate)
        {
            return new DateTime(selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month)).AddDays(1).AddMilliseconds(-1);
        }

        [DebuggerStepThrough]
        public static void ForEachDay(this DateTime start, DateTime end, Action<DateTime> action)
        {
            for (var date = start; date.Date <= end.Date; date = date.AddDays(1))
            {
                action(date);
            }
        }

        [DebuggerStepThrough]
        public static bool IsWeekend(this DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday);
        }

        [DebuggerStepThrough]
        public static DateTime StartOfWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            var diff = date.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return date.AddDays(-1 * diff).Date;
        }

        [DebuggerStepThrough]
        public static DateTime EndOfWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            return date.StartOfWeek(startOfWeek).AddDays(7).AddMilliseconds(-1);
        }

        [DebuggerStepThrough]
        public static string ToJavaScriptSafeShortDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
