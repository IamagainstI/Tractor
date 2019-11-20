using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Credentials;

namespace Tractor.Core.Objects.Repositories
{
    class GoogleDriveStorageRepository : ICloudStorageRepository
    {
        public ICredentials Credentials => throw new NotImplementedException();

        public bool Equals(IRepository other)
        {
            throw new NotImplementedException();
        }
    }
}
