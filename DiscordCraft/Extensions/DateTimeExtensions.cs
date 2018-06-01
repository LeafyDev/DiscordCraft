// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System;

namespace DiscordCraft.Extensions
{
    internal static class DateTimeExtensions
    {
        private static DateTimeFormatStrings English => new DateTimeFormatStrings
        {
            SecondAgo = "{0} second ago",
            SecondsAgo = "{0} seconds ago",
            MinuteAgo = "{0} minute ago",
            MinutesAgo = "{0} minutes ago",
            HourAgo = "{0} hour ago",
            HoursAgo = "{0} hours ago",
            DayAgo = "{0} day ago",
            DaysAgo = "{0} days ago",
            MonthAgo = "{0} month ago",
            MonthsAgo = "{0} months ago",
            YearAgo = "{0} year ago",
            YearsAgo = "{0} years ago"
        };

        public static string TimeAgo(this DateTime dateTime, DateTime relativeTo)
        {
            var timeSpan = relativeTo - dateTime;
            var dateTimeFormatStrings = English;
            if (timeSpan.Days > 365)
            {
                var years = timeSpan.Days / 365;
                if (timeSpan.Days % 365 != 0)
                    years += 1;
                return string.Format(years == 1 ? dateTimeFormatStrings.YearAgo : dateTimeFormatStrings.YearsAgo,
                    years);
            }

            if (timeSpan.Days > 30)
            {
                var months = timeSpan.Days / 30;
                if (timeSpan.Days % 31 != 0)
                    months += 1;
                return string.Format(months == 1 ? dateTimeFormatStrings.MonthAgo : dateTimeFormatStrings.MonthsAgo,
                    months);
            }

            if (timeSpan.Days > 0)
                return string.Format(timeSpan.Days == 1 ? dateTimeFormatStrings.DayAgo : dateTimeFormatStrings.DaysAgo,
                    timeSpan.Days);
            if (timeSpan.Hours > 0)
                return string.Format(
                    timeSpan.Hours == 1 ? dateTimeFormatStrings.HourAgo : dateTimeFormatStrings.HoursAgo,
                    timeSpan.Hours);
            if (timeSpan.Minutes > 0)
                return string.Format(
                    timeSpan.Minutes == 1 ? dateTimeFormatStrings.MinuteAgo : dateTimeFormatStrings.MinutesAgo,
                    timeSpan.Minutes);
            if (timeSpan.Seconds > 1 || timeSpan.Seconds == 0)
                return string.Format(dateTimeFormatStrings.SecondsAgo, timeSpan.Seconds);
            if (timeSpan.Seconds == 1)
                return string.Format(dateTimeFormatStrings.SecondAgo, timeSpan.Seconds);

            throw new NotSupportedException("The DateTime object does not have a supported value.");
        }
    }
}