using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Tasks
{
    interface IMeetingTask : ITask
    {
        IList<IEntity> Participants { get; }
        IDictionary<IEntity, bool> CheckList { get; }
    }
}
