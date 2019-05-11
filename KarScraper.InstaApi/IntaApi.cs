//using AngleSharp;

//using AngleSharp.Parser.Html;
////using AngleSharp.Dom.Html;
////using AngleSharp.Parser.Html;
//using FbScraper.Model;
//using Newtonsoft.Json;
using FbScraper.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KarScraper.InstaApi
{



    public class IntaApi
    {
        private HttpClient _client;



        public IntaApi()
        {
            _client = new HttpClient();


        }//13262623138
        public async Task<string> GetPageAsync(string url)
        {
            string res = String.Empty;
            try
            {
             
                var httpResponse = await _client.GetAsync(url);
                var httpContent = await httpResponse.Content.ReadAsStringAsync();

                res = httpContent;
            }
            catch (HttpRequestException e)
            {
                res = e.ToString();
            }
            return res;
        }

        public async Task<InstaUser> GetUserInfoAsync(string pageString)
        {
            InstaUser user = new InstaUser();
            try
            {
                pageString = pageString.Remove(0, pageString.IndexOf("{\"user"));
                pageString = pageString.Remove(pageString.IndexOf(",\"connected_fb_page"));
                pageString += "}}";
                user=    await Task.Run(() => JsonConvert.DeserializeObject<InstaUser>(pageString));

            }
            catch (HttpRequestException e)
            {
                user = null;
            }

            return user;

        }

    }



}
