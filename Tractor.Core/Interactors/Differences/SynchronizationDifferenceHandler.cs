using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects.Difference;

namespace Tractor.Core.Interactors.Differences
{
    public class SynchronizationDifferenceHandler : IPipelineOutput<IDifference>
    {
        private event EventHandler<IDifference> IDifference_Output;

        event EventHandler<IDifference> IPipelineOutput<IDifference>.Output
        {
            add => IDifference_Output += value;
            remove => IDifference_Output -= value;
        }
    }
}
