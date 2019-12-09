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
        public ObservableCollection<IEntity> Entities { get; } = new ObservableCollection<IEntity>();
        public ObservableCollection<IProject> Projects { get; } = new ObservableCollection<IProject>();
        public ObservableCollection<IPermission> Permissions { get; } = new ObservableCollection<IPermission>();
        public ObservableCollection<IRepository> Repositories { get; } = new ObservableCollection<IRepository>();
        public ObservableCollection<IDifference> History { get; } = new ObservableCollection<IDifference>();
        public ObservableCollection<ITeam> Teams { get; } = new ObservableCollection<ITeam>();
    }
}
