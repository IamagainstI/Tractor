using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public interface IProgress : IEquatable<IProgress>
    {
        Progress Percentage { get; }
        void ProgressChanged(IProgress Difference);
        DateTime TimeLastChangeProgress { get; }
    }
}
