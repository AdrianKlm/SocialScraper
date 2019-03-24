using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarScraper.Common;

namespace KarScraper.Model
{
    public class FbScraper: PropertyChangedNotification
    {
        [Required(ErrorMessage ="Pole wymagane")]
        public string UriSource
        {
            get { return GetValue(() => UriSource); }
            set { SetValue(() => UriSource, value); }
        }
    }
}
