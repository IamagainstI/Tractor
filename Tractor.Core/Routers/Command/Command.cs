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
        public AccessType AccessType { get; set; }
        public string Command { get; set; }
        public IEntity Entity { get; set; }
        public IDataBase DataBase { get; set; }


    }
}
