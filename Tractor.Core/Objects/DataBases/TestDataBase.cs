using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Projects;

namespace Tractor.Core.Objects.DataBases
{
    public static class TestDataBase
    {
        public static List<IProject> Projects { get; set; }
        public static List<IDifference> Differences { get; set; }
        public static void AddProject(IProject project)
        {
            if (Projects != null)
            {
                Projects.Add(project);
            }
            else
            {
                Projects = new List<IProject>();
                Projects.Add(project);
            }
        }
    }
}
