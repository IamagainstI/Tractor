using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using Tractor.Core.Objects.Progress;

namespace Tractor.Core.Objects
{
    public class UsualProject : IProject
    {
        public string Name { get; set; }

        public IProgress Progress => throw new NotImplementedException();

        public IEnumerable<IProject> Subprojects => ITreeNode<ITask>.Items;

        public IDescription Description => throw new NotImplementedException();

        public IEnumerable<ITask> Tasks => throw new NotImplementedException();

        public IDictionary<IEntity, IEntityRole> Performers => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();

        public IProject Parent => throw new NotImplementedException();

        public IEnumerable<IProject> Items => throw new NotImplementedException();

        IEnumerable<ITask> ITreeNode<ITask>.Items => throw new NotImplementedException();

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

        public void AddEntity(IEntity Entity, IEntityRole EntityRole)
        {
            throw new NotImplementedException();
        }

        public void AddTask(ITask Task)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProject> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void ProjectChanged(IProject Difference)
        {
            throw new NotImplementedException();
        }

        public void RemoveEntity(IEntity Entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(ITask Task)
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
