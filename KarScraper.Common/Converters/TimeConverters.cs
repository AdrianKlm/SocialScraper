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

        public static DateTime StringToDateTime (string dataStr)
        {
            DateTime tempDT = DateTime.MinValue;

            string y = dataStr.Substring(dataStr.Length - 4);
            string d = dataStr.Remove(dataStr.IndexOf(" "));

            string mstr = dataStr.Remove(dataStr.Length-5);
            mstr= mstr.Remove(0,dataStr.IndexOf(" "));


            var months = new Dictionary<string, int>()
            {
                {"stycznia", 1},
                {"lutego", 2},
                {"marca", 3},
                {"kwietnia", 4},
                {"maja", 5},
                {"czerwca", 6},
                {"lipca", 7},
                {"sierpnia", 8},
                {"września", 9},
                {"października", 10},
                {"listopada", 11},
                {"grudnia", 12},
            };
            months.TryGetValue(mstr.Trim(), out  int mInt);

            string end = y +"-"+ mInt.ToString() + "-" + d;
      
            tempDT = DateTime.Parse(end.Trim());

            return tempDT;
        }
    }
}
