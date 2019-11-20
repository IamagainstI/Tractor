using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Objects.Credentials;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Objects.Projects;

namespace Tractor.Core.Objects.Repositories
{
    class GitHubProject : IProject
    {
        public string Name => throw new NotImplementedException();

        public IProgress Progress => throw new NotImplementedException();

        public IEnumerable<IProject> Subprojects => throw new NotImplementedException();

        public IDescription Description => throw new NotImplementedException();

        public IEnumerable<ITask> Tasks => throw new NotImplementedException();

        public IReadOnlyDictionary<IEntity, IEntityRole> Participants => throw new NotImplementedException();

        public IEnumerable<IPermission> Permissions => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();

        public event ProjectChangeEventHandler ProjectChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public void AddParticipant(IEntity entity, IEntityRole entityRole)
        {
            throw new NotImplementedException();
        }

        public void AddPermission(IPermission permission)
        {
            throw new NotImplementedException();
        }

        public void AddTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public void EditParticipantRole(IEntity entity, IEntityRole entityRole)
        {
            throw new NotImplementedException();
        }

        public void RemoveParticipant(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemovePermission(IPermission permission)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(ITask task)
        {
            throw new NotImplementedException();
        }

        string URL { get; set; }

        UserPasswordCredentials Credentials { get; set; }

    }
}
