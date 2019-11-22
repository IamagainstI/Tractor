using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks.Locations;

namespace Tractor.Core.Objects.Tasks
{
    public class UsualTask : ITask
    {

        #region Private events
        private event ObservableTreeNodeItemChangeHandler<ITask> _SubTaskItemAdded;
        private event ObservableTreeNodeItemChangeHandler<ITask> _SubTaskItemRemoved;
        #endregion

        #region Private objects
        private string _Name;
        private IProgress _Progress;
        private List<ITask> _SubTasks;
        private IDescription _Description;
        private ITask _Parent;
        private IEntity _Performer;
        #endregion

        #region IObservableTreeNode<ITask> events
        event ObservableTreeNodeItemChangeHandler<ITask> IObservableTreeNode<ITask>.ItemAdded
        {
            add => _SubTaskItemAdded += value;
            remove => _SubTaskItemAdded -= value;
        }
        event ObservableTreeNodeItemChangeHandler<ITask> IObservableTreeNode<ITask>.ItemRemoved
        {
            add => _SubTaskItemRemoved += value;
            remove => _SubTaskItemRemoved -= value;
        }
        #endregion

        #region
        public event ObservableTreeNodeItemChangeHandler<ITask> ItemAdded;
        public event ObservableTreeNodeItemChangeHandler<ITask> ItemRemoved;
        #endregion

        #region Public events
        public event TaskChangeEventHandler TaskChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Protected metods
        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
         where T : IEquatable<T>
        {
            if (!field.Equals(newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
                ITaskDifference difference = null;
                switch (name)
                {
                    case nameof(Name):
                        difference = new TaskDifferenceNameChanged((string)(object)newValue, this, DateTime.Now);
                        break;
                }
                TaskChanged?.Invoke(difference);
            }
        }
        #endregion

        #region Public objects
        public string Name
        {
            get => _Name;
            set => OnPropertyChange(ref _Name, value);
        }

        public IDescription Description 
        { 
            get => _Description; 
            set => OnPropertyChange(ref _Description, value); 
        }

        public IEnumerable<ITask> Subtasks { get; }

        public IEnumerable<ITask> Dependencies => throw new NotImplementedException();

        public IList<IEntity> Observers { get;  }

        public IEntity Performer
        {
            get => _Performer;
            set => OnPropertyChange(ref _Performer, value);
        }

        public IEntity Producer { get; }

        public DateTime CreationDate { get; }

        public DateTime LastStateChangeDate => throw new NotImplementedException();

        public ITaskLocation Location { get; }

        public Guid ID { get; }

        public IEditableTreeNode<ITask> Parent { get; }

        public IEnumerable<ITask> Items { get; }

        public IProgress Progress { get; }

        #endregion

        #region IEnumerable<ITask> metod
        IEnumerator<ITask> IEnumerable<ITask>.GetEnumerator()
        {
            foreach (ITask task in _SubTasks)
            {
                yield return task;
                foreach (ITask _task in (IEnumerable<ITask>)task)
                {
                    yield return _task;
                }
            }
        }
        #endregion

        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotSupportedException();
        }
        #endregion

        #region Public metods
        public UsualTask()
        {

        }

        public void Add(ITask item)
        {
            bool checkContaints = false;
            if (item != null)
            {
                foreach(ITask task in _SubTasks)
                {
                    if (task.Equals(item)) checkContaints = true;
                }
                if (!checkContaints) _SubTasks.Add(item);
            }
        }

        public bool Equals(ITask other)
        {
            if(other != null)
            {
                return other.ID == ID;
            }
            return false;
        }

        public void Remove(ITask item)
        {
            if (item != null)
            {
                _SubTasks.Remove(item);
            }
        }
        #endregion
    }
}
