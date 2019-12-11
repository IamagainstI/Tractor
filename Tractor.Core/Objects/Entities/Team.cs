using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tractor.Core.Model;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Entities;
using System.Linq;
using Tractor.Core.Collections;

namespace Tractor.Core.Objects
{
    public class Team : ITeam
    {
        #region Private objects
        private string _Name;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ObservableDictionary<IEntity, IEntityRole> Members { get; } = new ObservableDictionary<IEntity, IEntityRole>();

        public string Name 
        { 
            get => _Name;
            set => OnPropertyChange(ref _Name, value);
        }

        public Guid ID { get; }

        #region Constructors
        public Team(Guid id)
        {
            ID = id;
        }
        #endregion

        #region Private methods
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

        public bool Equals(IEntity other)
        {

            return ID.Equals(other.ID) && Members.Equals((other as ITeam).Members);
        }

        public object Clone()
        {
            Team result = new Team(ID)
            {
                _Name = _Name
            };
            foreach (var item in Members)
            {
                result.Members.Add(item);
            }
            return result;
        }
    }
}
