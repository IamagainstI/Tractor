using System;
using System.Collections.Generic;
using System.Text;
using EmptyBox.Automation;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Objects.Projects;

namespace Tractor.Core.Interactors
{
    public class DataRelocator : Pipeline<DataRelocationInfo, IDifference>, IPipelineIO<DataRelocationInfo, IDifference>
    {
  
        private event EventHandler<IDifference> IDifference_Output;

        event EventHandler<IDifference> IPipelineOutput<IDifference>.Output
        {
            add => IDifference_Output += value;
            remove => IDifference_Output -= value;
        }

        EventHandler<DataRelocationInfo> IPipelineInput<DataRelocationInfo>.Input => GetData;

        private void GetData(object sender, DataRelocationInfo data)
        {
            if (data.Object != null)
            {
                if (data.OldStorage != null)
                {
                    if (data.OldStorage is ITaskStorage storage0)
                    {
                        storage0.Tasks.Remove(data.Object as ITask);
                    }
                    else if (data.OldStorage is IProjectStorage storage1)
                    {
                        storage1.Projects.Remove(data.Object as IProject);
                    }
                    Difference diff = new Difference(Guid.NewGuid())
                    {
                        ChangedObject = data.OldStorage,
                        CreationDate = DateTime.Now,
                        
                    };
                    IDifference_Output?.Invoke(this, diff);
                }
                if (data.NewStorage != null)
                {
                    if (data.OldStorage is ITaskStorage storage0)
                    {
                        storage0.Tasks.Add(data.Object as ITask);
                    }
                    else if (data.OldStorage is IProjectStorage storage1)
                    {
                        storage1.Projects.Add(data.Object as IProject);
                    }
                }
            }
        }

    }
}
