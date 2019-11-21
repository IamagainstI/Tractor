using EmptyBox.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Progress
{
    public class TaskBasedProgress : IProgress
    {
        public Progress Percentage
        {
            get
            {
                foreach (ITask task in Tasks)
                {
                    task.Progress.Percentage
                }
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

        public void ProgressChanged(IProgress Difference)
        {
            throw new NotImplementedException();
        }
    }
}
