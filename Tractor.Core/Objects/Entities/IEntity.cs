using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Objects
{
    public interface IEntity : IEquatable<IEntity>, INotifyPropertyChanged, INotifyPropertyChanging
    {
        Guid ID { get; }
        string Name { get; set; }
    }
}
