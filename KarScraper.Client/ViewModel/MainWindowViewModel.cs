using KarScraper.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarScraper.ViewModel
{
    public class MainWindowViewModel: PropertyChangedNotification
    {
        #region RelayCommands
        public RelayCommand NavigateToCommand { get; private set; }
        public RelayCommand DeleteViewModelCommand { get; private set; }

        public RelayCommand NewViewModelCommand { get; private set; }
        public RelayCommand CompareCommand { get; private set; }

        #endregion

        public object SelectedViewModel
        {
            get { return GetValue(() => SelectedViewModel); }
            set { SetValue(() => SelectedViewModel, value); }
        }

        public ObservableCollection<BaseViewModelListModel> ViewModels { get; private set; }

        public MainWindowViewModel()
        {
            NavigateToCommand = new RelayCommand((e)=> SelectedViewModel = (e as BaseViewModelListModel).ViewModel, (e)=> e is BaseViewModelListModel);
            DeleteViewModelCommand = new RelayCommand((e) => ViewModels.Remove(e as BaseViewModelListModel), (e) => e is BaseViewModelListModel);

            NewViewModelCommand = new RelayCommand(NewViewModelAction);
            CompareCommand = new RelayCommand(CompareAction);
            //, (e)=>(ViewModels.Select(x=>x.Checked).Count==2)
            ViewModels = new ObservableCollection<BaseViewModelListModel>
            {
                new BaseViewModelListModel(){ViewModel = new Page1ViewModel()}
            };
            //NavPage1Command = new RelayCommand((e)=> SelectedViewModel = ViewModelLocator.FacebookScraperViewModel);
            //NavPage2Command = new RelayCommand((e) => SelectedViewModel = ViewModelLocator.PageTwoViewModel);
        }
        private void NewViewModelAction(object obj)
        {
            var temp = new ViewModel.Page1ViewModel();
            ViewModels.Add(new BaseViewModelListModel() { ViewModel = temp});
            //SelectedViewModel = temp;
        }

        private void CompareAction(object obj)
        {
            SelectedViewModel = new ComparerViewModel(new List<BaseViewModelListModel>(ViewModels.Where(x => x.Checked)));
        }
    }
    public class BaseViewModelListModel
    {
        public IBaseViewModel ViewModel { get;  set; }
        public bool Checked { get; set; }
    }
}
