using System;
using System.Collections.Generic;
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

namespace Tractor.UWP.Decorators.Controls
{
    public sealed partial class TaskEditorView : UserControl
    {
        //public static readonly DependencyProperty PresentedTaskProperty = DependencyProperty.Register(nameof(PresentedTask), typeof(ITask), typeof(TaskView), new PropertyMetadata(null));

        //public UsualTask PresentedTask
        //{
        //    //get => (UsualTask)GetValue(PresentedTaskProperty);
        //    //set => SetValue(PresentedTaskProperty, value);
        //    get => (UsualTask)Editor.Task;
        //    set => Editor.Task = value;
        //}

        public DataEditor Editor { get; set; }

        public TaskEditorView()
        {
            this.InitializeComponent();
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
