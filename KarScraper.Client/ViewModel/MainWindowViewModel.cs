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

        public RelayCommand NewSearchCommand { get; private set; }
        public RelayCommand CompareCommand { get; private set; }
        #endregion

        #region Prop
        public ObservableCollection<BaseViewModelListModel> ViewModels { get; private set; }

        public object SelectedViewModel
        {
            get { return GetValue(() => SelectedViewModel); }
            set { SetValue(() => SelectedViewModel, value); }
        }
        #endregion

        public MainWindowViewModel()
        {
            NavigateToCommand = new RelayCommand((e)=> SelectedViewModel = (e as BaseViewModelListModel).ViewModel, (e)=> e is BaseViewModelListModel);
            DeleteViewModelCommand = new RelayCommand((e) => ViewModels.Remove(e as BaseViewModelListModel), (e) => e is BaseViewModelListModel);

            NewSearchCommand = new RelayCommand(NewSearchAction);
            CompareCommand = new RelayCommand(CompareAction, (e) => (ViewModels.Where(x => x.Checked).ToList().Count > 1));
            ViewModels = new ObservableCollection<BaseViewModelListModel>
            {
                new BaseViewModelListModel(){ViewModel = new Page1ViewModel()}
            };
        }

        private void NewSearchAction(object obj)
        {
            var temp = new ViewModel.Page1ViewModel();
            ViewModels.Add(new BaseViewModelListModel() { ViewModel = temp});
            SelectedViewModel = temp;
        }
        private void CompareAction(object obj) => SelectedViewModel = new ComparerViewModel(new List<BaseViewModelListModel>(ViewModels.Where(x => x.Checked)));
    }
}
