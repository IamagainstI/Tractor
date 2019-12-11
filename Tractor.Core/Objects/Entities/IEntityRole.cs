using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Objects
{
    public interface IEntityRole : INotifyPropertyChanged, INotifyPropertyChanging, ICloneable
    {
        Guid ID { get; }
        string Name { get; set; }
    }
}
