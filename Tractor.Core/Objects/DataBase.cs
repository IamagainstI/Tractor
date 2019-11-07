using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;

namespace Tractor.Core.Objects
{
    public class DataBase
    {
        public List<Project> Projects { get; }
        public List<IEntity> Entities { get; }

        public DataBase()
        {
            Projects = new List<Project>();
            Entities = new List<IEntity>();
        }
    }
}
