using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters.IEntities
{
    public class UserSetupPage : AbstractPresenter
    {
        public UIRouter UIRouter { get; }
        IEntity Account { get; }
        public UserSetupPage(UIRouter router, IEntity account) : base(router)
        {
            Account = account;
        }



    }
}
