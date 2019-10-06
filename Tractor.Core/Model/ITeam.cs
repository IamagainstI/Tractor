using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Model
{
    public interface ITeam : IEntity
    {
        IDictionary<IEntity, IEntityRole> Members { get; }
    }
}
