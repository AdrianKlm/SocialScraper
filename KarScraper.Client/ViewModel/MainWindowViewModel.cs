using KarScraper.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarScraper.ViewModel
{
    public class MainWindowViewModel: PropertyChangedNotification
    {
        #region RelayCommands
        public RelayCommand NavPage1Command { get; private set; }
        public RelayCommand NavPage2Command { get; private set; }
        #endregion

        public object SelectedViewModel
        {
            get { return GetValue(() => SelectedViewModel); }
            set { SetValue(() => SelectedViewModel, value); }
        }

        public MainWindowViewModel()
        {
            NavPage1Command = new RelayCommand((e)=> SelectedViewModel = ViewModelLocator.FacebookScraperViewModel);
            NavPage2Command = new RelayCommand((e) => SelectedViewModel = ViewModelLocator.PageTwoViewModel);
        }

    }
}
