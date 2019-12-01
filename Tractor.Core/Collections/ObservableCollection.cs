using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Collections
{
    public class ObservableCollection<T> : System.Collections.ObjectModel.ObservableCollection<T>, INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler PropertyChanging;

        protected override void ClearItems()
        {
            PropertyChanging?.Invoke(this, null);
            base.ClearItems();
        }

        protected override void InsertItem(int index, T item)
        {
            PropertyChanging?.Invoke(this, null);
            base.InsertItem(index, item);
        }

        protected override void MoveItem(int oldIndex, int newIndex)
        {
            PropertyChanging?.Invoke(this, null);
            base.MoveItem(oldIndex, newIndex);
        }

        protected override void RemoveItem(int index)
        {
            PropertyChanging?.Invoke(this, null);
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, T item)
        {
            PropertyChanging?.Invoke(this, null);
            base.SetItem(index, item);
        }
    }
}
