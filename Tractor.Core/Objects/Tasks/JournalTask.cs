using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Tasks
{
    class JournalTask : IMeetingTask
    {
        public IList<IEntity> Participants => throw new NotImplementedException();

        public IDictionary<IEntity, bool> CheckList => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public IEnumerable<ITask> Subtasks => throw new NotImplementedException();

        public IEnumerable<ITask> Dependencies => throw new NotImplementedException();

        public IList<IEntity> Observers => throw new NotImplementedException();

        public IEntity Performer => throw new NotImplementedException();

        public IEntity Producer => throw new NotImplementedException();

        public DateTime CreationDate => throw new NotImplementedException();

        public DateTime LastStateChangeDate => throw new NotImplementedException();

        public TaskState State => throw new NotImplementedException();

        public ITaskLocation Location => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();
    }
}
