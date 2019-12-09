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
    public class DescriptionViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NullDescriptionTemplate { get; set; }
        public DataTemplate DescriptionTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            switch (item)
            {
                case IDescription _:
                    return DescriptionTemplate;
                case null:
                    return NullDescriptionTemplate;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
