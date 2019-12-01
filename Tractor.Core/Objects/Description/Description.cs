using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EmptyBox.IO.Storage;
using Tractor.Core.Objects;

namespace Tractor.Core
{
    public class Description : IDescription
    {

        #region Private objects
        private List<ILabel> _Labels;
        private List<IStorageItem> _Attachments;
        #endregion

        #region Public events
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion

        #region Public Objects
        public IList<ILabel> Labels { get => _Labels; }
        public IList<IStorageItem> Attachments { get => _Attachments; }

        public Guid ID { get; }
        #endregion Public Objects

        #region Private metods
        private void OnPropertyChangeCollectionAdd<T>(ref List<T> field, IEnumerable<T> newValue, [CallerMemberName]string name = null)
            where T : IEquatable<T>
        {
            if (newValue != null)
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(name)));
                field.AddRange(newValue);
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newValue, null));
            }
        }
        private void OnPropertyChangeCollectionRemove<T>(ref List<T> field, IEnumerable<T> Value, [CallerMemberName]string name = null)
           where T : IEquatable<T>
        {
            if (Value != null)
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(name)));
                foreach (T item in field)
                {
                    field.Remove(item);
                }
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, null, Value));
            }
        }
        #endregion

        #region Constructors
        public Description(Guid id = new Guid())
        {
            ID = id;
        }
        #endregion

        #region Public Metods

        public bool Equals(IDescription other)
        {
            throw new NotImplementedException();
        }

        public void AddLabel(IEnumerable<ILabel> label)
        {
            OnPropertyChangeCollectionAdd(ref _Labels, label);
        }

        public void RemoveLabel(IEnumerable<ILabel> label)
        {
            OnPropertyChangeCollectionRemove(ref _Labels, label);
        }

        public void AddAttachment(IEnumerable<IStorageItem> storageItem)
        {
            //OnPropertyChangeCollectionAdd(ref _Attachments, storageItem);
        }

        public void RemoveAttachment(IEnumerable<IStorageItem> storageItem)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            Description result = new Description(ID);
            result._Attachments = _Attachments;
            result._Labels = _Labels;
            return result;
        }
        #endregion
    }
}

