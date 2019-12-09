using System;
using System.Collections.Generic;
using System.ComponentModel;
using EmptyBox.IO.Storage;
using Tractor.Core.Collections;
using Tractor.Core.Objects.Descriptions.Labels;

namespace Tractor.Core.Objects.Descriptions
{
    public interface IDescription : IEquatable<IDescription>, INotifyPropertyChanged, INotifyPropertyChanging, ICloneable
    {
		ObservableCollection<ILabel> Labels { get; }
        ObservableCollection<IStorageItem> Attachments { get; }
        Guid ID { get; }
    }
}