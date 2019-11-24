using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Tractor.Core.Objects.Difference
{
    public interface IDifference : IEquatable<IDifference>, IComparable<IDifference>, IComparable<DateTime>
    {
        Guid ID { get; }
        DateTime CreationDate { get; }
        IEntity Entity { get; }
        object ChangedObject { get; }
        string PropertyName { get; }
        object OldValue { get; }
        object NewValue { get; }
        NotifyCollectionChangedAction Type { get; }
    }
}
