using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Presenters.Projects;
using Tractor.Core.Presenters.Tasks;
using Tractor.Core.Routers.Command;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters
{
    public static class ProjectMethods
    {
        public static void AddProject(UIRouter router, IProjectStorage storage) => EditProject(router, storage, null);

        public static void RemoveProject(UIRouter router, IProject project) => MoveProject(router, project, null);

        public static void MoveProject(UIRouter router, IProject task, IProjectStorage newStorage)
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

        public static void SaveProject(UIRouter router, IProjectStorage storage, IProject project)
        {
            SetCommand cmd = new SetCommand(Guid.NewGuid())
            {
                DataBase = router.CurrentDataBase,
                Entity = router.CurrentAccount,
                NewValue = project,
                Path = router.CurrentDataBase.GetPath(storage).Concat(Enumerable.Repeat(project.ID, 1))
            };
            router.SendCommand(cmd);
        }

        public static void EditProject(UIRouter router, IProjectStorage storage, IProject project)
        {
            NavigationHistory navigationHistory = new NavigationHistory()
            {
                Name = UIViews.PROJECT_EDIT_PAGE,
                PresenterType = typeof(ProjectEditPresenter),
                Paths = new IEnumerable<Guid>[]
                {
                    router.CurrentDataBase.GetPath(storage),
                    router.CurrentDataBase.GetPath(project)
                }
            };
            router.RequestNavigation(navigationHistory);
        }

        public static void ShowProject(UIRouter router, IProject project)
        {
            NavigationHistory navigationHistory = new NavigationHistory()
            {
                Name = UIViews.PROJECT_VIEW_PAGE,
                PresenterType = typeof(ProjectViewPresenter),
                Paths = new IEnumerable<Guid>[]
                {
                    router.CurrentDataBase.GetPath(project)
                }
            };
            router.RequestNavigation(navigationHistory);
        }
    }
}
