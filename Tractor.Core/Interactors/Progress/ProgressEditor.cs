using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.Progress;
using Tractor.Core.Routers.UI;
using Tractor.Core.Specialized;

namespace Tractor.Core.Interactors.Progress
{
    public class ProgressEditor : Pipeline<IProgress>, IPipelineInput<IProgress>, IPipelineOutput<NavigationInfo>
    {


        private IProgress StoredProgress;
        private event EventHandler<NavigationInfo> NavigationInfo_Output;

        event EventHandler<NavigationInfo> IPipelineOutput<NavigationInfo>.Output
        {
            add => NavigationInfo_Output += value;
            remove => NavigationInfo_Output -= value;
        }

        EventHandler<IProgress> IPipelineInput<IProgress>.Input => GetData;

        public IProgress Progress { get; set; }
        public Type ProgressType { get => ProgressType; set => TypeChanged(value); }

        public void EndEditing()
        {
            TypeInfo progressType = StoredProgress.GetType().GetTypeInfo();
            foreach(PropertyInfo prop in progressType.DeclaredProperties)
            {
                if (prop.CanWrite)
                {
                    prop.SetValue(StoredProgress, prop.GetValue(Progress));
                }
            }
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "Back" });
        }

        private void TypeChanged(Type type)
        {
            if (StoredProgress.GetType() != type)
            {
                if (typeof(IProgress).IsAssignableFrom(type))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new []{ typeof(Guid) });
                    object task = constructorInfo?.Invoke(new object[] { StoredProgress.ID });
                    TypeInfo newTypeInfo = type.GetTypeInfo();
                    TypeInfo oldTypeInfo = StoredProgress.GetType().GetTypeInfo();
                    IEnumerable<PropertyInfo> intersect = newTypeInfo.DeclaredProperties.Intersect(oldTypeInfo.DeclaredProperties, PropertyComparator.Comparator);
                    foreach(PropertyInfo prop in intersect)
                    {
                        if (prop.CanWrite)
                        {
                            PropertyInfo readProp = oldTypeInfo.GetDeclaredProperty(prop.Name);
                            prop.SetValue(task, readProp.GetValue(Progress));
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Some exception");
                }
            }
        }

        private void GetData(object sender, IProgress data)
        {
            StoredProgress = data;
            Progress = (IProgress)StoredProgress.Clone();
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "ProgressEditor" });
        }

    }
}
