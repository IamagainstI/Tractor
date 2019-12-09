using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.Command;

namespace Tractor.Core.Interactors.DataBases
{
    public class CommandAccessGate : Pipeline<ICommand, ICommand>, IPipelineIO<ICommand, ICommand>
    {
        private event EventHandler<ICommand> Command_Output;

        event EventHandler<ICommand> IPipelineOutput<ICommand>.Output
        {
            add => Command_Output += value;
            remove => Command_Output -= value;
        }

        EventHandler<ICommand> IPipelineInput<ICommand>.Input => HandleAccess;

        private void HandleAccess(object sender, ICommand command)
        {
            AccessType requiredAccess = GetRequiredAccess(command);
            AccessType grantedAccess = command.DataBase.GetAccessType(command.Entity, command.DataBase.GetSpecifiedPath(command.Path).LastOrDefault());
            if (requiredAccess == (requiredAccess | grantedAccess))
            {
                Command_Output?.Invoke(this, command);
            }
        }

        private AccessType GetRequiredAccess(ICommand command)
        {
            switch (command)
            {
                case GetCommand get:
                    switch (get.DataBase.GetSpecifiedPath(get.Path))
                    {
                        case ITask task:
                            if (task.Performer == get.Entity)
                            {
                                return AccessType.PerformerView;
                            }
                            else if (task.Producer == get.Entity)
                            {
                                return AccessType.OwnerView;
                            }
                            else goto default;
                        default:
                            return AccessType.View;
                    }
                case SetCommand set:
                    switch (set.DataBase.GetSpecifiedPath(set.Path))
                    {
                        case ITask task:
                            if (task.Performer == set.Entity)
                            {
                                return AccessType.PerformerEdit;
                            }
                            else if (task.Producer == set.Entity)
                            {
                                return AccessType.OwnerEdit;
                            }
                            else goto default;
                        default:
                            return AccessType.Edit;
                    }
                case RelocateCommand relocate:
                    switch (relocate.DataBase.GetSpecifiedPath(relocate.Path))
                    {
                        case ITask task:
                            if (task.Performer == relocate.Entity)
                            {
                                return AccessType.PerformerAdd | AccessType.PerformerRemove;
                            }
                            else if (task.Producer == relocate.Entity)
                            {
                                return AccessType.OwnerAdd | AccessType.OwnerRemove;
                            }
                            else goto default;
                        default:
                            return AccessType.Add | AccessType.Remove;
                    }
                default:
                    return AccessType.None;
            }
        }
    }
}
