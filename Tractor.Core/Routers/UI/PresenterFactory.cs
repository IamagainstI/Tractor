using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Presenters.Projects;

namespace Tractor.Core.Routers.UI
{
    public class PresenterFactory
    {
        public void FillNavigationInfo(NavigationInfo info)
        {
            switch (info.Name)
            {
                case UIViews.PROJECTS_PAGE:
                    info.Presenter = new ProjectsCollectionPresenter();
                    break;
            }
        }
    }
}
