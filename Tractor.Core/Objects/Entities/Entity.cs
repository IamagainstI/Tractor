using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;

namespace Tractor.Core
{
    public class Entity : IEntity
    {
        public Guid ID { get; }
        public string Name { get; set; }

        public Entity(Guid id)
        {
            ID = id;
        }

    }
}
