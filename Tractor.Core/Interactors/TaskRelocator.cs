using System;
using System.Collections.Generic;
using System.Text;
using EmptyBox.Automation;
using Tractor.Core.Objects.Difference;

namespace Tractor.Core.Interactors
{
    public class TaskRelocator : Pipeline<IDifference>, IPipelineInput<IDifference>, IPipelineOutput<object>, IPipelineOutput<string>
    {
        public EventHandler<IDifference> Input => throw new NotImplementedException();

        public event EventHandler<object> Output;

        event EventHandler<string> IPipelineOutput<string>.Output
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
    }
}
