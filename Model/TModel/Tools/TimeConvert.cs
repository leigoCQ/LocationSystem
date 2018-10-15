﻿using System;

namespace Location.TModel.Tools
{
    public static class TimeConvert
    {
        public static long DateTimeToTimeStamp(DateTime dt)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970,1,1));
            long timeStamp = (long)(dt.Ticks - startTime.Ticks)/10000000;
            return timeStamp;
        }

        public static DateTime TimeStampToDateTime(long timeStamp)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            DateTime dt = startTime.AddSeconds(timeStamp);
            return dt;
        }
    }
}
