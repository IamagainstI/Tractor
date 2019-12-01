using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Routers.UI;
using Tractor.Core.Specialized;

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
        public Type ProjectType { get; set; }

        EventHandler<IProject> IPipelineInput<IProject>.Input => GetData;

        private void TypeChanged(Type type)
        {
            if (StoredProject.GetType() != type)
            {
                if (typeof(IProject).IsAssignableFrom(type))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(Guid) });
                    object project = constructorInfo?.Invoke(new object[] { StoredProject.ID });
                    TypeInfo newTypeInfo = type.GetTypeInfo();
                    TypeInfo oldTypeInfo = StoredProject.GetType().GetTypeInfo();
                    IEnumerable<PropertyInfo> intersect = newTypeInfo.DeclaredProperties.Intersect(oldTypeInfo.DeclaredProperties, PropertyComparator.Comparator);
                    foreach (PropertyInfo prop in intersect)
                    {
                        if (prop.CanWrite)
                        {
                            PropertyInfo readProp = oldTypeInfo.GetDeclaredProperty(prop.Name);
                            prop.SetValue(project, readProp.GetValue(Project));
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Some exception");
                }
            }
        }

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
            ProjectType = data.GetType();
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "ProjectEditor" });
        }
    }
}
