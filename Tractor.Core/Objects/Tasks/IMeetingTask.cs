using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Collections;

namespace Tractor.Core.Objects.Tasks
{
    public interface IMeetingTask : ITask
    {
        ObservableCollection<IEntity> Participants { get; }
        ObservableDictionary<IEntity, bool> CheckList { get; }
    }
}
