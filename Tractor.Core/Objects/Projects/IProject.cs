using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Collections;
using Tractor.Core.Objects.Descriptions;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Projects
{
    public interface IProject : ITaskStorage,
        IEquatable<IProject>, ICloneable,
        INotifyPropertyChanged, INotifyPropertyChanging, INotifyCollectionChanged
    {
        Guid ID { get; }
        string Name { get; set; }
        IProgress Progress { get; set; }
        IDescription Description { get; set; }
        IProjectStorage Parent { get; }
        ObservableDictionary<IEntity, IEntityRole> Participants { get; }
        ObservableCollection<IPermission> Permissions { get; }
    }
}
