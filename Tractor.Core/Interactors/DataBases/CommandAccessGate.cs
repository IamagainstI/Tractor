using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Entities.Permissions;
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
            foreach (IPermission perm in command.DataBase.Permissions)
            {
                switch (perm)
                {
                    case IEntityPermission entityPerm:
                        if (entityPerm.Entity == command.Entity)
                        {
                            AccessType gainedAccess = requiredAccess | entityPerm.AccessType;
                            switch (gainedAccess)
                            {
                                case AccessType.None:

                                    break;
                            }
                        }
                        break;
                }
            }
        }

        private void GetGrantedAccess()
        {

        }

        private AccessType GetRequiredAccess(ICommand command)
        {
            switch (command)
            {
                case GetCommand get:
                    return AccessType.View;
                case SetCommand set:
                    return AccessType.Edit;
                case RelocateCommand relocate:
                    return AccessType.Add | AccessType.Remove;
                default:
                    return AccessType.None;
            }
        }
    }
}
