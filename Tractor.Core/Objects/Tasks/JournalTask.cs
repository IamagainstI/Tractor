using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using EmptyBox.Collections.Generic;
using EmptyBox.Collections.ObjectModel;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Tasks.Locations;
using System.Linq;
using Tractor.Core.Objects.Descriptions;
using Tractor.Core.Collections;

namespace Tractor.Core.Objects.Tasks
{
    public class JournalTask : IMeetingTask
    {
        #region Private objects
        private string _Name;
        private IProgress _Progress;
        private IDescription _Description;
        private IEntity _Performer;
        private IEntity _Producer;
        private ITaskLocation _Location;
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
        public ObservableCollection<IEntity> Participants { get; } = new ObservableCollection<IEntity>();
        public ObservableDictionary<IEntity, bool> CheckList { get; } = new ObservableDictionary<IEntity, bool>();
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
        public DateTime CreationDate { get; }
        public DateTime LastStateChangeDate { get; }
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
        public JournalTask(Guid id)
        {
            ID = id;
            Tasks.CollectionChanged += OnCollectionChanged;
            Tasks.PropertyChanging += OnCollectionPropertyChanging;
            Dependencies.CollectionChanged += OnCollectionChanged;
            Dependencies.PropertyChanging += OnCollectionPropertyChanging;
            Observers.CollectionChanged += OnCollectionChanged;
            Observers.PropertyChanging += OnCollectionPropertyChanging;
            Participants.CollectionChanged += OnCollectionChanged;
            Participants.PropertyChanging += OnCollectionPropertyChanging;
            CheckList.CollectionChanged += OnCollectionChanged;
            CheckList.PropertyChanging += OnCollectionPropertyChanging;
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

        #region Public methods
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
        public object Clone()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

