using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;

namespace Tractor.Core.Objects
{
    public interface ITask : IStuff, ITreeNodeWithParent<ITask>, IObservableTreeNode<ITask>, IEquatable<ITask>
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
        ITaskLocation Location { get; }
    }
}
