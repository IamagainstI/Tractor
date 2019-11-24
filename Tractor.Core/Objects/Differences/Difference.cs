using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Tractor.Core.Objects.Difference
{
    public class Difference : IDifference
    {
        public Guid ID { get; }
        public DateTime CreationDate { get; set; }
        public IEntity Entity { get; set; }
        public object ChangedObject { get; set; }
        public string PropertyName { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
        public NotifyCollectionChangedAction Type { get; set; }

        public Difference(Guid id)
        {
            ID = id;
        }

        public int CompareTo(IDifference other)
        {
            return CreationDate.CompareTo(other.CreationDate);
        }

        public int CompareTo(DateTime other)
        {
            return CreationDate.CompareTo(other);
        }

        public bool Equals(IDifference other)
        {
            return ID.Equals(other.ID);
        }
    }
}
