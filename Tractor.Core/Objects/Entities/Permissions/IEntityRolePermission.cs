using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Entities.Permissions
{
    public interface IEntityRolePermission : IPermission
    {
        IEntityRole EntityRole { get; set; }
    }
}
