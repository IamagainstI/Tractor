using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Entities
{
    class AnonymousEntity : IEntity
    {
        public string Name => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();
    }
}
