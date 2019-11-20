using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Entities
{
    public class GitHubEntity : IEntity
    {
        public string Name => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();

        public bool Equals(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
