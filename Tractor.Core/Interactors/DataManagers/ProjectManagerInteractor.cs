using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Projects;

namespace Tractor.Core.Interactors.DataManagers
{
    public class ProjectManagerInteractor
    {
        public void RemoveSubProject(Guid projectID)
        {

        }
        public void AddSubProject(IProject project, Guid projectID)
        {

        }
        public void SetDescription(IDescription description, Guid projectID)
        {

        }
        public void SetName(string name, Guid projectID)
        {

        }
        public void AddParticipants(IReadOnlyDictionary<IEntity, IEntityRole> participants, Guid projectID)
        {

        }
        public void RemoveParticipants(IEnumerable<Guid> IDs, Guid projectID)
        {

        }
        public void MoveSubProject(Guid projectID, Guid newProjectID, Guid oldProjectID)
        {

        }
    }
}
