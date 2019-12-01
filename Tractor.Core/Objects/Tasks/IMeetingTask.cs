using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Tasks
{
    public interface IMeetingTask : ITask
    {
        IEnumerable<IEntity> Participants { get; }
        IReadOnlyDictionary<IEntity, bool> CheckList { get; }
    }
}
