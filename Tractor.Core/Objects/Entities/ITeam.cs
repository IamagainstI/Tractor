using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Objects
{
    public interface ITeam : IEntity, INotifyPropertyChanged, INotifyPropertyChanging, INotifyCollectionChanged, ICloneable
    {
        IDictionary<IEntity, IEntityRole> Members { get; }
        void AddMember(IDictionary<IEntity, IEntityRole> membres);
        void RemoveMember(IDictionary<IEntity, IEntityRole> membres);
    }
}
