using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
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
        #region Private objects
        private string _Name;
        private List<ITask> _SubTasks;
        private List<IEntity> _Observers;
        private IDescription _Description;
        private ITask _Parent;
        private IEntity _Performer;
        private IEntity _Producer;
        private ITaskLocation _Location;
        private List<ITask> _Dependencies;
        private BaseProgress _Progress;
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
            if (true)
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
        public IEnumerable<ITask> SubTasks { get => _SubTasks; }
        public IEnumerable<ITask> Dependencies { get => _Dependencies; }
        public IList<IEntity> Observers { get => _Observers;  }
        public IEntity Performer
        {
            get => _Performer;
            set => OnPropertyChange(ref _Performer, value);
        }
        public IEntity Producer
        {
            get => _Producer;
            set => OnPropertyChange(ref _Producer, value);
        }
        public DateTime CreationDate { get; set; }
        public DateTime LastStateChangeDate { get; set; }
        public ITaskLocation Location
        {
            get => _Location;
            set => OnPropertyChange(ref _Location, value);
        }
        public Guid ID { get; }
        //public IEditableTreeNode<ITask> Parent { get ; }
        public IEnumerable<ITask> Items { get; } //?
        public IProgress Progress 
        {
            get => _Progress;
            set
            {
                if (true)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs("Progress"));
                    _Progress = (BaseProgress)value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Progress"));
                }
            }
        }
        #endregion

        #region Constructors
        public UsualTask(Guid id)
        {
            ID = id;
        }
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
        public void AddSubtask(IEnumerable<ITask> Subtask)
        {
            OnPropertyCollectionChangedAdd(ref _SubTasks, Subtask);
        }
        public void AddObserver(IEnumerable<IEntity> Obeserver)
        {
            OnPropertyCollectionChangedAdd(ref _Observers, Obeserver);
        }
        public void AddDependenci(IEnumerable<ITask> Dependenci)
        {
            OnPropertyCollectionChangedAdd(ref _Dependencies, Dependenci);
        }
        public void RemoveSubtask(IEnumerable<ITask> SubTask)
        {
            OnPropertyCollectionChangedRemove(ref _SubTasks, SubTask);
        }

        public void RemoveObserver(IEnumerable<IEntity> Observer)
        {
            OnPropertyCollectionChangedRemove(ref _Observers, Observer);
        }
        public void RemoveDependenci(IEnumerable<ITask> Dependenci)
        {
            OnPropertyCollectionChangedRemove(ref _Dependencies, Dependenci);
        }
        public bool Equals(ITask other)
        {
            if (other != null)
            {
                return other.ID == ID;
            }
            return false;
        }
        public void Add(ITask item)
        {
            throw new NotImplementedException(); //?
        }
        public void Remove(ITask item)
        {
            throw new NotImplementedException(); //?
        }

        public object Clone()
        {
            UsualTask result = new UsualTask(ID);
            result.CreationDate = CreationDate;
            result.Description = Description;
            result.LastStateChangeDate = LastStateChangeDate;
            result.Location = Location;
            result.Name = Name;
            result.Performer = Performer;
            result.Producer = Producer;
            result.Progress = Progress;
            return result;
        }
        #endregion
    }
}
