using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;

namespace Tractor.Core
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
        
        public Project(Guid id)
        {
            ID = id;
            Subprojects = new List<IProject>();
            Tasks = new List<ITask>();
            Performers = new Dictionary<IEntity, IEntityRole>();
        }
    }
}
