using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.Command;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters.Tasks
{
    public class TaskEditPresenter : AbstractPresentor
    {
        public ITaskStorage Storage { get; }
        public ITask Task { get; private set; }

        public TaskEditPresenter(UIRouter router, ITaskStorage storage, ITask task) : base(router)
        {
            Storage = storage;
            Task = task;
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
        public void Save()
        {
            SetCommand cmd = new SetCommand(Guid.NewGuid())
            {
                DataBase = Router.CurrentDataBase,
                Entity = Router.CurrentAccount,
                NewValue = Task,
                Path = new List<Guid>(Router.CurrentDataBase.GetPath(Storage).Concat(Enumerable.Repeat(Task.ID, 1)))
            };
            Router.SendCommand(cmd);
            Router.RequestBack();
        }

        public void Cancel()
        {
            Router.RequestBack();
        }
    }
}
