using FbApi;
using FbScraper.Common.Generator;
using FbScraper.Model;
using KarScraper.Common;
using KarScraper.InstaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KarScraper.ViewModel
{
    public class Page1ViewModel: PropertyChangedNotification,  IBaseViewModel
    {
        #region Commands
        public RelayCommand DownloadCommand { get; private set; }
        public RelayCommand OpenFbCommand { get; private set; }
        public RelayCommand OpenInstaCommand { get; private set; }

        #endregion

        #region Viewodel prop
        public List<Rating> SrapedRatesList { get { return GetValue(() => SrapedRatesList); } set { SetValue(() => SrapedRatesList, value); } }

        public Model.FbScraper NewFaceBookScraper { get; private set; }

        public bool PrograssBarIsIndeterminate { get { return GetValue(() => PrograssBarIsIndeterminate); } set { SetValue(() => PrograssBarIsIndeterminate, value); } }

        public bool StatsVisibility { get {  return GetValue(() => StatsVisibility); ; } set { SetValue(() => StatsVisibility, value); } }

        public  Statistic Statistic { get { return GetValue(() => Statistic); ; } set { SetValue(() => Statistic, value); } }


        public int Errors { get; set; }
        public string Content { get { return GetValue(() =>Content); ; } set { SetValue(() => Content, value); } }
        #endregion

        private readonly FbApi.FbApi _fbApi;
        private readonly IntaApi _instaApi;

        public Page1ViewModel()
        {      
            _fbApi = new FbApi.FbApi();
            _instaApi = new IntaApi();
            Statistic = new Statistic();
            Content = "Wyszukiwanie";
            PrograssBarIsIndeterminate = false;
            StatsVisibility = false;
            NewFaceBookScraper = new Model.FbScraper() { UriSource = "https://www.facebook.com/pg/locale.warszawa/reviews/" };
            SrapedRatesList = new List<Rating>();
            DownloadCommand = new RelayCommand(Download, (e) => Errors == 0);
            OpenFbCommand = new RelayCommand((e) => { System.Diagnostics.Process.Start("https://www.facebook.com/" + (e as Rating).Author.Login); });
            OpenInstaCommand = new RelayCommand((e) => { System.Diagnostics.Process.Start("https://www.instagram.com/" + (e as Rating).Author.Login); });
        }



        private async void Download(object obj)
        {
            var _temp = new List<Rating>();

            try
            {
                SrapedRatesList = new List<Rating>();
                PrograssBarIsIndeterminate = true;
                StatsVisibility = false;

                NewFaceBookScraper.BussinesName = FbUriGenerator.ExtractName(NewFaceBookScraper.UriSource);
                Content = NewFaceBookScraper.BussinesName;

                NewFaceBookScraper.UriSource = FbUriGenerator.Generate(NewFaceBookScraper.UriSource);

                string page = await _fbApi.GetPageAsync(NewFaceBookScraper.UriSource);

                _temp = await _fbApi.GetRatesAsyncV2(page);

                //foreach (var item in _temp)
                //{
                //    string instaPage = await _instaApi.GetPageAsync("https://www.instagram.com/" + item.Author.Login);
                //    if (!instaPage.Contains("Sorry, this page"))
                //    {
                //        item.InstaUser = await _instaApi.GetUserInfoAsync(instaPage);
                //    }
                //}
                SrapedRatesList = _temp;
                PrograssBarIsIndeterminate = false;
                StatsVisibility = true;
                Statistic = GenerateStatistic(_temp);
            }
            catch(Exception ex)
            {               
                NewFaceBookScraper.UriSource = "";
                MessageBox.Show(ex.Message);
                PrograssBarIsIndeterminate = false;
                StatsVisibility = false;
            }
            finally
            {
            
            }
        }

        private Statistic GenerateStatistic(List<Rating> rateslist)
        {
            return new Statistic()
            {
                NumberOfRates= rateslist.Count,
                AverageRates = rateslist.Select(x => x.ReviewRating.RatingValue).Average(),
                NumberOfFemale = rateslist.Where(x => x.Author.Sex == 'K').Count(),
                NumberOfMan = rateslist.Where(x => x.Author.Sex == 'M').Count(),
                NumberOfIgAccount = rateslist.Where(x => x.InstaUser != null).Count(),
                BussinesName = NewFaceBookScraper.BussinesName//TODO
                //NumberOfInAccount = rateslist.Select(x => Int64.Parse(x.InstaUser.user?.id) > 10).Count()


            };
        }

    }
}


