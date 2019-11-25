using System;
using System.Collections.Generic;
using System.ComponentModel;
using EmptyBox.IO.Storage;

namespace Tractor.Core.Objects
{
    public interface IDescription : IEquatable<IDescription>, INotifyPropertyChanged, INotifyPropertyChanging
    {
		IList<ILabel> Labels { get; }
        IList<IStorageItem> Attachments { get; }
        void AddLabel(IEnumerable<ILabel> label);
        void RemoveLabel(IEnumerable<ILabel> label);
        void AddAttachment(IEnumerable<IStorageItem> storageItem);
        void RemoveAttachment(IEnumerable<IStorageItem> storageItem);
    }
}