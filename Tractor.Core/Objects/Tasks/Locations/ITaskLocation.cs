using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;

namespace Tractor.Core.Objects.Tasks.Locations
{
    public interface ITaskLocation : IEquatable<ITaskLocation>
    {
        Guid ID { get; }
    }
}
