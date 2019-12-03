using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public class BaseProgress : IProgress
    {
        private double _ProgressPercentage;
        private DateTime _TimeLastchangeProgress;
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

        public BaseProgress(Guid id)
        {
            ID = id;
        }

        public DateTime TimeLastChangeProgress
        {
            get => _TimeLastchangeProgress;
            set => OnPropertyChange(ref _TimeLastchangeProgress, value);
        }
        public double ProgressPercentage
        {
            get => _ProgressPercentage;
            set => OnPropertyChange(ref _ProgressPercentage, value);
        }
        public Guid ID { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public bool Equals(IProgress other)
        {
            return other.ID == ID;
        }

        public object Clone()
        {
            BaseProgress result = new BaseProgress(ID);
            result.ProgressPercentage = ProgressPercentage;
            result.TimeLastChangeProgress = TimeLastChangeProgress;
            return result;
        }
    }
}
