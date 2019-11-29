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

namespace Tractor.Core.Objects
{
    public class Team : ITeam
    {


        #region
        private Dictionary<IEntity, IEntityRole> _Members;
        private string _Name;
        #endregion

        #region Private Metods
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
        private void OnPropertyCollectionChangedAdd(ref Dictionary<IEntity, IEntityRole> field, IDictionary<IEntity, IEntityRole> newItems, [CallerMemberName]string name = null)
        {
            if (newItems != null)
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(name)));
                field.Concat(newItems);
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newItems, null));
            }
        }
        private void OnPropertyCollectionChangedRemove(ref Dictionary<IEntity, IEntityRole> field, IDictionary<IEntity, IEntityRole> items, [CallerMemberName]string name = null)
        {
            if (items != null)
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(name)));
                foreach (var item in field)
                {
                    field.Remove(item.Key);
                }
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, null, items));
            }
        }
        #endregion

        public IDictionary<IEntity, IEntityRole> Members { get => _Members; }

        public string Name { get => _Name; }

        public Guid ID { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void AddMember(IDictionary<IEntity, IEntityRole> membres)
        {
            OnPropertyCollectionChangedAdd(ref _Members, membres);
        }

        public bool Equals(IEntity other)
        {
            return other.ID == ID;
        }

        public void RemoveMember(IDictionary<IEntity, IEntityRole> membres)
        {
            OnPropertyCollectionChangedRemove(ref _Members, membres);
        }
    }
}
