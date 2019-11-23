using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.NewDifferenceModel
{
    public interface IDifference<T>
    {
        byte[] GetPropertyHashCode();
        string PropertyName { get; }
        DateTime CreationDate { get; }
        T ChangedObject { get; }
    }
}
