using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Tractor.UWP.Presenters
{
    public class ColorConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value switch
            {
                System.Drawing.Color system => Windows.UI.Color.FromArgb(system.A, system.R, system.G, system.B),
                Windows.UI.Color uwp => uwp,
                _ => throw new ArgumentException(),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value switch
            {
                System.Drawing.Color system => system,
                Windows.UI.Color uwp => System.Drawing.Color.FromArgb(uwp.A, uwp.R, uwp.G, uwp.B),
                _ => throw new ArgumentException(),
            };
        }
    }
}
