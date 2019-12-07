using System;
using System.Collections.Generic;
using System.Text;
using EmptyBox.Automation;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Objects.Projects;

namespace Tractor.Core.Interactors
{
    public class DataRelocator : Pipeline<IDifference>, IPipelineInput<IDifference>, IPipelineOutput<object>, IPipelineOutput<string>
    {
  
        private event EventHandler<object> Object_Output;
        private event EventHandler<string> Action_Output;

        event EventHandler<object> IPipelineOutput<object>.Output
        {
            add => Object_Output += value;
            remove => Object_Output -= value;
        }

        event EventHandler<string> IPipelineOutput<string>.Output
        {
            add => Action_Output += value;
            remove => Action_Output -= value;
        }

        EventHandler<IDifference> IPipelineInput<IDifference>.Input => GetData;

        private void GetData(object sender, IDifference data)
        {
            if (((data.NewValue != null) || (data.OldValue != null)) && (data.ChangedObject != null))
            {
                if (data.OldValue != null)
                {
                    if (typeof(ITaskStorage).IsAssignableFrom(data.OldValue.GetType()))
                    {
                        ((ITaskStorage)data.OldValue).Tasks.Remove((ITask)data.ChangedObject);
                    }
                    else if (typeof(IProjectStorage).IsAssignableFrom(data.OldValue.GetType()))
                    {
                        ((IProjectStorage)data.OldValue).Projects.Remove((IProject)data.ChangedObject);
                    }
                }
                if (data.NewValue != null)
                {
                    if (typeof(ITaskStorage).IsAssignableFrom(data.NewValue.GetType()))
                    {
                        ((ITaskStorage)data.NewValue).Tasks.Add((ITask)data.ChangedObject);
                    }
                    else if (typeof(IProjectStorage).IsAssignableFrom(data.NewValue.GetType()))
                    {
                        ((IProjectStorage)data.NewValue).Projects.Add((IProject)data.ChangedObject);
                    }
                }
            }
        }

    }
}
