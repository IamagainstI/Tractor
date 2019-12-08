using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.Command;
using Tractor.Core.Routers.UI;
using Tractor.Core.Objects.DataBases;

namespace Tractor.Core.Presenters.Tasks
{
    public class TaskViewPresenter : AbstractPresentor
    {
        public ITask Task { get; }
        public ITaskStorage Storage { get; }

        public TaskViewPresenter(UIRouter router, ITask task, ITaskStorage taskStorage) : base(router)
        {
            Task = task;
            Storage = taskStorage;
        }

        public void AddSubtaskTask()
        {
            NavigationHistory info = new NavigationHistory()
            {
                Name = UIViews.TASK_EDITOR,
                PresenterType = typeof(TaskEditPresenter),
                Paths = new[]
                {
                    new List<Guid>(Router.CurrentDataBase.GetPath(Storage)),
                    new List<Guid>() { Guid.NewGuid() }
                }
            };
            Router.RequestNavigation(info);
        }
        public void RemoveSubtask(ITask task)
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

    }
}
