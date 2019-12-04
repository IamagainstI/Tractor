using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Routers.UI;

namespace Tractor.Core
{
    public sealed class TractorInstance
    {
        public LocalDataBase DataBase { get; } = new LocalDataBase();
        public UIRouter UIRouter { get; } = new UIRouter();

        public TractorInstance()
        {
            DataBase.Account = new TractorAccount(Guid.NewGuid()) { Name = "Me" };
        }

        public void ApplicationLaunched()
        {
            UIRouter.RequestNavigation(new NavigationInfo() { Name = UIViews.OVERALL_PAGE });
        }
    }
}
