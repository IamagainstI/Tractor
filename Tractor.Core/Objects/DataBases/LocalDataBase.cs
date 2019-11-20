using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Repositories;

namespace Tractor.Core.Objects.DataBases
{
    public class LocalDataBase : IDataBase
    {
        public TractorAccount Account => throw new NotImplementedException();

        public IEnumerable<IEntity> Entities => throw new NotImplementedException();

        public IEnumerable<IProject> Projects => throw new NotImplementedException();

        public IEnumerable<IPermission> Permissions => throw new NotImplementedException();

        public IEnumerable<IRepository> Repositories => throw new NotImplementedException();

        public IEnumerable<IDifference> History => throw new NotImplementedException();
    }
}
