using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Objects.Progress;
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
    public sealed partial class ProgressControl : UserControl
    {
        public static readonly DependencyProperty PresentedProgressProperty = DependencyProperty.Register(nameof(PresentedProgress), typeof(IProgress), typeof(TaskView), new PropertyMetadata(null));

        public IProgress PresentedProgress
        {
            get => (IProgress)GetValue(PresentedProgressProperty);
            set => SetValue(PresentedProgressProperty, value);
        }
        public ProgressControl()
        {
            this.InitializeComponent();
        }
    }
}
