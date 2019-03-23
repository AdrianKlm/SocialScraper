using KarScraper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FbScraper.Model;

namespace KarScraper.ViewModel
{
    public class Page1ViewModel : PropertyChangedNotification
    {
        public RelayCommand PobierzCommand { get; private set; }

        public List<Rating> SrapedRatesList
        {
            get { return GetValue(() => SrapedRatesList); }
            set { SetValue(() => SrapedRatesList, value); }
        }

        public Model.FacebookScraper NewFaceBookScraper { get; set; }
        public int Errors { get; set; }

        private readonly FbApi.FbApi _fbApi;

        public Page1ViewModel()
        {
            _fbApi = new FbApi.FbApi();

            NewFaceBookScraper = new Model.FacebookScraper() {UriSource= "https://www.facebook.com/pg/locale.warszawa/reviews/" };
            SrapedRatesList = new List<Rating>();
            PobierzCommand = new RelayCommand(Pobierz, (e) => Errors == 0);
        }

        private async void Pobierz(object obj)
        {
            string page = await _fbApi.GetPageAsync(NewFaceBookScraper.UriSource);
            SrapedRatesList = await _fbApi.GetRatesAsync(page);
        }

    }
}


