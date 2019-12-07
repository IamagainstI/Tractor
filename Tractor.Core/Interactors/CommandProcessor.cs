using System;
using System.Collections.Generic;
using System.Text;
using EmptyBox.Automation;
using Tractor.Core.Routers.Command;
using Tractor.Core.Objects.Difference;
using System.Linq;
using Tractor.Core.Objects.DataBases;

namespace Tractor.Core.Interactors
{
    public class CommandProcessor : Pipeline<ICommand, ICommand>, IPipelineIO<ICommand, IDifference>, IPipelineOutput<GetCommand>
    {
        private event EventHandler<IDifference> IDifference_Output;
        private event EventHandler<GetCommand> Command_Output;

        event EventHandler<IDifference> IPipelineOutput<IDifference>.Output
        {
            add => IDifference_Output += value;
            remove => IDifference_Output -= value;
        }
        event EventHandler<GetCommand> IPipelineOutput<GetCommand>.Output
        {
            add => Command_Output += value;
            remove => Command_Output -= value;
        }

        EventHandler<ICommand> IPipelineInput<ICommand>.Input => CommandHandler;

        private void CommandHandler(object sender, ICommand Command)
        {
            Type CommandType = Command.GetType();
            if (Command is SetCommand)
            {
                IDifference difference = new Difference(new Guid())
                {
                    ChangedObject = (Command as SetCommand).NewValue,
                    Entity = (Command as SetCommand).Entity,
                    NewValue = (object)(Command as SetCommand).DataBase.Projects.FirstOrDefault(x => x.ID == (Command as SetCommand).Path.Last()),
                    OldValue = (object)(Command as SetCommand).DataBase.Projects.FirstOrDefault(x => x.ID == (Command as SetCommand).Path.Last())
                };
                IDifference_Output?.Invoke(sender, difference);
            }
            else if (Command is RelocateCommand)
            {
                Guid oldPathGuid = (Command as RelocateCommand).Path[(Command as SetCommand).Path.Count - 2];
                Guid newPathGuid = (Command as RelocateCommand).NewPath[(Command as SetCommand).Path.Count - 2];
                IDifference difference = new Difference(new Guid())
                {
                    ChangedObject = Command.DataBase.Projects.FirstOrDefault(x => x.ID == ((Command as SetCommand).Path.Last())),
                    NewValue = Command.DataBase.Projects.FirstOrDefault(x => x.ID == newPathGuid),
                    OldValue = Command.DataBase.Projects.FirstOrDefault(x => x.ID == oldPathGuid),
                    Entity = Command.Entity
                };
                IDifference_Output?.Invoke(sender, difference);
            }
            else if (Command is GetCommand)
            {
                Command_Output?.Invoke(sender, (Command as GetCommand));
            }
               
        }

    }
}
