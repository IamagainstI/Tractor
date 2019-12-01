using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Tasks
{
    public interface IEventTask : ITask
    {
        TimeSpan Duration { get; set; }
        DateTime StartTime { get; set; }
    }
}
