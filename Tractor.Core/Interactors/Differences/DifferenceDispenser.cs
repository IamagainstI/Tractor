using EmptyBox.Automation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects.Difference;

namespace Tractor.Core.Interactors.Differences
{
    public class DifferenceDispenser : Pipeline<IDifference>, IPipelineInput<IDifference>
    {
        EventHandler<IDifference> IPipelineInput<IDifference>.Input => ApplyDifference;

        private void ApplyDifference(object sender, IDifference difference)
        {
            TypeInfo objectType = difference.ChangedObject.GetType().GetTypeInfo();
            PropertyInfo propInfo = objectType.GetDeclaredProperty(difference.PropertyName);
            //Проверяем что работаем с коллекцией
            if (typeof(IEnumerable).IsAssignableFrom(propInfo.PropertyType))
            {

            }
            else
            {
                propInfo.SetValue(difference.ChangedObject, difference.NewValue);
            }
        }
    }
}