using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Repositories;

namespace Tractor.Core.Objects.Difference
{
    public interface IRepositoryDifference : IDifference
    {
        IRepository Repository { get; }
    }
}
