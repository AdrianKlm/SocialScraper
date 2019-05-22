using KarScraper.Common;

namespace KarScraper
{
    public class BaseViewModelListModel
    {
        public IBaseViewModel ViewModel { get; set; }
        public bool Checked { get; set; }
    }
}
