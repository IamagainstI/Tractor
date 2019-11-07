using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;

namespace Tractor.Core.Objects
{
    public class Account : IEntity
    {
        public string Name => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();

        public string Password { get; }
    }
}
