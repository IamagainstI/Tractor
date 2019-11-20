using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using Tractor.Core.Objects.Tasks.Locations;

namespace Tractor.Core.Objects.Tasks
{
    public class EventTask : IEventTask
    {
        public TimeSpan Duration => throw new NotImplementedException();

        public DateTime StartTime => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public IEnumerable<ITask> Subtasks => throw new NotImplementedException();

        public IEnumerable<ITask> Dependencies => throw new NotImplementedException();

        public IList<IEntity> Observers => throw new NotImplementedException();

        public IEntity Performer => throw new NotImplementedException();

        public IEntity Producer => throw new NotImplementedException();

        public DateTime CreationDate => throw new NotImplementedException();

        public DateTime LastStateChangeDate => throw new NotImplementedException();

        public ITaskLocation Location => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();

        public IEditableTreeNode<ITask> Parent => throw new NotImplementedException();

        public IEnumerable<ITask> Items => throw new NotImplementedException();

        public event ObservableTreeNodeItemChangeHandler<ITask> ItemAdded;
        public event ObservableTreeNodeItemChangeHandler<ITask> ItemRemoved;

        public void Add(ITask item)
        {
            throw new NotImplementedException();
        }

        public bool Equals(ITask other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITask> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(ITask item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
