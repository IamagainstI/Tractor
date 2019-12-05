using System;
using System.Collections.Generic;
using System.Text;
using EmptyBox.Automation;
using Tractor.Core.Routers.Command;
using Tractor.Core.Objects.Difference;

namespace Tractor.Core.Interactors
{
    public class CommandProcessor : Pipeline<ICommand, ICommand>, IPipelineIO<ICommand, IDifference>
    {
        private event EventHandler<IDifference> IDifference_Output;
        //private event EventHandler<object> Object_Output;

        event EventHandler<IDifference> IPipelineOutput<IDifference>.Output
        {
            add => IDifference_Output += value;
            remove => IDifference_Output -= value;
        }
        //event EventHandler<object> IPipelineOutput<object>.Output
        //{
        //    add => Object_Output += value;
        //    remove => Object_Output -= value;
        //}

        EventHandler<ICommand> IPipelineInput<ICommand>.Input => CommandHandler;

        private void CommandHandler(object sender, ICommand Command)
        {
            Type CommandType = Command.GetType();
            if (Command is SetCommand)
            {
                IDifference difference = new Difference(new Guid())
                {
                   //NewValue = ()
                };
                IDifference_Output?.Invoke(sender, difference);
            }
            else if (Command is RelocateCommand)
            {
                IDifference difference = new Difference(new Guid())
                {

                };
                IDifference_Output?.Invoke(sender, difference);
            }
            else if (Command is GetCommand)
            {
                IDifference difference = new Difference(new Guid())
                {

                };
            }
               
        }

    }
}
