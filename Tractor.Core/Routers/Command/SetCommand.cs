using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;

namespace Tractor.Core.Routers.Command
{
    public class SetCommand : ICommand
    {
        private ProgressState _ProgressState;

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<Guid> Path { get; set; }
        public IEntity Entity { get; set; }
        public IDataBase DataBase { get; set; }
        public object NewValue { get; set; }
        public Guid ID { get; }
        public SetCommand(Guid id)
        {
            ID = id;
        }
        public ProgressState Progress
        {
            get => _ProgressState;
            set => OnPropertyChange(ref _ProgressState, value);
        }
        private void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
        {
            if (!field.Equals(newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
