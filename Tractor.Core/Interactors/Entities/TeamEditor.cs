using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Interactors.Entities
{
    public class TeamEditor : Pipeline<ITeam>, IPipelineInput<ITeam>, IPipelineOutput<NavigationInfo>
    {
        private ITeam StoredTeam;
        private event EventHandler<NavigationInfo> NavigationInfo_Output;

        public EventHandler<ITeam> Input => GetData;
        event EventHandler<NavigationInfo> IPipelineOutput<NavigationInfo>.Output
        {
            add => NavigationInfo_Output += value;
            remove => NavigationInfo_Output -= value;
        }

        public ITeam Team { get; set; }

        public void EndEditing()
        {
            TypeInfo teamType = StoredTeam.GetType().GetTypeInfo();
            foreach(PropertyInfo prop in teamType.DeclaredProperties)
            {
                if (prop.CanWrite)
                {
                    prop.SetValue(StoredTeam, prop.GetValue(Team));
                }
            }
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "Back" });
        }

        private void GetData(object sender, ITeam data)
        {
            StoredTeam = data;
            Team = (ITeam)StoredTeam.Clone();
            NavigationInfo_Output?.Invoke(this, new NavigationInfo() { Name = "TeamEditor" });
        }

    }
}
