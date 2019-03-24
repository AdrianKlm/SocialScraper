using KarScraper.Common;
using System.Windows.Controls;

namespace KarScraper
{
    public partial class Page1View : UserControl
    {
        public Page1View() => InitializeComponent();

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) (this.DataContext as IBaseViewModel).Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) (this.DataContext as IBaseViewModel).Errors -= 1;
        }
    }
}
