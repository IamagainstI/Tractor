using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Progress;

namespace Tractor.Core.Objects.Projects
{
    public interface IProject : IStuff, ITreeNodeWithParent<IProject>, IObservableTreeNode<IProject>, IObservableTreeNode<ITask>
    {
        event ProjectChangeEventHandler ProjectChanged;

        string Name { get; }
        IProgress Progress { get; }
        IEnumerable<IProject> Subprojects { get; }
        IDescription Description { get; }
        IEnumerable<ITask> Tasks { get; }
        IDictionary<IEntity, IEntityRole> Performers { get; }
        void AddTask(ITask Task);
        void RemoveTask(ITask Task);
        void AddEntity(IEntity Entity, IEntityRole EntityRole);
        void RemoveEntity(IEntity Entity);
    }
}
