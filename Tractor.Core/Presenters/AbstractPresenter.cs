using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters
{
    public abstract class AbstractPresenter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public UIRouter Router { get; }

        public AbstractPresenter(UIRouter router)
        {
            Router = router;
        }

        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
         where T : IEquatable<T>
        {
            if (true)
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
