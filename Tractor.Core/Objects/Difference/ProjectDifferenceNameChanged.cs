using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Projects;

namespace Tractor.Core.Objects.Difference
{
    public class ProjectDifferenceNameChanged : IProjectDifferenceNameChanged
    {
        public string NewName { get; }
        public IProject Project { get; }
        public DateTime CreationDate { get; }

        public ProjectDifferenceNameChanged(IProject project, string @new, DateTime creationDate)
        {
            NewName = @new;
            Project = project;
            CreationDate = creationDate;
        }

        public byte[] GetDifferenceHash()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IDifference other)
        {
            return CreationDate.CompareTo(other.CreationDate);
        }
    }
}
