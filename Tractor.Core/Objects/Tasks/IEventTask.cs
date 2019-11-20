using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Tasks
{
    interface IEventTask : ITask
    {
        TimeSpan Duration { get; }
        DateTime StartTime { get; }
    }
}
