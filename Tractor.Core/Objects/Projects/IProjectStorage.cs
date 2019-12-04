using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Collections;

namespace Tractor.Core.Objects.Projects
{
    public interface IProjectStorage
    {
        ObservableCollection<IProject> Projects { get; }
    }
}
