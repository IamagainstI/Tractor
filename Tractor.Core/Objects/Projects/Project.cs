using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.Progress;

namespace Tractor.Core.Objects
{
    public class Project : IProject
    {
        IDictionary<IEntity, IEntityRole> IProject.Performers => Performers;
        IEnumerable<IProject> IProject.Subprojects => Subprojects;
        IEnumerable<ITask> IProject.Tasks => Tasks;

        public Guid ID { get;  }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<IProject> Subprojects { get; }
        public IList<ITask> Tasks { get; }
        

        public Dictionary<IEntity, IEntityRole> Performers { get;  }

        public IProgress Progress => throw new NotImplementedException();

        IDescription IProject.Description => throw new NotImplementedException();

        public Project(Guid id)
        {
            ID = id;
            Subprojects = new List<IProject>();
            Tasks = new List<ITask>();
            Performers = new Dictionary<IEntity, IEntityRole>();
        }

        public void AddTask(ITask Task)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(ITask Task)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(IEntity Entity, IEntityRole EntityRole)
        {
            throw new NotImplementedException();
        }

        public void RemoveEntity(IEntity Entity)
        {
            throw new NotImplementedException();
        }

        public void ProjectChanged(IProject Difference)
        {
            throw new NotImplementedException();
        }
    }
}
