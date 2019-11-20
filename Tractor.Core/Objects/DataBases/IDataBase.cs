using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Repositories;

namespace Tractor.Core.Objects.DataBases
{
    public interface IDataBase
    {
        TractorAccount Account { get; }
        IEnumerable<IEntity> Entities { get; }
        IEnumerable<IProject> Projects { get; }
        IEnumerable<IPermission> Permissions { get; }
        IEnumerable<IRepository> Repositories { get; }
        IEnumerable<IDifference> History { get; }
    }
}
