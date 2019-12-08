using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters.IEntities
{
    public class TeamManagmentPresentor : AbstractPresentor
    {
        ITeam Team { get; }

        UIRouter UIRouter { get; }

        public TeamManagmentPresentor(UIRouter router, ITeam team) : base(router)
        {
            Team = team;
        }

        public void AddEntity()
        {
            NavigationInfo info = new NavigationInfo()
            {

            };
        }

        public void RemoveEntity(IEntity entity)
        {

        }

    }
}
