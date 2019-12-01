using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.Descriptions;
using Tractor.Core.Routers.UI;
using Tractor.Core.Specialized;

namespace Tractor.Core.Interactors.Descriptions
{
    public class DescriptionEditor : Pipeline<IDescription>, IPipelineInput<IDescription>, IPipelineOutput<NavigationInfo>
    {

        private event EventHandler<NavigationInfo> NavigationInfo_Output;
        private IDescription StoredDescription;

        EventHandler<IDescription> IPipelineInput<IDescription>.Input => GetData;

        event EventHandler<NavigationInfo> IPipelineOutput<NavigationInfo>.Output
        {
            add => NavigationInfo_Output += value;
            remove => NavigationInfo_Output -= value;
        }

        public IDescription Description { get; set; }
        public Type Type { get => Type; set => TypeChange(value); }

        public void EdnEditing()
        {
            TypeInfo type = StoredDescription.GetType().GetTypeInfo();
            foreach(PropertyInfo prop in type.DeclaredProperties)
            {
                if(prop.CanWrite)
                {
                    prop.SetValue(StoredDescription, prop.GetValue(Description));
                }
            }
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "Back" });
        }

        private void TypeChange(Type type)
        {
            if (StoredDescription.GetType() != type)
            {
                if (typeof(IDescription).IsAssignableFrom(type))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(Guid) });
                    object project = constructorInfo?.Invoke(new object[] { StoredDescription.ID });
                    TypeInfo newTypeInfo = type.GetTypeInfo();
                    TypeInfo oldTypeInfo = StoredDescription.GetType().GetTypeInfo();
                    IEnumerable<PropertyInfo> intersect = newTypeInfo.DeclaredProperties.Intersect(oldTypeInfo.DeclaredProperties, PropertyComparator.Comparator);
                    foreach (PropertyInfo prop in intersect)
                    {
                        if (prop.CanWrite)
                        {
                            PropertyInfo readProp = oldTypeInfo.GetDeclaredProperty(prop.Name);
                            prop.SetValue(project, readProp.GetValue(Description));
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Some exception");
                }
            }
        }

        private void GetData(object sender, IDescription data)
        {
            StoredDescription = data;
            Description = (IDescription)data.Clone();
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "DescriptionEditor" });
        }
    }
}
