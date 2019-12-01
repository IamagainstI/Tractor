using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Tractor.Core.Specialized
{
    public class PropertyComparator : IEqualityComparer<PropertyInfo>
    {
        public static PropertyComparator Comparator { get; } = new PropertyComparator();

        public bool Equals(PropertyInfo x, PropertyInfo y)
        {
            return ((x.PropertyType == y.PropertyType) && (x.Name == y.Name));
        }

        public int GetHashCode(PropertyInfo obj)
        {
            return obj.GetHashCode();
        }
    }
}
