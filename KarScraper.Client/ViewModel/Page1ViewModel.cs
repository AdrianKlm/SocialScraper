using FbApi;
using FbScraper.Model;
using KarScraper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KarScraper.ViewModel
{
    public class Page1ViewModel : PropertyChangedNotification, IBaseViewModel
    {
        #region Commands
        public RelayCommand DownloadCommand { get; private set; }
        public RelayCommand OpenLinkCommand { get; private set; }
        #endregion

        #region Viewodel prop
        public List<Rating> SrapedRatesList{ get { return GetValue(() => SrapedRatesList); } set { SetValue(() => SrapedRatesList, value); } }

        public Model.FbScraper NewFaceBookScraper { get; set; }

        public int Errors { get; set; }
        #endregion

        private readonly FbApi.FbApi _fbApi;

        public Page1ViewModel()
        {
            _fbApi = new FbApi.FbApi();

            NewFaceBookScraper = new Model.FbScraper() {UriSource= "https://www.facebook.com/pg/locale.warszawa/reviews/" };
            SrapedRatesList = new List<Rating>();
            DownloadCommand = new RelayCommand(Download, (e) => Errors == 0);
            OpenLinkCommand = new RelayCommand(OpenLink);
        }

        private void OpenLink(object obj)
        {

        }

        private async void Download(object obj)
        {
            string page = await _fbApi.GetPageAsync(NewFaceBookScraper.UriSource);
            SrapedRatesList = await _fbApi.GetRatesAsyncV2(page);
        }

    }
}


