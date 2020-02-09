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

namespace Tractor.UWP.Decorators.Pages
{
    public sealed partial class ProjectViewPage : Page
    {
        public ProjectViewPresenter Presenter { get; private set; }

        public ProjectViewPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Presenter = e.Parameter as ProjectViewPresenter;
            base.OnNavigatedTo(e);
        }
    }
}
