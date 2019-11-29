using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Routers.UI
{
    public class Navigator : Pipeline<NavigationInfo>, IPipelineInput<NavigationInfo>
    {
        public EventHandler<NavigationInfo> Input => OnInput;

        public event EventHandler<string> NavigationRequested;

        private void OnInput(object sender, NavigationInfo info)
        {
            NavigationRequested?.Invoke(this, info.Name);
        }
    }
}
