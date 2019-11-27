using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core.Objects;
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

namespace Tractor.UWP.UI.Controls
{
    public sealed partial class EntityView : UserControl
    {
        public static readonly DependencyProperty PresentedEntityProperty = DependencyProperty.Register(nameof(PresentedEntity), typeof(IEntity), typeof(EntityView), new PropertyMetadata(null));

        public IEntity PresentedEntity
        {
            get => (IEntity)GetValue(PresentedEntityProperty);
            set => SetValue(PresentedEntityProperty, value);
        }

        public EntityView()
        {
            this.InitializeComponent();
        }
    }
}
