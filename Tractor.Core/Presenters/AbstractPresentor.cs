using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters
{
    public abstract class AbstractPresentor
    {
        public UIRouter Router { get; }

        public AbstractPresentor(UIRouter router)
        {
            Router = router;
        }
    }
}
