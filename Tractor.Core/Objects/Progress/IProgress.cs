using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Objects.Difference;

namespace Tractor.Core.Objects.Progress
{
    public interface IProgress : IEquatable<IProgress>, INotifyPropertyChanged, INotifyPropertyChanging
    {
        double ProgressPercentage { get; }
        DateTime TimeLastChangeProgress { get; }
        Guid ID { get; }
    }
}
