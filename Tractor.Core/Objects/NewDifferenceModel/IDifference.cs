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
        Guid ID { get; } //для объекта
        string ObjectType { get; }
        string PropertyType { get; }
    }
}
