using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Projects
{
    public interface IProject : IStuff, IEquatable<IProject>, INotifyPropertyChanged, INotifyPropertyChanging, INotifyCollectionChanged,
        IEditableTreeNode<IProject>, ITreeNodeWithParent<IProject, IProject>, IObservableTreeNode<IProject>
        //IEditableTreeNode<ITask>, IObservableTreeNode<ITask>
    {
        string Name { get; set; }
        IProgress Progress { get; set; }
        IEnumerable<IProject> Subprojects { get; }
        IDescription Description { get; set; }
        IEnumerable<ITask> Tasks { get; }
        IReadOnlyDictionary<IEntity, IEntityRole> Participants { get; }
        IEnumerable<IPermission> Permissions { get; }

        void AddTask(ITask task);
        void RemoveTask(ITask task);
        void AddParticipant(IEntity entity, IEntityRole entityRole);
        void EditParticipantRole(IEntity entity, IEntityRole entityRole);
        void RemoveParticipant(IEntity entity);
        void AddPermission(IPermission permission);
        void RemovePermission(IPermission permission);
    }
}
