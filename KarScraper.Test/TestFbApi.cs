using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FbScraper.Model;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FbScraper.Test
{
    [TestClass]
    public class TestFbApi
    {
        [TestMethod]
        public async Task PageDownloadAsyncTest()
        {            
            FbApi.FbApi fbApi = new FbApi.FbApi();
            string res = await fbApi.GetPageAsync("https://www.facebook.com/pg/locale.warszawa/reviews/?ref=page_internal");            
            Assert.IsTrue(res.Length>0 && res.Contains("facebook"));
        }

        //[TestMethod]
        //public async Task TestPeopleDownloadAsync()
        //{
        //    FbApi.FbApi fbApi = new FbApi.FbApi();
        //    string page = await fbApi.GetPageAsync("https://www.facebook.com/pg/locale.warszawa/reviews/");
        //    List<Rating> res = await fbApi.GetRatesAsync(page);

        //    Assert.IsTrue(res.First().Author.Name.Length>0);
        //}
        [TestMethod]
        public async Task GetRatesAsyncV2AsyncTest()
        {
            FbApi.FbApi fbApi = new FbApi.FbApi();
            string page = await fbApi.GetPageAsync("https://www.facebook.com/pg/locale.warszawa/reviews/");

            List<Rating> res = await fbApi.GetRatesAsyncV2(page);

            //TODO
            Assert.IsTrue(res.First().Author.Name.Length > 0);
        }

        [TestMethod]
        public async Task GetPersonPageAsyncTest()
        {
            FbApi.FbApi fbApi = new FbApi.FbApi();
            string page = await fbApi.GetPageAsync("https://www.facebook.com/bartosz.maryjka/about");

            Assert.IsTrue(page.Contains("Maryjka"));
        }


        [TestMethod]
        public async Task GetPesronInfoAsyncTest()
        {
            FbApi.FbApi fbApi = new FbApi.FbApi();
            string page = await fbApi.GetPageAsync("https://www.facebook.com/bartosz.maryjka/about");

            //var author = await fbApi.GetAuthorAsync(page);

        }


    

    }
}
