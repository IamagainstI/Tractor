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
    public class CommandProcessor : Pipeline<ICommand, ICommand>, IPipelineIO<ICommand, IDifference>, IPipelineOutput<DataRelocationInfo>, IPipelineOutput<GetCommand>
    {
        private event EventHandler<IDifference> IDifference_Output;
        private event EventHandler<GetCommand> Command_Output;
        private event EventHandler<DataRelocationInfo> DataRelocationInfo_Output;

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
        event EventHandler<DataRelocationInfo> IPipelineOutput<DataRelocationInfo>.Output
        {
            add => DataRelocationInfo_Output += value;
            remove => DataRelocationInfo_Output -= value;
        }

        EventHandler<ICommand> IPipelineInput<ICommand>.Input => CommandHandler;

        private void CommandHandler(object sender, ICommand Command)
        {
            Type CommandType = Command.GetType();
            if (Command is SetCommand setCommand)
            {
                IDifference difference = new Difference(Guid.NewGuid())
                {
                    ChangedObject = setCommand.DataBase.GetSpecifiedPath(setCommand.Path.Take(setCommand.Path.Count() - 1)).LastOrDefault(),
                    Entity = setCommand.Entity,
                    NewValue = setCommand.NewValue,
                    OldValue = setCommand.DataBase.GetSpecifiedPath(setCommand.Path).LastOrDefault()
                };
                IDifference_Output?.Invoke(sender, difference);
            }
            else if (Command is RelocateCommand relocateCommand)
            {
                DataRelocationInfo a = new DataRelocationInfo()
                {
                    OldStorage = relocateCommand.DataBase.GetSpecifiedPath(relocateCommand.Path).LastOrDefault(),
                    NewStorage = relocateCommand.DataBase.GetSpecifiedPath(relocateCommand.NewPath).LastOrDefault(),
                    Object = relocateCommand.DataBase.GetSpecifiedPath(relocateCommand.Path.Take(relocateCommand.Path.Count() - 1)).LastOrDefault()
                };
                DataRelocationInfo_Output?.Invoke(this, a);
            }
            else if (Command is GetCommand getCommand)
            {
                Command_Output?.Invoke(sender, getCommand);
            }
               
        }

    }
}
