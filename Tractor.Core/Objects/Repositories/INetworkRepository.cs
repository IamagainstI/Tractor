using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Credentials;

namespace Tractor.Core.Objects.Repositories
{
    public interface INetworkRepository : IRepository
    {
        ICredentials Credentials { get; }
    }
}
