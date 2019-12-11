using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Tractor.UWP.Presenters
{
    class DateConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value switch
            {
                System.DateTime _ => DateTime.Now.ToString("MM/dd/yyyy"),
                _ => throw new ArgumentException(),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
