using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Difference
{
    public enum DifferenceType : byte
    {
        Unknown = 0,
        Change = 1,
        Add = 2,
        Remove = 3
    }
}
