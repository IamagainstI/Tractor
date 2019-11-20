using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Repositories
{
    public interface ILocalRepository : IRepository
    {
        string Path { get; }
    }
}
