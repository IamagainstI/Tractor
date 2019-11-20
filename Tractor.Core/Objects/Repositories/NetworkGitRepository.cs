using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Credentials;

namespace Tractor.Core.Objects.Repositories
{
    public class NetworkGitRepository : INetworkRepository
    {
        public ICredentials Credentials => throw new NotImplementedException();
        string Location { get; set; }

        public bool Equals(IRepository other)
        {
            throw new NotImplementedException();
        }
    }
}
