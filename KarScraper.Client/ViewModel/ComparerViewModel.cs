using FbScraper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarScraper.ViewModel
{
    public class ComparerViewModel
    {

        public ObservableCollection<Statistic> CompareList { get; private set; }

        public ComparerViewModel(List<BaseViewModelListModel> vmList)
        {
            CompareList = new ObservableCollection<Statistic>();

            foreach (var item in vmList)
            {
                CompareList.Add(item.ViewModel.Statistic);
            }
        }
    }


  
}
