using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbScraper.Common.Converters
{
    public static class TimeConverters
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        { 
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);      
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}
