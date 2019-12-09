using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Objects.Descriptions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace Tractor.UWP.Decorators.Controls
{
    public sealed partial class DescriptionView : UserControl
    {
        public readonly static DependencyProperty PresentedDescriptionProperty = DependencyProperty.Register(nameof(PresentedDescription), typeof(IDescription), typeof(DescriptionView), new PropertyMetadata(null));

        public IDescription PresentedDescription
        {
            get => (IDescription)GetValue(PresentedDescriptionProperty);
            set => SetValue(PresentedDescriptionProperty, value);
        }

        public DescriptionView()
        {
            this.InitializeComponent();
        }
    }
}
