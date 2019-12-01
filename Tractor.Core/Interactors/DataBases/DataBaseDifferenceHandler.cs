using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Interactors.Differences;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Difference;

namespace Tractor.Core.Interactors.DataBases
{
    public class DataBaseDifferenceHandler : Pipeline<IDifference, IDifference>, IPipelineIO<IDifference, IDifference>
    {
        private event EventHandler<IDifference> IDifference_Output;

        event EventHandler<IDifference> IPipelineOutput<IDifference>.Output
        {
            add => IDifference_Output += value;
            remove => IDifference_Output -= value;
        }

        EventHandler<IDifference> IPipelineInput<IDifference>.Input => HandleDifference;

        public IDataBase DataBase { get; }

        public DataBaseDifferenceHandler(IDataBase db)
        {
            DataBase = db;
        }

        private void HandleDifference(object sender, IDifference difference)
        {
            if (sender is RuntimeDifferenceHandler)
            {
                DataBase.History.Add(difference);
            }
            else if (sender is SynchronizationDifferenceHandler)
            {
                DataBase.History.Add(difference);
                IDifference_Output?.Invoke(this, difference);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
