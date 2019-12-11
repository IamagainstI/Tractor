using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Routers.UI
{
    public class NavigationHistory
    {
        public string Name { get; set; }
        public Type PresenterType { get; set; }
        public IEnumerable<Guid>[] Paths { get; set; }
    }
}
