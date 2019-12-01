using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Interactors.Projects
{
    public class ProjectEditor : Pipeline<IProject>, IPipelineInput<IProject>, IPipelineOutput<NavigationInfo>
    {
        private IProject StoredProject;
        private event EventHandler<NavigationInfo> NavigationInfo_Output;

        event EventHandler<NavigationInfo> IPipelineOutput<NavigationInfo>.Output
        {
            add => NavigationInfo_Output += value;
            remove => NavigationInfo_Output -= value;
        }
        EventHandler<IProject> IPipelineInput<IProject>.Input => GetData;

        public IProject Project { get; set; }

        public void EndEditing()
        {
            TypeInfo typeProject = StoredProject.GetType().GetTypeInfo();
            foreach(PropertyInfo prop in typeProject.DeclaredProperties)
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
            Project = (IProject)data.Clone();
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "ProjectEditor" });
        }
       
    }
}
