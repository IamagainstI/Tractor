using EmptyBox.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Progress
{
    
    public class TaskBasedProgress : IProgress
    {
        private double _ProgressPercentage;
        #region Public events
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion        
        public double ProgressPercentage
        {
            get
            {
                int count = 0;
                foreach (ITask task in Tasks)
                {
                    _ProgressPercentage += task.Progress.ProgressPercentage;
                    count++;
                }
                return _ProgressPercentage /= count;
            }
        }

        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
            where T : IEquatable<T>
        {
            if (!field.Equals(newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        public DateTime TimeLastChangeProgress { get; set; }

        public ITreeNode<ITask> Tasks { get; }

        public TaskBasedProgress(ITreeNode<ITask> tasks)
        {
            Tasks = tasks;
        }

        public bool Equals(IProgress other)
        {
            return other.ProgressPercentage == ProgressPercentage;
        }
    }
}
