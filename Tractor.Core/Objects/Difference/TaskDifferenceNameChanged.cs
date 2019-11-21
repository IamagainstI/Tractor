using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Difference
{
    public class TaskDifferenceNameChanged : ITaskDifferenceNameChanged
    {
        public string NewName { get; }

        public ITask Task { get; }

        public DateTime CreationDate { get; }

        public TaskDifferenceNameChanged(string @new, ITask task, DateTime creationDate)
        {
            NewName = @new;
            Task = task;
            CreationDate = creationDate;
        }

        public int CompareTo(IDifference other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IDifference other)
        {
            throw new NotImplementedException();
        }

        public byte[] GetDifferenceHash()
        {
            throw new NotImplementedException();
        }
    }
}
