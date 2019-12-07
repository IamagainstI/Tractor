﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;

namespace Tractor.Core.Routers.Command
{
    public class GetCommand : ICommand
    {
        private ProgressState _ProgressState;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Guid> Path { get; set; }
        public IEntity Entity { get; set; }
        public IDataBase DataBase { get; set; }
        public Guid ID { get; }
        public ProgressState Progress
        {
            get => _ProgressState;
            set => OnPropertyChange(ref _ProgressState, value);
        }

        public GetCommand(Guid id)
        {
            ID = id;
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
