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

namespace Tractor.Core.Objects.Projects
{
    public class UsualProject : IProject
    {
        #region Private events
        private event ObservableTreeNodeItemChangeHandler<IProject> _SubprojectsItemAdded;
        private event ObservableTreeNodeItemChangeHandler<IProject> _SubprojectsItemRemoved;
        private event ObservableTreeNodeItemChangeHandler<ITask> _TasksItemAdded;
        private event ObservableTreeNodeItemChangeHandler<ITask> _TasksItemRemoved;
        #endregion

        #region Private objects
        private string _Name;
        private IProgress _Progress;
        private List<IProject> _Subprojects;
        private IDescription _Description;
        private List<ITask> _Tasks;
        private Dictionary<IEntity, IEntityRole> _Performers;
        private IProject _Parent;
        private List<IPermission> _Permissions;
        #endregion

        #region IObservableTreeNode<IProject> events
        event ObservableTreeNodeItemChangeHandler<IProject> IObservableTreeNode<IProject>.ItemAdded
        {
            add => _SubprojectsItemAdded += value;
            remove => _SubprojectsItemAdded -= value;
        }
        event ObservableTreeNodeItemChangeHandler<IProject> IObservableTreeNode<IProject>.ItemRemoved
        {
            add => _SubprojectsItemRemoved += value;
            remove => _SubprojectsItemRemoved -= value;
        }
        #endregion

        #region IObservableTreeNode<ITask> events
        event ObservableTreeNodeItemChangeHandler<ITask> IObservableTreeNode<ITask>.ItemAdded
        {
            add => _TasksItemAdded += value;
            remove => _TasksItemAdded -= value;
        }
        event ObservableTreeNodeItemChangeHandler<ITask> IObservableTreeNode<ITask>.ItemRemoved
        {
            add => _TasksItemRemoved += value;
            remove => _TasksItemRemoved -= value;
        }
        #endregion

        #region ITreeNode<IProject> objects
        IEnumerable<IProject> ITreeNode<IProject>.Items => Subprojects;
        #endregion

        #region ITreeNode<ITask> objects
        IEnumerable<ITask> ITreeNode<ITask>.Items => Tasks;
        #endregion

        #region Public events
        public event ProjectChangeEventHandler ProjectChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Public objects
        public string Name
        {
            get => _Name;
            set => OnPropertyChange(ref _Name, value);
        }
        public IProgress Progress { get; set; }
        public IEnumerable<IProject> Subprojects { get; }
        public IDescription Description { get; set; }
        public IEnumerable<ITask> Tasks { get; }
        public IReadOnlyDictionary<IEntity, IEntityRole> Performers { get; }
        public Guid ID { get; }
        public IProject Parent { get; set; }
        public IEnumerable<IPermission> Permissions { get; }
        #endregion

        #region Protected methods
        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
            where T : IEquatable<T>
        {
            if (!field.Equals(newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
                IProjectDifference difference = null;
                switch (name)
                {
                    case nameof(Name):
                        difference = new ProjectDifferenceNameChanged(this, (string)(object)newValue, DateTime.Now);
                        break;
                }
                ProjectChanged?.Invoke(difference);
            }
        }
        #endregion

        #region IEnumerable<IProject> methods
        IEnumerator<IProject> IEnumerable<IProject>.GetEnumerator()
        {
            foreach (IProject proj in Subprojects)
            {
                yield return proj;
                foreach (IProject _proj in (IEnumerable<IProject>)proj)
                {
                    yield return proj;
                }
            }
        }
        #endregion

        #region IEnumerable<ITask> methods
        IEnumerator<ITask> IEnumerable<ITask>.GetEnumerator()
        {
            foreach (ITask task in Tasks)
            {
                yield return task;
                foreach (ITask _task in task)
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

        #region Public methods
        public void AddEntity(IEntity Entity, IEntityRole EntityRole)
        {
            throw new NotImplementedException();
        }

        public void AddTask(ITask Task)
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
        #endregion
    }
}
