using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarScraper.ViewModel
{
    public static class ViewModelLocator
    {
        public static ViewModel.Page1ViewModel FacebookScraperViewModel
        {
            get
            {
                if (_facebookScraperViewModel == null)
                    _facebookScraperViewModel = new Page1ViewModel();
                return _facebookScraperViewModel;
            }
        }
        private static ViewModel.Page1ViewModel _facebookScraperViewModel;

        public static ViewModel.Page2ViewModel PageTwoViewModel
        {
            get
            {
                if (_pageTwoViewModel == null)
                    _pageTwoViewModel = new Page2ViewModel();
                return _pageTwoViewModel;
            }
        }
        private static ViewModel.Page2ViewModel _pageTwoViewModel;
    }
}
