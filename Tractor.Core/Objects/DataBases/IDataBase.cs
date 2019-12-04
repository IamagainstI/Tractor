using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Collections;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Repositories;

namespace Tractor.Core.Objects.DataBases
{
    public interface IDataBase
    {
        TractorAccount Account { get; }
        ObservableCollection<IEntity> Entities { get; }
        ObservableCollection<IProject> Projects { get; }
        ObservableCollection<IPermission> Permissions { get; }
        ObservableCollection<IRepository> Repositories { get; }
        ObservableCollection<IDifference> History { get; }
    }
}
