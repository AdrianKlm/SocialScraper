using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbScraper.Test
{
    [TestClass]
    public class TestFbUriGenerator
    {        

        [TestMethod]
        public void ControlTest()
        {
            string url = "https://www.facebook.com/locale.warszawa/reviews/";
            string generatedUrl = Common.Generator.FbUriGenerator.Generate(url);

            Assert.IsTrue(generatedUrl == "https://www.facebook.com/locale.warszawa/reviews/");
        }
        [TestMethod]
        public void WithOutLink()
        {
            string url = "locale.warszawa/reviews/";
            string generatedUrl = Common.Generator.FbUriGenerator.Generate(url);
            Assert.IsTrue(generatedUrl == "https://www.facebook.com/locale.warszawa/reviews/");
        }
        [TestMethod]
        public void WrongLink()
        {
            string url = "facebook.com/locale.warszawa/reviews/";
            string generatedUrl = Common.Generator.FbUriGenerator.Generate(url);
            Assert.IsTrue(generatedUrl == "https://www.facebook.com/locale.warszawa/reviews/");
        }

        [TestMethod]
        public void LongLink()
        {
            string url = "facebook.com/locale.warszawa/reviews/fsdfsdfdsf5645654645hgfhfg";
            string generatedUrl = Common.Generator.FbUriGenerator.Generate(url);
            Assert.IsTrue(generatedUrl == "https://www.facebook.com/locale.warszawa/reviews/");
        }
        [TestMethod]
        public void PgLongLink()
        {
            string url = "https://www.facebook.com/pg/locale.warszawa/reviews/gfdgdggdfgfdgfd";
            string generatedUrl = Common.Generator.FbUriGenerator.Generate(url);
            Assert.IsTrue(generatedUrl == "https://www.facebook.com/locale.warszawa/reviews/");
        }
        [TestMethod]
        public void FromName()
        {
            string url = "locale.warszawa";
            string generatedUrl = Common.Generator.FbUriGenerator.Generate(url);
            Assert.IsTrue(generatedUrl == "https://www.facebook.com/locale.warszawa/reviews/");
        }
    }
 }
