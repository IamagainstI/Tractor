using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Projects;

namespace Tractor.Core.Objects.Difference
{
    public interface IProjectDifference
    {
        IProject Project { get; }
    }
}
