using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Collections;
using Tractor.Core.Objects.Projects;

namespace Tractor.Core.Presenters.Projects
{
    public class ProjectsPagePresenter
    {
        public ObservableCollection<IProject> Projects { get; }

        public ProjectsPagePresenter(ObservableCollection<IProject> projects)
        {
            Projects = projects;
        }
    }
}
