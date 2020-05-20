using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dates
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
