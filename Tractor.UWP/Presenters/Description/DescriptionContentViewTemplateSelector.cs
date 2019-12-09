using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tractor.Core.Objects.Descriptions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Tractor.UWP.Presenters.Description
{
    public class DescriptionContentViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextDescriptionTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            switch (item)
            {
                case TextDescription _:
                    return TextDescriptionTemplate;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
