﻿using System;

namespace Location.TModel.Tools
{
    public static class TimeConvert
    {
        public static long ToStamp(this DateTime dt)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970,1,1));
            long timeStamp = (long)(dt.Ticks - startTime.Ticks)/10000;
            return timeStamp;
        }


        public static DateTime ToDateTime(this long timeStamp,bool isSencond=false)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            if (isSencond == false)
            {
                DateTime dt = startTime.AddMilliseconds(timeStamp);
                return dt;
            }
            else
            {
                DateTime dt = startTime.AddSeconds(timeStamp);
                return dt;
            }
            
        }
    }
}
