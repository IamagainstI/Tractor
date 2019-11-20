using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Difference
{
    public interface IDifference : IEquatable<IDifference>, IComparable<IDifference>
    {
        byte[] GetDifferenceHash();
        DateTime CreationDate { get; }
    }
}
