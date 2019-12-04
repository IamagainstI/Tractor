using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Collections;

namespace Tractor.Core.Objects
{
    public interface ITeam : IEntity, INotifyPropertyChanged, INotifyPropertyChanging, INotifyCollectionChanged, ICloneable
    {
        ObservableDictionary<IEntity, IEntityRole> Members { get; }
    }
}
