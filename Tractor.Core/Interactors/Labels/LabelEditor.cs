using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects.Descriptions.Labels;
using Tractor.Core.Routers.UI;
using Tractor.Core.Specialized;

namespace Tractor.Core.Interactors.Labels
{
    public class LabelEditor : Pipeline<ILabel>, IPipelineInput<ILabel>, IPipelineOutput<NavigationInfo>
    {
        public EventHandler<ILabel> Input => throw new NotImplementedException();
        public event EventHandler<NavigationInfo> Output;

        private ILabel StoredLabel;
        private event EventHandler<NavigationInfo> NavigationInfo_Output;

        event EventHandler<NavigationInfo> IPipelineOutput<NavigationInfo>.Output
        {
            add => NavigationInfo_Output += value;
            remove => NavigationInfo_Output -= value;
        }

        EventHandler<ILabel> IPipelineInput<ILabel>.Input => GetData;

        public ILabel Label { get; set; }
        public Type LabelType { get => LabelType; set => TypeChanged(value); }

        public void EndEditing()
        {
            TypeInfo labelType = StoredLabel.GetType().GetTypeInfo();
            foreach (PropertyInfo prop in labelType.DeclaredProperties)
            {
                if (prop.CanWrite)
                {
                    prop.SetValue(StoredLabel, prop.GetValue(Label));
                }
            }
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "Back" });
        }

        private void TypeChanged(Type type)
        {
            if (StoredLabel.GetType() != type)
            {
                if (typeof(ILabel).IsAssignableFrom(type))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(Guid) });
                    object label = constructorInfo?.Invoke(new object[] { StoredLabel.ID });
                    TypeInfo newTypeInfo = type.GetTypeInfo();
                    TypeInfo oldTypeInfo = StoredLabel.GetType().GetTypeInfo();
                    IEnumerable<PropertyInfo> intersect = newTypeInfo.DeclaredProperties.Intersect(oldTypeInfo.DeclaredProperties, PropertyComparator.Comparator);
                    foreach (PropertyInfo prop in intersect)
                    {
                        if (prop.CanWrite)
                        {
                            PropertyInfo readProp = oldTypeInfo.GetDeclaredProperty(prop.Name);
                            prop.SetValue(label, readProp.GetValue(Label));
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Some exception");
                }
            }
        }

        private void GetData(object sender, ILabel data)
        {
            StoredLabel = data;
            Label = (ILabel)StoredLabel.Clone();
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "LabelEditor" });
        }
    }

}
