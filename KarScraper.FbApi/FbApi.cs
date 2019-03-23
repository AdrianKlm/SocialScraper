using AngleSharp;
using AngleSharp.Html.Parser;
using FbScraper.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FbApi
{
    public class FbApi
    {
        private HttpClient _client;
        public FbApi()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.UserAgent.ParseAdd(
               //Html Data
               // "Mozilla/5.0 (PlayStation 4 5.03) AppleWebKit/601.2 (KHTML, like Gecko)");
               //json data
               "Mozilla/5.0 (Linux; Android 6.0.1; SM-G935S Build/MMB29K; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/55.0.2883.91 Mobile Safari/537.36");
        }


        /// <summary>
        /// Get FaceBook rating page
        /// </summary>
        /// <param name="url">Page url, must contain /.../reviews/ </param>
        /// <returns></returns>
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

        /// <summary>
        /// Get all rates
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<List<Rating>> GetRatesAsync(string page)
        {
            List<Rating> res = null;

            try
            {
                page = page.Remove(0, page.IndexOf("[{\""));
                page = page.Remove(page.IndexOf("}</script><link"));

                res = await Task.Run( ()=>  JsonConvert.DeserializeObject<List<Rating>>(page));
            
            }
            catch(Exception)
            {
                res = null;
            }
            return res;
      


            //var parser = new HtmlParser();
            //var document = await parser.ParseDocumentAsync(page);          
            //var blueListItemsLinq = document.All.Where(m => m.LocalName == "a" && m.ClassList.Contains("profileLink"));
           
            //foreach (var item in blueListItemsLinq)
            //    res += item.InnerHtml;

        }




    }
}









