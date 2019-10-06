using EmptyBox.IO.Serializator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Model
{
    public interface ITask : IStuff
    {
        string Name { get; }
        string Description { get; }
        [SerializationScenario("Links", typeof(List<Guid>))]
        IEnumerable<ITask> Subtasks { get; }
        IEntity Performer { get; }
        IEntity Producer { get; }
        DateTime CreationDate { get; }
        DateTime LastStateChangeDate { get; }
        TaskState State { get; }
        ITaskLocation Location { get; }
        [SerializationScenario("Links", typeof(List<Guid>))]
        IEnumerable<ITask> Dependencies { get; }
    }
}
