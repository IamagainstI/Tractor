using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;

namespace Tractor.Core.Objects
{
    public class TractorAccount : IEntity
    {
        public TractorAccount(Guid id)
        {
            ID = id;
        }
        public string Name { get; }
        
        public Guid ID{ get; }

        public IEntity Clone()
        {
            throw new NotImplementedException();
        }

        public bool Equals(IEntity other)
        {
            return ID == other.ID;
        }
    }
}
