using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public interface ITimeBasedProgress : IProgress
    {
        TimeSpan Interval { get; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
    }
}
