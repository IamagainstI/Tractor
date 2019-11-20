using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Difference
{
    public interface ITaskDifference : IDifference
    {
        ITask Task { get; }
    }
}
