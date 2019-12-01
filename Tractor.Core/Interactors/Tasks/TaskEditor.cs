using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using EmptyBox.Automation;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.UI;
using Tractor.Core.Specialized;

namespace Tractor.Core.Interactors.Tasks
{
    public class TaskEditor : Pipeline<ITask>, IPipelineInput<ITask>, IPipelineOutput<NavigationInfo>
    {
        private ITask StoredTask;
        private event EventHandler<NavigationInfo> NavigationInfo_Output;

        event EventHandler<NavigationInfo> IPipelineOutput<NavigationInfo>.Output
        {
            add => NavigationInfo_Output += value;
            remove => NavigationInfo_Output -= value;
        }

        EventHandler<ITask> IPipelineInput<ITask>.Input => GetData;

        public ITask Task { get; set; }
        public Type TaskType { get => TaskType; set => TypeChanged(value); }

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
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "Back" });
        }

        private void TypeChanged(Type type)
        {
            if (StoredTask.GetType() != type)
            {
                if (typeof(ITask).IsAssignableFrom(type))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new []{ typeof(Guid) });
                    object task = constructorInfo?.Invoke(new object[] { StoredTask.ID });
                    TypeInfo newTypeInfo = type.GetTypeInfo();
                    TypeInfo oldTypeInfo = StoredTask.GetType().GetTypeInfo();
                    IEnumerable<PropertyInfo> intersect = newTypeInfo.DeclaredProperties.Intersect(oldTypeInfo.DeclaredProperties, PropertyComparator.Comparator);
                    foreach(PropertyInfo prop in intersect)
                    {
                        if (prop.CanWrite)
                        {
                            PropertyInfo readProp = oldTypeInfo.GetDeclaredProperty(prop.Name);
                            prop.SetValue(task, readProp.GetValue(Task));
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Some exception");
                }
            }
        }

        private void GetData(object sender, ITask data)
        {
            StoredTask = data;
            Task = (ITask)StoredTask.Clone();
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "TaskEditor" });
        }
    }
}
