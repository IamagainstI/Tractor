using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Interactors;
using Tractor.Core.Interactors.DataBases;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Routers.UI;

namespace Tractor.Core
{
    public sealed class TractorInstance
    {
        public TractorAccount CurrentAccount { get; private set; }
        public IDataBase CurrentDataBase { get; set; }
        public UIRouter UIRouter { get; } = new UIRouter();
        public DataGetter DataGetter { get; } = new DataGetter();
        public DataBaseDifferenceHandler DataBaseDifferenceHandler { get; }
        public CommandProcessor CommandProcessor { get; } = new CommandProcessor();
        public DataEditor DataEditor { get; } = new DataEditor();
        public DataRelocator DataRelocator { get; } = new DataRelocator();

        public TractorInstance()
        {
            LocalDataBase a = new LocalDataBase
            {
                Account = new TractorAccount(Guid.NewGuid()) { Name = "Me" }
            };
            CurrentDataBase = a;
            UIRouter.CurrentAccount = CurrentAccount;
            UIRouter.CurrentDataBase = CurrentDataBase;
            DataBaseDifferenceHandler = new DataBaseDifferenceHandler(CurrentDataBase);
            //////////////////////
            a.Projects.Add(new UsualProject(Guid.NewGuid()) { Name = "Хуй", Parent = CurrentDataBase });
            //////////////////////
            _ = UIRouter >> CommandProcessor;
            _ = DataEditor >> DataRelocator;
            _ = CommandProcessor >> DataEditor >> DataBaseDifferenceHandler;
            _ = CommandProcessor >> DataRelocator >> DataBaseDifferenceHandler;
            _ = CommandProcessor >> DataGetter;
        }

        public void ApplicationLaunched()
        {
            UIRouter.RequestNavigation(new NavigationHistory() { Name = UIViews.OVERALL_PAGE });
        }
    }
}
