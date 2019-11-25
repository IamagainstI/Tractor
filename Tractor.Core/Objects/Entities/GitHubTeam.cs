using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Objects.Entities
{
    public class GitHubTeam : ITeam
    {
        public IDictionary<IEntity, IEntityRole> Members => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public Guid ID => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void AddMember(IEntity item, IEntityRole itemRole)
        {
            throw new NotImplementedException();
        }

        public void AddMember(IDictionary<IEntity, IEntityRole> membres)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IEntity other)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(IEntity item)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(IDictionary<IEntity, IEntityRole> membres)
        {
            throw new NotImplementedException();
        }
    }
}
