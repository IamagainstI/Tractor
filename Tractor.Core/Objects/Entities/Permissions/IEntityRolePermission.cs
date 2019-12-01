using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Entities.Permissions
{
    interface IEntityRolePermission : IPermission
    {
        IEntityRole EntityRole { get; set; }
    }
}
