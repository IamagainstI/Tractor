using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    class ManualUpdatedProgress : IManualUpdatedProgress
    {        
        private double _ProgressPercentage;
        private DateTime _TimeLastchangeProgress;
        private bool _TaskCompleted;
        public double ProgressPercentage
        {
            get => _ProgressPercentage;
            set => OnPropertyChange(ref _ProgressPercentage, value);
        }

        public DateTime TimeLastChangeProgress
        {
            get => _TimeLastchangeProgress;
            set => OnPropertyChange(ref _TimeLastchangeProgress, value);
        }

        public bool TaskCompleted 
        { 
            get => _TaskCompleted; 
            set => OnPropertyChange(ref _TaskCompleted, value); 
        }
        public Guid ID { get; }

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

        public bool Equals(IProgress other)
        {
            return ID == other.ID;
        }
    }
}
