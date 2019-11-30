using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Model;
using Tractor.Core.Objects.Tasks;
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

namespace Tractor.UWP.Presenters.Controls
{
    public sealed partial class TasksPresenterView : UserControl
    {
        public static readonly DependencyProperty PresentedTaskProperty = DependencyProperty.Register(nameof(PresentedTasks), typeof(ObservableCollection<ITask>), typeof(TasksPresenterView), new PropertyMetadata(null));

        public ObservableCollection<ITask> PresentedTasks
        {
            get => (ObservableCollection<ITask>)GetValue(PresentedTaskProperty);
            set => SetValue(PresentedTaskProperty, value);
        }

        public TasksPresenterView()
        {
            this.InitializeComponent();
        }
    }
}
