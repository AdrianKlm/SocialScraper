﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbScraper.Model
{
    public class Rating
    {
        public int Lp { get; set; }
        public int DatePublished { get; set; }
        public string DatePublishedStr { get; set; }
        public DateTime DatePublishedDt
        {
            get => Common.Converters.TimeConverters.StringToDateTime(DatePublishedStr);     
        }
        public string Description { get; set; }
        public ReviewRating ReviewRating { get; set; }
        public Author Author { get; set; }

        public InstaUser InstaUser { get; set; }
    }
}
