using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tractor.Core.Objects.Entities
{
    public class AnonymousEntity : IEntity
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

        public AnonymousEntity(Guid id)
        {
            ID = id;
        }

        public bool Equals(IEntity other)
        {
            return (ID.Equals(ID) && Name.Equals(other.Name));
        }

        object ICloneable.Clone()
        {
            var result = new AnonymousEntity(ID);
            result._Name = Name;
            return result;
        }
    }
}
