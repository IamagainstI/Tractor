using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks.Locations;

namespace Tractor.Core.Objects.Tasks
{
    public class JournalTask : IMeetingTask
    {
        #region PrivateObject
        private List<IEntity> _Participants;
        private Dictionary<IEntity, bool> _CheckList;
        private ITask _Task;
        private string _Name;
        private string _Description;
        #endregion
        
        public IDictionary<IEntity, bool> CheckList => CheckList;

        #region PublicObjects
        public string Name
        {
            get => _Name;
        }

        public string Description
        {
            get => _Description;
        }

        public IList<IEntity> Participants
        {
            get
            {
                Participants.Add(_Task.Performer);
                Participants.Add(_Task.Producer);
                foreach (IEntity entity in Observers)
                {
                    Participants.Add(entity);
                }
                return Participants;
            }
        }

        #endregion

        public IEnumerable<ITask> Subtasks => throw new NotImplementedException();

        public IEnumerable<ITask> Dependencies => throw new NotImplementedException();

        public IList<IEntity> Observers => throw new NotImplementedException();

        public IEntity Performer => throw new NotImplementedException();

        public IEntity Producer => throw new NotImplementedException();

        public IProgress Progress => throw new NotImplementedException();

        public DateTime CreationDate => throw new NotImplementedException();

        public DateTime LastStateChangeDate => throw new NotImplementedException();

        public ITaskLocation Location => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();

        public IEditableTreeNode<ITask> Parent => throw new NotImplementedException();

        public IEnumerable<ITask> Items => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
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

