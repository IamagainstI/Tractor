using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Entities.Permissions;

namespace Tractor.Core.Routers.Command
{
    public interface ICommand : INotifyPropertyChanged
    {
        List<Guid> Path { get; set; }
        IEntity Entity { get; set; }
        IDataBase DataBase { get; set; }
        Guid ID { get; }
        ProgressState Progress { get; set; } 
    }
}
