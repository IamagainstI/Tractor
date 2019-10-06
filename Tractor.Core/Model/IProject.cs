using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Model
{
    public interface IProject : IStuff
    {
        string Name { get; }
        string Description { get; }
        IEnumerable<IProject> Subprojects { get; }
        IEnumerable<ITask> Tasks { get; }
        IDictionary<IEntity, IEntityRole> Performers { get; }
    }
}
