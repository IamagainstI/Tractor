using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.Pipeline;
using Tractor.UWP.UI.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Tractor.UWP.UI.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public UsualTask Task { get; set; } = new UsualTask(Guid.NewGuid());
        public PipelineConstructor Constructor { get; set; } = new PipelineConstructor();

        public MainPage()
        {
            this.InitializeComponent();
            Constructor.Navigator.NavigationRequested += Navigator_NavigationRequested;
        }

        private void Navigator_NavigationRequested(object sender, string e)
        {
            if (e == "TaskEditor")
            {
                TaskEditorView v = new TaskEditorView();
                v.Editor = Constructor.TaskEditor;
                Content = v;
            }
        }

        private void NavigationView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Constructor.ExternalTaskInput.Send(Task);
        }
    }
}
