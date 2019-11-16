using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Model
{
    public interface ITask : IStuff
    {
        string Name { get; }
        string Description { get; }

        IEnumerable<ITask> Subtasks { get; }
        IEnumerable<ITask> Dependencies { get; }

        IList<IEntity> Observers { get; }
        IEntity Performer { get; }
        IEntity Producer { get; }

        DateTime CreationDate { get; }
        DateTime LastStateChangeDate { get; }
        TaskState State { get; }
        ITaskLocation Location { get; }
    }
}
