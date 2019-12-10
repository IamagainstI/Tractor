using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Presenters.Projects;
using Tractor.Core.Presenters.Tasks;
using Tractor.Core.Routers.UI;
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

namespace Tractor.UWP.Decorators.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ProjectManagementPage : Page
    {
        public ProjectManagementPagePresenter Presenter { get; private set; }

        public ProjectManagementPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Presenter = e.Parameter as ProjectManagementPagePresenter;
            base.OnNavigatedTo(e);
        }

        private void abb_Add_Click(object sender, RoutedEventArgs e)
        {
            Presenter.AddTask();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                var task = new List<Guid>(Presenter.Router.CurrentDataBase.GetPath(e.AddedItems[0]));
                var storage = new List<Guid>(Presenter.Router.CurrentDataBase.GetPath(Presenter.Project));
                Presenter.Router.RequestNavigation(new NavigationHistory() { Name = UIViews.TASK_VIEW_DIALOG, PresenterType = typeof(TaskViewPresenter), Paths = new List<Guid>[] { task, storage } });
            }
        }
    }
}
