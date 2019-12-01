using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Routers.UI;

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

        private void GetData(object sender, IDescription data)
        {
            StoredDescription = data;
            Description = (IDescription)data.Clone();
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "DescriptionEditor" });
        }

    }
}
