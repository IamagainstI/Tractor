using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Collections;
using Tractor.Core.Model;
using Tractor.Core.Objects.Descriptions;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks.Locations;

namespace Tractor.Core.Objects.Tasks
{
    public interface ITask : IStuff, IEquatable<ITask>, INotifyPropertyChanged, INotifyPropertyChanging, INotifyCollectionChanged, ICloneable
        //IEditableTreeNode<ITask>, ITreeNodeWithParent<ITask, IEditableTreeNode<ITask>>, IObservableTreeNode<ITask>
    {
        string Name { get; set; }
        IDescription Description { get; set; }
        ObservableCollection<ITask> Subtasks { get; }
        ObservableCollection<ITask> Dependencies { get; }
        ObservableCollection<IEntity> Observers { get; }
        IEntity Performer { get; set; }
        IEntity Producer { get; set; }
        IProgress Progress { get; set; }
        DateTime CreationDate { get; }
        DateTime LastStateChangeDate { get; }
        ITaskLocation Location { get; set; }
    }
}
