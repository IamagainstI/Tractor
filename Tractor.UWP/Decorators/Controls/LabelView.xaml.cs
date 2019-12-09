using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Objects.Descriptions.Labels;
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
    public sealed partial class LabelView : UserControl
    {
        public readonly static DependencyProperty PresentedLabelProperty = DependencyProperty.Register(nameof(PresentedLabel), typeof(ILabel), typeof(LabelView), new PropertyMetadata(null));

        public ILabel PresentedLabel
        {
            get => (ILabel)GetValue(PresentedLabelProperty);
            set => SetValue(PresentedLabelProperty, value);
        }

        public LabelView()
        {
            this.InitializeComponent();
        }
    }
}
