using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Model;
using Tractor.Core.Objects.Descriptions;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks.Locations;

namespace Tractor.Core.Objects.Tasks
{
    public interface ITask : IEquatable<ITask>, INotifyPropertyChanged, INotifyPropertyChanging, INotifyCollectionChanged, ICloneable
        //IEditableTreeNode<ITask>, ITreeNodeWithParent<ITask, IEditableTreeNode<ITask>>, IObservableTreeNode<ITask>
    {
        Guid ID { get; }
        string Name { get; set; }
        IDescription Description { get; set; }
        IEnumerable<ITask> Subtasks { get; }
        IEnumerable<ITask> Dependencies { get; }
        IEnumerable<IEntity> Observers { get; }
        IEntity Performer { get; set; }
        IEntity Producer { get; set; }
        IProgress Progress { get; set; }
        DateTime CreationDate { get; }
        DateTime LastStateChangeDate { get; }
        ITaskLocation Location { get; set; }
        void AddSubtask(ITask subtask);
        void AddObserver(IEntity observer);
        void AddDependency(ITask dependency);
        void RemoveSubtask(ITask SubTask);
        void RemoveObserver(IEntity observer);
        void RemoveDependency(ITask dependency);
        void AddRangeSubtask(IEnumerable<ITask> subtasks);
        void AddRangeObserver(IEnumerable<IEntity> observers);
        void AddRangeDependency(IEnumerable<ITask> dependencies);
        void RemoveRangeSubtask(IEnumerable<ITask> subtasks);
        void RemoveRangeObserver(IEnumerable<IEntity> observers);
        void RemoveRangeDependency(IEnumerable<ITask> dependencies);
    }
}
