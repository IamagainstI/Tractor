using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Credentials;

namespace Tractor.Core.Objects.Repositories
{
    class GoogleDriveStorageRepository : ICloudStarageRepository
    {
        public ICredentials Credentials => throw new NotImplementedException();
    }
}
