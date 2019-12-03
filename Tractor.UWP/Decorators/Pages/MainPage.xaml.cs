using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.Pipeline;
using Tractor.Core.Routers.UI;
using Tractor.UWP.Presenters.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using MUIX = Microsoft.UI.Xaml;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Tractor.UWP.Decorators.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void nv_LeftPane_SelectionChanged(MUIX.Controls.NavigationView sender, MUIX.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            MUIX.Controls.NavigationViewItem item = sender.SelectedItem as MUIX.Controls.NavigationViewItem;
            string cmd = (string)item.Content switch
            {
                "Общий вид" => UIViews.OVERALL_PAGE,
                "Управление проектами" => UIViews.PROJECTS_PAGE,
                _ => string.Empty
            };
            App.CurrentInstance.Instance.UIRouter.RequestNavigation(new NavigationInfo() { Name = cmd });
        }

        public void NavigateTo(Type type, object obj)
        {
            Frame contentFrame = new Frame();
            nv_TopPane.Content = contentFrame;
            contentFrame.Navigate(type, obj);
        }
    }
}
