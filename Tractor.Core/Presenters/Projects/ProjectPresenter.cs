using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.Command;
using Tractor.Core.Routers.UI;
using Tractor.Core.Objects.DataBases;

namespace Tractor.Core.Presenters.Projects
{
    public class ProjectPresenter : AbstractPresentor
    {
        public IProject Project { get; private set; }
        public IProjectStorage Storage { get; private set; }

        public ProjectPresenter(UIRouter router, IProject project) : base(router)
        {
            Project = project;
        }

        public void Save()
        {
            SetCommand cmd = new SetCommand(Guid.NewGuid())
            {
                DataBase = Router.CurrentDataBase,
                Entity = Router.CurrentAccount,
                NewValue = Project,
                Path = new List<Guid>(Router.CurrentDataBase.GetPath(Storage))
            };
            Router.SendCommand(cmd);
            Router.RequestBack();
        }

        public void RemoveTask(ITask task)
        {
            RelocateCommand cmd = new RelocateCommand(Guid.NewGuid())
            {
                DataBase = Router.CurrentDataBase,
                Entity = Router.CurrentAccount,
                NewPath = null,
                Path = new List<Guid>(Router.CurrentDataBase.GetPath(Storage))
            };
            Router.SendCommand(cmd);
        }

        public void Cancel()
        {
            Router.RequestBack();
        }

    }
}
