using System;

namespace Common.Dates
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetDateTimeUtc()
        {
            return DateTime.UtcNow;
        }

        public DateTime UtcToLocal(DateTime dateTime)
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc).ToLocalTime();
        }
    }
}