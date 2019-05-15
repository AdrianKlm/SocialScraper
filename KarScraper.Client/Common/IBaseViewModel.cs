using FbScraper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarScraper.Common
{
    public interface IBaseViewModel 
    {
        List<Rating> SrapedRatesList { get; set; }
        Statistic Statistic { get; set; }
        int Errors { get; set; }
        string Content { get; set; }
    }
}
