using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public interface IProgress : IEquatable<IProgress>
    {
        double Percentage { get; }
        DateTime TimeLastChangeProgress { get; }
    }
}
