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
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks.Locations;

namespace Tractor.Core.Objects.Tasks
{
    public class EventTask : IEventTask
    {
        #region Private objects
        private string _Name;
        private IProgress _Progress;
        private IDescription _Description;
        private IEntity _Performer;
        private IEntity _Producer;
        private ITaskLocation _Location;
        private TimeSpan _Duration;
        private DateTime _StartTime;
        private DateTime _LastStageChangeDate;
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
        public ObservableCollection<ITask> Dependencies { get; } = new ObservableCollection<ITask>();
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
        public DateTime CreationDate { get; set; }
        public DateTime LastStateChangeDate 
        {
            get => _LastStageChangeDate;
            set => OnPropertyChange(ref _LastStageChangeDate, value);
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
        public TimeSpan Duration
        {
            get => _Duration;
            set => OnPropertyChange(ref _Duration, value);
        }
        public DateTime StartTime
        {
            get => _StartTime;
            set => OnPropertyChange(ref _StartTime, value);
        }
        public ITaskStorage Parent { get; set; }
        #endregion

        #region Constructors
        public EventTask(Guid id)
        {
            ID = id;
            Tasks.CollectionChanged += OnCollectionChanged;
            Tasks.PropertyChanging += OnCollectionPropertyChanging;
            Dependencies.CollectionChanged += OnCollectionChanged;
            Dependencies.PropertyChanging += OnCollectionPropertyChanging;
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
            else if (collection == Dependencies)
            {
                return nameof(Dependencies);
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

        #region Public methods
        public object Clone()
        {
            EventTask result = new EventTask(ID);
            result._Name = Name;
            result._Description = Description;
            result._Location = Location;
            result.Parent = Parent;
            result._Performer = Performer;
            result._Producer = Producer;
            result._Progress = Progress;
            result._Duration = Duration;
            result._StartTime = StartTime;
            foreach (var task in Tasks)
            {
                result.Tasks.Add(task);
            }
            foreach (var task in Dependencies)
            {
                result.Dependencies.Add(task);
            }
            foreach (var observer in Observers)
            {
                result.Observers.Add(observer);
            }
            return result;
        }

        public bool Equals(ITask other)
        {
            return ID == other.ID;
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
