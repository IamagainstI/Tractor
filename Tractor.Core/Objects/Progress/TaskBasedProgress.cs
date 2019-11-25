using EmptyBox.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Progress
{
    public class TaskBasedProgress : IProgress
    {
        private double _Percentage;

        public double Percentage
        {
            get
            {
                int count = 0;
                foreach (ITask task in Tasks)
                {
                    _Percentage += task.Progress.Percentage;
                    count++;
                }
                return _Percentage = _Percentage / count; 
            }
        }

        public DateTime TimeLastChangeProgress => throw new NotImplementedException();

        public ITreeNode<ITask> Tasks { get; }

        public TaskBasedProgress(ITreeNode<ITask> tasks)
        {
            Tasks = tasks;
        }

        public bool Equals(IProgress other)
        {
            throw new NotImplementedException();
        }
    }
}
