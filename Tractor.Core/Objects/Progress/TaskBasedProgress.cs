using EmptyBox.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Progress
{

    public class TaskBasedProgress : IProgress
    {
        private DateTime _TimeLastChangeProgress;
        #region Public events
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        public double ProgressPercentage
        {
            get
            {
                double progress = 0;
                foreach (var a in Tasks.Tasks)
                {
                    progress += a.Progress.ProgressPercentage;
                }
                return progress / Tasks.Tasks.Count();
            }
        }

        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
        {
            if (!Equals(field, newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        public DateTime TimeLastChangeProgress 
        {
            get => _TimeLastChangeProgress;
            set => OnPropertyChange(ref _TimeLastChangeProgress, value);
        }
        public ITaskStorage Tasks { get; set; }
        public Guid ID { get; }
        public TaskBasedProgress(Guid id)
        {
            ID = id;
        }
        public bool Equals(IProgress other)
        {
            return ID == other.ID;
        }

        public object Clone()
        {
            var result = new TaskBasedProgress(ID);
            result._TimeLastChangeProgress = _TimeLastChangeProgress;
            return result;
        }
    }
}
