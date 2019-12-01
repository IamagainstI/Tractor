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
         where T : IEquatable<T>
        {
            if (true)
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        public EntityRole(Guid id)
        {
            ID = id;
        }
    }
}
