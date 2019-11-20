using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using Tractor.Core.Objects.Credentials;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Projects
{
    class GitHubProject : IProject
    {
        public string Name => throw new NotImplementedException();

        public IProgress Progress => throw new NotImplementedException();

        public IEnumerable<IProject> Subprojects => throw new NotImplementedException();

        public IDescription Description => throw new NotImplementedException();

        public IEnumerable<ITask> Tasks => throw new NotImplementedException();

        public IReadOnlyDictionary<IEntity, IEntityRole> Participants => throw new NotImplementedException();

        public IEnumerable<IPermission> Permissions => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();

        public IProject Parent => throw new NotImplementedException();

        public IEnumerable<IProject> Items => throw new NotImplementedException();

        IEnumerable<ITask> ITreeNode<ITask>.Items => throw new NotImplementedException();

        public event ProjectChangeEventHandler ProjectChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public event ObservableTreeNodeItemChangeHandler<IProject> ItemAdded;
        public event ObservableTreeNodeItemChangeHandler<IProject> ItemRemoved;

        event ObservableTreeNodeItemChangeHandler<ITask> IObservableTreeNode<ITask>.ItemAdded
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event ObservableTreeNodeItemChangeHandler<ITask> IObservableTreeNode<ITask>.ItemRemoved
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void Add(IProject item)
        {
            throw new NotImplementedException();
        }

        public void Add(ITask item)
        {
            throw new NotImplementedException();
        }

        public void AddParticipant(IEntity entity, IEntityRole entityRole)
        {
            throw new NotImplementedException();
        }

        public void AddPermission(IPermission permission)
        {
            throw new NotImplementedException();
        }

        public void AddTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public void EditParticipantRole(IEntity entity, IEntityRole entityRole)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IProject other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProject> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(IProject item)
        {
            throw new NotImplementedException();
        }

        public void Remove(ITask item)
        {
            throw new NotImplementedException();
        }

        public void RemoveParticipant(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemovePermission(IPermission permission)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(ITask task)
        {
            throw new NotImplementedException();
        }

        IEnumerator<ITask> IEnumerable<ITask>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
