using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Progress;

namespace Tractor.Core.Objects.Projects
{
    public interface IProject : IStuff, ITreeNodeWithParent<IProject>, IObservableTreeNode<IProject>, IObservableTreeNode<ITask>, INotifyPropertyChanged
    {
        event ProjectChangeEventHandler ProjectChanged;

        string Name { get; }
        IProgress Progress { get; }
        IEnumerable<IProject> Subprojects { get; }
        IDescription Description { get; }
        IEnumerable<ITask> Tasks { get; }
        IReadOnlyDictionary<IEntity, IEntityRole> Performers { get; }
        IEnumerable<IPermission> Permissions { get; }

        void AddTask(ITask task);
        void RemoveTask(ITask task);
        void AddEntity(IEntity entity, IEntityRole entityRole);
        void RemoveEntity(IEntity entity);
        void AddPermission(IPermission permission);
        void RemovePermission(IPermission permission);
    }
}
