using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects
{
    public interface ITeam : IEntity
    {
        IDictionary<IEntity, IEntityRole> Members { get; }
    }
}
