using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Tasks
{
    interface IRepetitiveTask : IEventTask
    {
        IList<IRepetitiveTask> AllInstances { get; }
    }
}
