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
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Projects
{
    public class UsualProject : IProject
    {
        #region Private objects
        private string _Name;
        private IDescription _Description;
        private IProject _Parent;
        #endregion

        #region Public events
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion

        #region Public objects
        public string Name
        {
            get => _Name;
            set => OnPropertyChange(ref _Name, value);
        }
        public TaskBasedProgress Progress { get; set; }
        public ObservableCollection<IProject> Projects { get; } = new ObservableCollection<IProject>();
        public IDescription Description 
        {
            get => _Description;
            set => OnPropertyChange(ref _Description, value);
        }
        public ObservableCollection<ITask> Tasks { get; } = new ObservableCollection<ITask>();
        public ObservableDictionary<IEntity, IEntityRole> Participants { get; } = new ObservableDictionary<IEntity, IEntityRole>();
        public Guid ID { get; }
        public IProjectStorage Parent { get; set; }
        public ObservableCollection<IPermission> Permissions { get; } = new ObservableCollection<IPermission>();

        #endregion

        #region Protected methods
        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
        {
            if (!Equals(field, newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region Constructors
        public UsualProject(Guid id)
        {
            ID = id;
        }
        #endregion

        #region Public methods

        public bool Equals(IProject other)
        {
            return ID.Equals(other.ID) && Name.Equals(other.Name)
                && Projects.Equals(other.Projects) && Description.Equals(other.Description)
                && Tasks.Equals(other.Tasks) && Participants.Equals(other.Participants) &&
                Parent.Equals(other.Parent) && Permissions.Equals(Permissions);
        }

        public object Clone()
        {
            UsualProject result = new UsualProject(ID);
            result._Name = _Name;
            result._Parent = _Parent;
            foreach (var item in Participants)
            {
                result.Participants.Add(item);
            }
            foreach (var item in Permissions)
            {
                result.Permissions.Add(item);
            }
            result.Progress = Progress;
            foreach (var item in Tasks)
            {
                result.Tasks.Add(item);
            }
            foreach (var item in Projects)
            {
                result.Projects.Add(item);
            }
            result._Description = _Description;
            return result;
        }

        #endregion
    }
}
