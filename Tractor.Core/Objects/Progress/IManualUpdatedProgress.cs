using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public interface IManualUpdatedProgress : IProgress
    {
        bool TaskCompleted { get; set; }
    }
}
