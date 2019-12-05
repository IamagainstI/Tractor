using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Entities.Permissions;

namespace Tractor.Core.Routers.Command
{
    class Command
    {
        public AccessType accessType { get; set; }
        public string Commands { get; set; }
        public IEntity Entity { get; set; }
        public LocalDataBase LocalDataBase { get; set; }


    }
}
