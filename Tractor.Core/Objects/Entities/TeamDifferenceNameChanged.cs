using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Difference;

namespace Tractor.Core.Objects.Entities
{
    class TeamDifferenceNameChanged : IDifference
    {
        public string NewName { get; }

        public ITeam Team { get; }

        public DateTime CreationDate { get; }

        public TeamDifferenceNameChanged(string @new, ITeam team, DateTime creationDate)
        {
            NewName = @new;
            Team = team;
            CreationDate = creationDate;
        }

        public int CompareTo(IDifference other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IDifference other)
        {
            throw new NotImplementedException();
        }

        public byte[] GetDifferenceHash()
        {
            throw new NotImplementedException();
        }
    }
}
