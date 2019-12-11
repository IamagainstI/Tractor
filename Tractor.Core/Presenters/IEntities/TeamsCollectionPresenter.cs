using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Routers.UI;
using Tractor.Core.Objects.DataBases;

namespace Tractor.Core.Presenters.IEntities
{
    public class TeamsCollectionPresenter : AbstractPresenter
    {
        public IEnumerable<ITeam> Teams { get; }
        UIRouter UIRouter { get; }

        public TeamsCollectionPresenter(UIRouter router, IEnumerable<ITeam> teams) : base(router)
        {
            Teams = teams;
        }

        public void AddTeam()
        {
            NavigationHistory info = new NavigationHistory()
            {
                Name = UIViews.TEAMS_MANAGEMENT_PAGE,
                PresenterType = typeof(TeamManagmentPresentor),
                Paths = new[]
                {
                    new List<Guid>(Router.CurrentDataBase.GetPath(UIRouter.CurrentDataBase)),
                    new List<Guid>() { Guid.NewGuid() }
                }
            };
            Router.RequestNavigation(info);
        }

        public void RemoveTeam(ITeam team)
        {

        }

    }
}
