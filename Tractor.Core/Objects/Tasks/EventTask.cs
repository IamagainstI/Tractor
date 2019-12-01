using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using Tractor.Core.Objects.Descriptions;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks.Locations;

namespace Tractor.Core.Objects.Tasks
{
    public class EventTask : IEventTask
    {
        #region Private objects
        private string _Name;
        private IProgress _Progress;
        private List<ITask> _Subtasks;
        private List<IEntity> _Observers;
        private IDescription _Description;
        private ITask _Parent;
        private IEntity _Performer;
        private ITaskLocation _Location;
        private List<ITask> _Dependencies;
        TimeSpan _Duration;
        DateTime _StartTime;
        #endregion

        #region Public events
        public event PropertyChangedEventHandler PropertyChanged;
        //public event ObservableTreeNodeItemChangeHandler<ITask> ItemAdded;
        //public event ObservableTreeNodeItemChangeHandler<ITask> ItemRemoved;
        public event PropertyChangingEventHandler PropertyChanging;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion

        #region Private metods for property change
        private void OnPropertyCollectionChangedAdd<T>(ref List<T> field, IEnumerable<T> newItems, [CallerMemberName]string name = null)
                where T : IEquatable<T>
        {
            if (newItems != null)
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(name)));
                field.AddRange(newItems);
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newItems, null));
            }
        }
        private void OnPropertyCollectionChangedRemove<T>(ref List<T> field, IEnumerable<T> items, [CallerMemberName]string name = null)
                where T : IEquatable<T>
        {
            if (items != null)
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(name)));
                foreach (T item in field)
                {
                    field.Remove(item);
                }
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, null, items));
            }
        }
        private void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
         where T : IEquatable<T>
        {
            if (!field.Equals(newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
        public ObservableCollection<IEntity> Entities;
        public void test()
        {
            Entities.
        }
        public IEnumerable<ITask> Subtasks => _Subtasks;
        public IEnumerable<ITask> Dependencies => _Dependencies;
        public IEnumerable<IEntity> Observers => _Observers;
        public IEntity Performer
        {
            get => _Performer;
            set => OnPropertyChange(ref _Performer, value);
        }
        public IEntity Producer { get; set; }
        public DateTime CreationDate { get; }
        public DateTime LastStateChangeDate { get; }
        public ITaskLocation Location
        {
            get => _Location;
            set => OnPropertyChange(ref _Location, value);
        }
        public Guid ID { get; }
        //public IEditableTreeNode<ITask> Parent { get; }
        public IEnumerable<ITask> Items { get; } //?
        public IProgress Progress { get; set; } // как-то выщитываем

        public TimeSpan Duration { get => _Duration; }

        public DateTime StartTime { get => _StartTime; }
        #endregion

        #region IEnumerable<ITask> metod
        //IEnumerator<ITask> IEnumerable<ITask>.GetEnumerator()
        //{
        //    foreach (ITask task in _SubTasks)
        //    {
        //        yield return task;
        //        foreach (ITask _task in (IEnumerable<ITask>)task)
        //        {
        //            yield return _task;
        //        }
        //    }
        //}
        #endregion

        #region IEnumerable
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotSupportedException();
        //}
        #endregion

        #region Public metods

        public void AddSubtask(ITask subtask)
        {
            AddRangeSubtask(Enumerable.Repeat(subtask, 1));
        }

        public void AddObserver(IEntity observer)
        {
            AddRangeObserver(Enumerable.Repeat(observer, 1));
        }

        public void AddDependency(ITask dependency)
        {
            AddRangeDependency(Enumerable.Repeat(dependency, 1));
        }

        public void RemoveSubtask(ITask subtask)
        {
            RemoveRangeSubtask(Enumerable.Repeat(subtask, 1));
        }

        public void RemoveObserver(IEntity observer)
        {
            RemoveRangeObserver(Enumerable.Repeat(observer, 1));
        }

        public void RemoveDependency(ITask dependency)
        {
            RemoveRangeDependency(Enumerable.Repeat(dependency, 1));
        }

        public void AddRangeSubtask(IEnumerable<ITask> subtasks)
        {
            OnPropertyCollectionChangedAdd(ref _Subtasks, subtasks, nameof(Subtasks));
        }

        public void AddRangeObserver(IEnumerable<IEntity> observers)
        {
            OnPropertyCollectionChangedAdd(ref _Observers, observers, nameof(Observers));
        }

        public void AddRangeDependency(IEnumerable<ITask> dependencies)
        {
            OnPropertyCollectionChangedAdd(ref _Dependencies, dependencies, nameof(Dependencies));
        }

        public void RemoveRangeSubtask(IEnumerable<ITask> subtasks)
        {
            OnPropertyCollectionChangedRemove(ref _Subtasks, subtasks, nameof(Subtasks));
        }

        public void RemoveRangeObserver(IEnumerable<IEntity> observers)
        {
            OnPropertyCollectionChangedRemove(ref _Observers, observers, nameof(Observers));
        }

        public void RemoveRangeDependency(IEnumerable<ITask> dependencies)
        {
            OnPropertyCollectionChangedRemove(ref _Dependencies, dependencies, nameof(Dependencies));
        }
        public bool Equals(ITask other)
        {
            if (other != null)
            {
                return other.ID == ID;
            }
            return false;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
