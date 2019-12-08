using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Collections;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Routers.UI;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Routers.Command;

namespace Tractor.Core.Presenters.Projects
{
    public class ProjectsCollectionPresenter : AbstractPresentor
    {
        public IProjectStorage Projects { get; }

        public ProjectsCollectionPresenter(UIRouter router, IProjectStorage projects) : base(router)
        {
            Projects = projects;
        }

        public void AddProject()
        {
            NavigationHistory info = new NavigationHistory()
            {
                Name = UIViews.TEAMS_MANAGEMENT_PAGE,
                PresenterType = typeof(ProjectManagementPagePresenter),
                Paths = new[]
                {
                    new List<Guid>(Router.CurrentDataBase.GetPath(Projects)),
                    new List<Guid>() { Guid.NewGuid() }
                }
            };
            Router.RequestNavigation(info);
        }

        public void RemoveProject(IProject project)
        {
            RelocateCommand cmd = new RelocateCommand(Guid.NewGuid())
            {
                DataBase = Router.CurrentDataBase,
                Entity = Router.CurrentAccount,
                NewPath = null,
                Path = new List<Guid>(Router.CurrentDataBase.GetPath(Projects))
            };
        }

        public void OpenProject()
        {

        }


    }
}
