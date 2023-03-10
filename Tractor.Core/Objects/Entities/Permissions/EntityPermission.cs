using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tractor.Core.Objects.Entities.Permissions
{
    class EntityPermission : IEntityPermission
    {
        private AccessType _AccessType;
        private IEntity _Entity;

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        private void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
        {
            if (!Equals(field, newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public IEntity Entity 
        { 
            get => _Entity; 
            set => OnPropertyChange(ref _Entity, value); 
        }
        public AccessType AccessType 
        { 
            get => _AccessType;
            set => OnPropertyChange(ref _AccessType, value); 
        }

        public Guid ID { get; }

        public EntityPermission(Guid id)
        {
            ID = id;
        }

        public bool Equals(IPermission other)
        {
            return (ID == other.ID && _Entity.Equals(other));
        }

        public object Clone()
        {
            var result = new EntityPermission(ID);
            result._Entity = _Entity;
            result._AccessType = _AccessType;
            return result;
        }
    }
}
