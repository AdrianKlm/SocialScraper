using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbScraper.Model
{
    public class Rating
    {
        public string Type { get; set; }
        public int DatePublished { get; set; }
        public DateTime DatePublishedDt
        {
            get =>  Common.Converters.TimeConverters.UnixTimeStampToDateTime((int)DatePublished);           
        }
        public string Description { get; set; }
        public ReviewRating ReviewRating { get; set; }
        public Author Author { get; set; }
    }
}
