using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tractor.Core.Objects.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Tractor.UWP.Decorators.Tasks
{
    public sealed class TaskViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ITaskTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            switch (item)
            {
                case ITask _:
                    return ITaskTemplate;
                default:
                    return null;
            }
        }
    }
}
