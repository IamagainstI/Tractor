using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Collections;

namespace Tractor.Core.Objects.Tasks
{
    public interface ITaskStorage
    {
        ObservableCollection<ITask> Tasks { get; }
    }
}
