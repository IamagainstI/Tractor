using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Difference
{
    public  interface ITaskDifferenceSubtasksChanged : ITaskDifference
    {
        IList<ITaskDifference> Tasks { get; }
    }
}
