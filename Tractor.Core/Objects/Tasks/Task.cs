using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;

namespace Tractor.Core.Objects
{
    public class Task : ITask
    {
        IEnumerable<ITask> ITask.Subtasks => Subtasks;
        IEnumerable<ITask> ITask.Dependencies => Dependencies;

        public Guid ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ITask> Subtasks { get; }
        public IEntity Performer { get; set; }
        public IEntity Producer { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastStateChangeDate { get; set; }
        public TaskState State { get; set; }
        public ITaskLocation Location { get; set; }
        public List<ITask> Dependencies { get; }

        public Task(Guid id)
        {
            ID = id;
        }
    }
}
