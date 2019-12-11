using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tractor.Core.Model;
using Tractor.Core.Objects.Entities;

namespace Tractor.Core.Objects
{
    public class TractorAccount : ITractorEntity
    {
        private string _Name;

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

        public TractorAccount(Guid id)
        {
            ID = id;
        }
       
        public Guid ID { get; }
        public string Name 
        { 
            get => _Name; 
            set => OnPropertyChange(ref _Name, value); 
        }
             
        public bool Equals(IEntity other)
        {
            return ID.Equals(other.ID) && Name.Equals(other.Name);
        }

        public bool CheckAvailability(DateTime dateTime, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            var result = new TractorAccount(ID)
            {
                _Name = _Name
            };
            return result;
        }
    }
}
