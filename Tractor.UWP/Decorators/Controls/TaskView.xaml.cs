using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Model;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.Command;
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
    public sealed partial class TaskView : UserControl
    {
        public static readonly DependencyProperty PresentedTaskProperty = DependencyProperty.Register(nameof(PresentedTask), typeof(ITask), typeof(TaskView), new PropertyMetadata(null));

        public event EventHandler<ICommand> CommandRequested;

        public ITask PresentedTask
        {
            get => (ITask)GetValue(PresentedTaskProperty);
            set => SetValue(PresentedTaskProperty, value);
        }

        public TaskView()
        {
            this.InitializeComponent();
        }

        private void b_AddDescription_Click(object sender, RoutedEventArgs e)
        {
            CommandRequested?.Invoke(this, null);
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 512)
            {
                VisualStateManager.GoToState(this, "WideView", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "NarrowView", true);
            }
        }

        private void tb_Name_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {

        }
    }
}
