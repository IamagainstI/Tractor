using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tractor.Core.Objects
{
    public class EntityRole : IEntityRole
    {
        private string _Name;
        public Guid ID { get; }
        public string Name 
        { 
            get => _Name; 
            set => OnPropertyChange(ref _Name, value); 
        }

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

        public object Clone()
        {
            var result = new EntityRole(ID);
            result._Name = _Name;
            return result;
        }

        public EntityRole(Guid id)
        {
            ID = id;
        }
    }
}
