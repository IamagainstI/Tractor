using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Repositories;

namespace Tractor.Core.Objects.DataBases
{
    public class LocalDataBase : IDataBase
    {
        public TractorAccount Account { get; set; }
        public IEnumerable<IEntity> Entities { get; }
        public IEnumerable<IProject> Projects { get; }
        public IEnumerable<IPermission> Permissions { get; }
        public IEnumerable<IRepository> Repositories { get; }
        public IEnumerable<IDifference> History { get; }
    }
}
