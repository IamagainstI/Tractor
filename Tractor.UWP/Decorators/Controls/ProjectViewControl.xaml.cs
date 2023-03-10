using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Model;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Presenters.Tasks;
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
    public sealed partial class ProjectViewControl : UserControl
    {
        public IProject PresentedProject { get; set; }

        public ProjectViewControl()
        {
            this.InitializeComponent();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 512)
            {
                VisualStateManager.GoToState(this, "WideView", true);
            }
            else if (e.NewSize.Width >= 256)
            {
                VisualStateManager.GoToState(this, "NarrowView", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "MiniView", true);
            }
        }
    }
}
