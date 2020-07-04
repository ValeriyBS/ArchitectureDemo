using System;

namespace Common.Dates
{
    public interface IDateTimeService
    {
        DateTime GetDateTimeUtc();

        DateTime UtcToLocal(DateTime dateTime);
    }
}
