using System;

namespace Project.Hub.Utils
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Convert time to specific offset which is based on timezone name.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="systemTimeZone"></param>
        /// <returns></returns>
        public static DateTimeOffset ConvertToTimeZone(this DateTimeOffset date, string systemTimeZone)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(systemTimeZone);
            var offset = timeZone.GetUtcOffset(date);
            return date.ToOffset(offset);
        }
    }
}
