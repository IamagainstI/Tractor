using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Collections;

namespace Tractor.Core.Objects.Entities.Permissions
{
    public interface ISecurityObject
    {
        ObservableCollection<IPermission> Permissions { get; }
    }
}
