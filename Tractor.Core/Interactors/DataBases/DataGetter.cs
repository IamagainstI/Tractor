using EmptyBox.Automation;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Routers.Command;

namespace Tractor.Core.Interactors.DataBases
{
    public class DataGetter : Pipeline<GetCommand, object>, IPipelineIO<GetCommand, object>
    {
        EventHandler<GetCommand> IPipelineInput<GetCommand>.Input => InputCommand;

        public event EventHandler<object> OutputGetter;
        event EventHandler<object> IPipelineOutput<object>.Output
        {
            add => OutputGetter += value;
            remove => OutputGetter -= value;
        }

        private void InputCommand(object sender, GetCommand getCommand)
        {
            object obj = getCommand.DataBase.GetSpecifiedPath(getCommand.Path).Last();
            getCommand.Progress = ProgressState.Finished;
            OutputGetter?.Invoke(this, obj);
        }

    }
}
