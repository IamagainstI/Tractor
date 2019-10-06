using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Model
{
    public interface IEntity : IStuff
    {
        string Name { get; }
    }
}
