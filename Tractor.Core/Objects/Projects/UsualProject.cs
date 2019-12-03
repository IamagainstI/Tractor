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
        private IProgress _Progress;
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
        public IProgress Progress { get; set; }
        public ObservableCollection<IProject> Projects { get; }
        public IDescription Description { get; set; }
        public ObservableCollection<ITask> Tasks { get; }
        public ObservableDictionary<IEntity, IEntityRole> Participants { get; }
        public Guid ID { get; }
        public IProjectStorage Parent { get; set; }
        public ObservableCollection<IPermission> Permissions { get; }

        #endregion

        #region Protected methods
        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
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

        #region Constructors
        public UsualProject(Guid id)
        {
            ID = id;
        }
        #endregion

        #region Public methods

        public bool Equals(IProject other)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            UsualProject result = new UsualProject(ID);
            //result._Name = _Name;
            //result._Parent = _Parent;
            //result._Participants = _Participants;
            //result._Permissions = _Permissions;
            //result._Progress = _Progress;
            //result._Tasks = _Tasks;
            //result._Subprojects = _Subprojects;
            //result._Description = _Description;
            return result;
        }

        #endregion
    }
}
