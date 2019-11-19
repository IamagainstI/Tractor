using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Progress;

namespace Tractor.Core.Objects
{
    public delegate void ProjectChanged();

    public interface IProject : IStuff
    {
        string Name { get; }
        IProgress Progress { get; }
        IEnumerable<IProject> Subprojects { get; }
        IDescription Description { get; }
        IEnumerable<ITask> Tasks { get; }
        IDictionary<IEntity, IEntityRole> Performers { get; }
        void AddTask(ITask Task);
        void RemoveTask(ITask Task);
        void AddEntity(IEntity Entity, IEntityRole EntityRole);
        void RemoveEntity(IEntity Entity);
        void ProjectChanged(IProject Difference);
    }
}
