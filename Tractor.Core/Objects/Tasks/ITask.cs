using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;
using Tractor.Core.Objects.Tasks.Locations;

namespace Tractor.Core.Objects.Tasks
{
    public interface ITask : IStuff, IEquatable<ITask>,
        IEditableTreeNode<ITask>, ITreeNodeWithParent<ITask>, IObservableTreeNode<ITask>
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
