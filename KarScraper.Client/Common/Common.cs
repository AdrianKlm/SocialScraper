using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KarScraper
{
    public class CommonHelpers
    {
        public static void Validation_ErrorCommon(object sender, ValidationErrorEventArgs e)
        {
            dynamic dt = (sender as FrameworkElement).DataContext;
            if (e.Action == ValidationErrorEventAction.Added) dt.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) dt.Errors -= 1;
        }
    }
}
