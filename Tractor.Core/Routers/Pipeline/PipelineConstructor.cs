using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Interactors.Tasks;
using Tractor.Core.Routers.UI;
using EmptyBox.Automation;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Routers.Pipeline
{
    public class PipelineConstructor
    {
        public TaskEditor TaskEditor = new TaskEditor();
        public UIRouter Navigator = new UIRouter();
        public ExternalInput<ITask> ExternalTaskInput = new ExternalInput<ITask>();

        public PipelineConstructor()
        {
            _ = ExternalTaskInput >> TaskEditor;
            _ = TaskEditor >> Navigator;
        }
    }
}
