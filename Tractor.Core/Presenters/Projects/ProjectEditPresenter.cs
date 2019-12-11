using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Presenters.Tasks;
using Tractor.Core.Routers.Command;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters.Projects
{
    public class ProjectEditPresenter : AbstractPresenter
    {
        public IProject Project { get; set; }
        public IProjectStorage Storage { get; }

        public ProjectEditPresenter(UIRouter router, IProjectStorage storage, IProject project) : base(router)
        {
            Project = project;
            Storage = storage;
        }

        public void Save() => ProjectMethods.SaveProject(Router, Storage, Project);
        public void Cancel() => Router.RequestBack();
    }
}
