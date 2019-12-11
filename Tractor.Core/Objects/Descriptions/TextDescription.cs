using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EmptyBox.IO.Storage;
using Tractor.Core.Collections;
using Tractor.Core.Objects.Descriptions.Labels;

namespace Tractor.Core.Objects.Descriptions
{
    public class TextDescription : IDescription
    {
        #region Private objects
        private string _Text;
        #endregion

        #region Public events
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion

        #region Public Objects
        public string Text
        {
            get => _Text;
            set => OnPropertyChange(ref _Text, value);
        }
        public ObservableCollection<ILabel> Labels { get; } = new ObservableCollection<ILabel>();
        public ObservableCollection<IStorageItem> Attachments { get; } = new ObservableCollection<IStorageItem>();
        public Guid ID { get; }
        #endregion Public Objects


        #region Constructors
        public TextDescription(Guid id)
        {
            ID = id;
            Labels.CollectionChanged += OnCollectionChanged;
            Labels.PropertyChanging += OnCollectionPropertyChanging;
            Attachments.CollectionChanged += OnCollectionChanged;
            Attachments.PropertyChanging += OnCollectionPropertyChanging;
        }
        #endregion

        #region Private metods
        private string GetCollectionName(object collection)
        {
            if (collection == Labels)
            {
                return nameof(Labels);
            }
            else if (collection == Attachments)
            {
                return nameof(Attachments);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(sender, e);
        }

        private void OnCollectionPropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(GetCollectionName(sender)));
        }

        private void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
        {
            if (!Equals(field, newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region Public Metods
        public bool Equals(IDescription other)
        {
            return ID == other.ID;
        }

        public object Clone()
        {
            TextDescription result = new TextDescription(ID);
            result._Text = _Text;
            foreach (IStorageItem item in Attachments)
            {
                result.Attachments.Add(item);
            }
            foreach (ILabel label in Labels)
            {
                result.Labels.Add(label);
            }
            return result;
        }
        #endregion
    }
}

