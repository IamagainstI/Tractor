using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Presenters.Tasks;
using Tractor.Core.Routers.Command;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters
{
    public static class TaskMethods
    {
        public static void AddTask(UIRouter router, ITaskStorage storage) => EditTask(router, storage, null);

        public static void RemoveTask(UIRouter router, ITask task) => MoveTask(router, task, null);

        public static void MoveTask(UIRouter router, ITask task, ITaskStorage newStorage)
        {
            RelocateCommand cmd = new RelocateCommand(Guid.NewGuid())
            {
                DataBase = router.CurrentDataBase,
                Entity = router.CurrentAccount,
                NewPath = router.CurrentDataBase.GetPath(newStorage),
                Path = router.CurrentDataBase.GetPath(task.Parent)
            };
            router.SendCommand(cmd);
        }

        public static void SaveTask(UIRouter router, ITaskStorage storage, ITask task)
        {
            SetCommand cmd = new SetCommand(Guid.NewGuid())
            {
                DataBase = router.CurrentDataBase,
                Entity = router.CurrentAccount,
                NewValue = task,
                Path = router.CurrentDataBase.GetPath(storage).Concat(Enumerable.Repeat(task.ID, 1))
            };
            router.SendCommand(cmd);
        }

        public static void EditTask(UIRouter router, ITaskStorage storage, ITask task)
        {
            NavigationHistory navigationHistory = new NavigationHistory()
            {
                Name = UIViews.TASK_EDITOR,
                PresenterType = typeof(TaskEditPresenter),
                Paths = new IEnumerable<Guid>[]
                {
                    router.CurrentDataBase.GetPath(storage),
                    router.CurrentDataBase.GetPath(task)
                }
            };
            router.RequestNavigation(navigationHistory);
        }

        public static void ShowTask(UIRouter router, ITask task)
        {
            NavigationHistory navigationHistory = new NavigationHistory()
            {
                Name = UIViews.TASK_VIEW_DIALOG,
                PresenterType = typeof(TaskViewPresenter),
                Paths = new IEnumerable<Guid>[]
                {
                    router.CurrentDataBase.GetPath(task)
                }
            };
            router.RequestNavigation(navigationHistory);
        }
    }
}
