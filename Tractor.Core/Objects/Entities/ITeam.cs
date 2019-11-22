using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Objects
{
    public interface ITeam : IEntity, INotifyPropertyChanged
    {
        IDictionary<IEntity, IEntityRole> Members { get; }
        void AddMember(IEntity item, IEntityRole itemRole);
        void RemoveMember(IEntity item);
    }
}
