using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;

namespace Tractor.Core
{
    public class Team : ITeam
    {
        IDictionary<IEntity, IEntityRole> ITeam.Members => Members;

        public Guid ID { get; }
        public string Name { get; set; }
        public Dictionary<IEntity, IEntityRole> Members { get; }

    }
}
