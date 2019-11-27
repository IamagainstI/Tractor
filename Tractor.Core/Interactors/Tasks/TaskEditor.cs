using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using EmptyBox.Automation;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Interactors.Tasks
{
    public class TaskEditor : Pipeline<ITask>, IPipelineInput<ITask>, IPipelineOutput<NavigationInfo>
    {
        private ITask StoredTask;

        public EventHandler<ITask> Input => GetData;

        public ITask Task { get; set; }

        public event EventHandler<NavigationInfo> Output;

        public void EndEditing()
        {
            TypeInfo taskType = StoredTask.GetType().GetTypeInfo();
            foreach(PropertyInfo prop in taskType.DeclaredProperties)
            {
                if (prop.CanWrite)
                {
                    prop.SetValue(StoredTask, prop.GetValue(Task));
                }
            }
            Output?.Invoke(this, new NavigationInfo() { Name = "Back" });
        }

        private void GetData(object sender, ITask data)
        {
            StoredTask = data;
            Task = (ITask)StoredTask.Clone();
            Output?.Invoke(this, new NavigationInfo() { Name = "TaskEditor" });
        }
    }
}
