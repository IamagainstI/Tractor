using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters.IEntities
{
    public class EntityManagmentPresenter : AbstractPresenter
    {
        public IEntity Entity { get; }

        public EntityManagmentPresenter(UIRouter router, IEntity entity) : base(router)
        {
            Entity = entity;
        }

    }
}
