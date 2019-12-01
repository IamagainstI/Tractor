using System;
using System.Collections.Generic;
using System.ComponentModel;
using EmptyBox.IO.Storage;
using Tractor.Core.Objects.Descriptions.Labels;

namespace Tractor.Core.Objects.Descriptions
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