using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Entities
{
    public class AnonymousEntity : IEntity
    {
        public string Name { get; }

        public Guid ID { get; }

        public bool Equals(IEntity other)
        {
            return ID == other.ID;
        }
    }
}
