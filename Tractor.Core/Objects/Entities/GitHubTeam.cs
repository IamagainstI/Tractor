﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Entities
{
    class GitHubTeam : ITeam
    {
        public IDictionary<IEntity, IEntityRole> Members => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();
    }
}