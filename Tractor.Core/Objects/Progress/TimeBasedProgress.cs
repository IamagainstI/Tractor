﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public class TimeBasedProgress : ITimeBasedProgress
    {
        private DateTime _TimeLastchangeProgress;
        private double _ProgressPercentage;
        private TimeSpan _Interval;
        private DateTime _StartTime;
        private DateTime _EndTime;
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
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public TimeBasedProgress(Guid id)
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
        public TimeSpan Interval
        {
            get => _Interval;
            set => OnPropertyChange(ref _Interval, value);
        }
        public DateTime StartTime
        {
            get => _StartTime;
            set => OnPropertyChange(ref _StartTime, value);
        }
        public DateTime EndTime
        {
            get => _EndTime;
            set => OnPropertyChange(ref _EndTime, value);
        }

        public Guid ID { get; }

        public bool Equals(IProgress other)
        {
            return ID.Equals(other.ID) && ProgressPercentage.Equals(other.ProgressPercentage) &&
                Interval.Equals((other as TimeBasedProgress).Interval) && StartTime.Equals((other as TimeBasedProgress).StartTime)
                && EndTime.Equals((other as TimeBasedProgress).EndTime);
        }

        public object Clone()
        {
            var result = new TimeBasedProgress(ID);
            result.TimeLastChangeProgress = TimeLastChangeProgress;
            result.StartTime = StartTime;
            result.ProgressPercentage = ProgressPercentage;
            result.EndTime = EndTime;
            result.Interval = Interval;
            return result;
        }
    }
}
