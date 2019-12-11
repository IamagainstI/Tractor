using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tractor.Core.Objects.Entities.Permissions
{
    class EntityRolePermission : IEntityRolePermission
    {
        private IEntityRole _EntityRole;
        private AccessType _AccessType;

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

        public IEntityRole EntityRole
        { 
            get => _EntityRole; 
            set => OnPropertyChange(ref _EntityRole, value); 
        }
        public AccessType AccessType 
        { 
            get => _AccessType; 
            set => OnPropertyChange(ref _AccessType, value); 
        }

        public Guid ID { get; }

        public EntityRolePermission(Guid id)
        {
            ID = id;
        }

        public bool Equals(IPermission other)
        {
            return (ID.Equals(other.ID));
        }

        public object Clone()
        {
            var result = new EntityRolePermission(ID);
            result._EntityRole = _EntityRole;
            result._AccessType = _AccessType;
            return result;
        }
    }
}
