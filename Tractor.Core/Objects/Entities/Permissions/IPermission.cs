using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Objects.Entities.Permissions
{
    public interface IPermission : IEquatable<IPermission>, INotifyPropertyChanged, INotifyPropertyChanging, ICloneable
    {
        Guid ID { get; }
        AccessType AccessType { get; set; }
    }
}
