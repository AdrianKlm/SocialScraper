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
        public ObservableCollection<Rating> MatchedList { get; private set; }



        public ComparerViewModel(List<BaseViewModelListModel> vmList)//vmList - All searchs
        {
            CompareList = new ObservableCollection<Statistic>();
            List<Rating> temp = new List<Rating>();

            vmList.ForEach(x => CompareList.Add(x.ViewModel.Statistic));//Get statistic from all searchs       

            vmList.ForEach(y => y.ViewModel.SrapedRatesList.ForEach(x => temp.Add(x)));//generate rates list from all search
            //var aff = temp.FirstOrDefault(x => x.Author.Login.Contains("v"));
            //temp.Add(aff);

            var temp2 = temp.GroupBy(x => x.Author).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
            temp = temp.Where(x => x.Author == temp2.FirstOrDefault(y => y == x.Author)).Distinct().ToList();

            MatchedList = new ObservableCollection<Rating>(temp);


        }
    }
}
