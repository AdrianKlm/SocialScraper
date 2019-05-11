using FbScraper.Model;
using KarScraper.InstaApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbScraper.Test
{
    [TestClass]
    public class TestInstaAPI
    {

        [TestMethod]
        public async Task GetPageAsyncTest()
        {
            IntaApi instaApi = new IntaApi();
            string res = await instaApi.GetPageAsync("https://www.instagram.com/ffdsfs/");

            Assert.IsTrue(res.Length > 0 && res.Contains("zdjeciazkomorki"));
        }

        [TestMethod]
        public async Task GetUserInfoAsyncTest()
        {
            IntaApi instaApi = new IntaApi();
            string page = await instaApi.GetPageAsync("https://www.instagram.com/zdjeciazkomorki/");

            InstaUser user = new InstaUser();
            user = await instaApi.GetUserInfoAsync(page);

            Assert.IsTrue(user != null && user.user.id== "13262623138");
        }
    }
}
