using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbScraper.Common.Generator
{
    public static class FbUriGenerator
    {
        public static string Generate(string url)
        {
            try
            {
                url = ExtractName(url);
                url = AddFbUrl(url);
                url = AddReviews(url);
            }
            catch(Exception)
            {
                throw new Exception("Url generate exception");
            }
            return url;
        }
        public static string ExtractName(string url)
        {
            if (url.Contains(".com/pg/"))
            {
                url = url.Remove(0,url.IndexOf(".com/pg/") + 8);
                url = url.Remove(url.IndexOf("/"));
            }
            else if (url.Contains(".com/"))
            {
                url = url.Remove(0, url.IndexOf(".com/") + 5);
                url = url.Remove(url.IndexOf("/"));
            }
            else if(url.Contains("/reviews"))
            {
                url= url.Remove(url.IndexOf("/"));
            }

            return url;
        }
        private static string ClearUrl(string url) => url = url.Remove(url.IndexOf("/reviews/") + 8)+"/";

        private static string AddFbUrl(string url) => "https://www.facebook.com/" + url;

        private static string AddReviews(string url) => url += "/reviews/";
    }
}
