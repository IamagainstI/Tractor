using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Interactors.Projects
{
    public class TaskEditor : Pipeline<IProject>, IPipelineInput<IProject>, IPipelineOutput<NavigationInfo>
    {
        private IProject StoredProject;
        private event EventHandler<NavigationInfo> NavigationInfo_Output;

        event EventHandler<NavigationInfo> IPipelineOutput<NavigationInfo>.Output
        {
            add => NavigationInfo_Output += value;
            remove => NavigationInfo_Output -= value;
        }
        
        public IProject Project { get; set; }

        EventHandler<IProject> IPipelineInput<IProject>.Input => GetData;

        public void EndEditing()
        {
            TypeInfo taskType = StoredProject.GetType().GetTypeInfo();
            foreach (PropertyInfo prop in taskType.DeclaredProperties)
            {
                if (prop.CanWrite)
                {
                    prop.SetValue(StoredProject, prop.GetValue(Project));
                }
            }
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "Back" });
        }

        private void GetData(object sender, IProject data)
        {
            StoredProject = data;
            Project = (IProject)StoredProject.Clone();
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "ProjectEditor" });
        }
    }
}
