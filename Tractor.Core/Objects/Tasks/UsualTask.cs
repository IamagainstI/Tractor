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
using Tractor.Core.Collections;
using Tractor.Core.Objects.Descriptions;
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
        private IDescription _Description;
        private ITask _Parent;
        private IEntity _Performer;
        private IEntity _Producer;
        private ITaskLocation _Location;
        private IProgress _Progress;
        private DateTime _CreationDate;
        private DateTime _LastStateChangeDate;
        #endregion

        #region Public events
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
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
        public ObservableCollection<ITask> Tasks { get; } = new ObservableCollection<ITask>();
        public ObservableCollection<IEntity> Observers { get; } = new ObservableCollection<IEntity>();
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
        public DateTime CreationDate 
        {
            get => _CreationDate;
            set => OnPropertyChange(ref _CreationDate, value);
        }
        public DateTime LastStateChangeDate 
        {
            get => _LastStateChangeDate;
            set => OnPropertyChange(ref _LastStateChangeDate, value);
        }
        public ITaskLocation Location
        {
            get => _Location;
            set => OnPropertyChange(ref _Location, value);
        }
        public Guid ID { get; }
        public IProgress Progress
        {
            get => _Progress;
            set => OnPropertyChange(ref _Progress, value);
        }
        public ITaskStorage Parent { get; set; }
        #endregion

        #region Constructors
        public UsualTask(Guid id)
        {
            ID = id;
            Tasks.CollectionChanged += OnCollectionChanged;
            Tasks.PropertyChanging += OnCollectionPropertyChanging;
            Observers.CollectionChanged += OnCollectionChanged;
            Observers.PropertyChanging += OnCollectionPropertyChanging;
        }
        #endregion

        #region Private methods
        private string GetCollectionName(object collection)
        {
            if (collection == Tasks)
            {
                return nameof(Tasks);
            }
            else if (collection == Observers)
            {
                return nameof(Observers);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(sender, e);
        }

        private void OnCollectionPropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(GetCollectionName(sender)));
        }

        private void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
        {
            if (!Equals(field, newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region Public metod
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
            var result = new UsualTask(ID);
            result._Name = _Name;
            foreach (var obs in Observers)
            {
                result.Observers.Add(obs);
            }
            result._Parent = _Parent;
            result._Performer = _Performer;
            result._Producer = _Producer;
            result._Progress = _Progress;
            foreach (var item in Tasks)
            {
                result.Tasks.Add(item);
            }
            result._CreationDate = _CreationDate;
            result._Description = _Description;
            result._LastStateChangeDate = _LastStateChangeDate;
            result._Location = _Location;
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is ITask task)
            {
                return Equals(task);
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
