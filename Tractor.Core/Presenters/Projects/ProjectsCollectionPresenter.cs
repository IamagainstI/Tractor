using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Collections;
using Tractor.Core.Objects.Projects;

namespace Tractor.Core.Presenters.Projects
{
    public class ProjectsCollectionPresenter
    {
        public IProjectStorage Projects { get; }

        public ProjectsCollectionPresenter(IProjectStorage projects)
        {
            Projects = projects;
        }
    }
}
