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
        public TractorAccount CurrentAccount { get; private set; }
        public IDataBase CurrentDataBase { get; set; }
        public UIRouter UIRouter { get; } = new UIRouter();

        public TractorInstance()
        {
            LocalDataBase a = new LocalDataBase
            {
                Account = new TractorAccount(Guid.NewGuid()) { Name = "Me" }
            };
            CurrentDataBase = a;
        }

        public void ApplicationLaunched()
        {
            UIRouter.RequestNavigation(new NavigationInfo() { Name = UIViews.OVERALL_PAGE });
        }
    }
}
