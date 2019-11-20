using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Repositories
{
    class LocalGitRepository : ILocalRepository
    {
        public string Path => throw new NotImplementedException();

        public bool Equals(IRepository other)
        {
            throw new NotImplementedException();
        }
    }
}
