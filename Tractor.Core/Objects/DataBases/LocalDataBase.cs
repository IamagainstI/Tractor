using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Collections;
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
        public ObservableCollection<IEntity> Entities { get; }
        public ObservableCollection<IProject> Projects { get; }
        public ObservableCollection<IPermission> Permissions { get; }
        public ObservableCollection<IRepository> Repositories { get; }
        public ObservableCollection<IDifference> History { get; }
    }
}
