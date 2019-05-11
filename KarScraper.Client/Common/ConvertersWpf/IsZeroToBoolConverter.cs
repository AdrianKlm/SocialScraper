using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KarScraper.Common.ConvertersWpf
{
    public class IsZeroToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isenable = false;
            if (!Int32.TryParse(value.ToString(), out int valueInt) || valueInt == 0)
            {
                isenable = true;
            }
            return isenable;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
