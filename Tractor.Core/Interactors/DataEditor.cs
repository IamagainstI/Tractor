using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using EmptyBox.Automation;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.UI;
using Tractor.Core.Specialized;

namespace Tractor.Core.Interactors
{
    public class DataEditor : Pipeline<IDifference, IDifference>, IPipelineIO<IDifference, IDifference>, IPipelineOutput<object>
    {
        private event EventHandler<IDifference> IDifference_Output;
        private event EventHandler<object> Object_Output;

        event EventHandler<IDifference> IPipelineOutput<IDifference>.Output
        {
            add => IDifference_Output += value;
            remove => IDifference_Output -= value;
        }
        event EventHandler<object> IPipelineOutput<object>.Output
        {
            add => Object_Output += value;
            remove => Object_Output -= value;
        }

        EventHandler<IDifference> IPipelineInput<IDifference>.Input => GetData;

        // В презентер
        //private void TypeChanged(Type type)
        //{
        //    if (StoredTask.GetType() != type)
        //    {
        //        if (typeof(ITask).IsAssignableFrom(type))
        //        {
        //            ConstructorInfo constructorInfo = type.GetConstructor(new []{ typeof(Guid) });
        //            object task = constructorInfo?.Invoke(new object[] { StoredTask.ID });
        //            TypeInfo newTypeInfo = type.GetTypeInfo();
        //            TypeInfo oldTypeInfo = StoredTask.GetType().GetTypeInfo();
        //            IEnumerable<PropertyInfo> intersect = newTypeInfo.DeclaredProperties.Intersect(oldTypeInfo.DeclaredProperties, PropertyComparator.Comparator);
        //            foreach(PropertyInfo prop in intersect)
        //            {
        //                if (prop.CanWrite)
        //                {
        //                    PropertyInfo readProp = oldTypeInfo.GetDeclaredProperty(prop.Name);
        //                    prop.SetValue(task, readProp.GetValue(Task));
        //                }
        //            }
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Some exception");
        //        }
        //    }
        //}

        private void GetData(object sender, IDifference data)
        {
            TypeInfo oldDataType = data.OldValue.GetType().GetTypeInfo();
            if (oldDataType == data.NewValue?.GetType().GetTypeInfo())
            {
                foreach (PropertyInfo prop in oldDataType.DeclaredProperties)
                {
                    if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                    {
                        //List<int> A = new List<int>();
                        //List<int> B = new List<int>();

                        //IEnumerable<int> intersect = A.Intersect(B);
                        //List<(int val, int ind)> c0 = A.Select((x, y) => (x, intersect.Contains(y) ? y : -1)).ToList();
                        //List<(int val, int ind)> c1 = B.Select((x, y) => (x, intersect.Contains(y) ? y : -1)).ToList();
                        //IEnumerable<int> c2 = A.Except()
                    }
                    else
                    {
                        if (prop.CanRead && prop.CanWrite)
                        {
                            object oldValue = prop.GetValue(data.OldValue);
                            object newValue = prop.GetValue(data.NewValue);
                            if (oldValue != newValue)
                            {
                                Difference diff = new Difference(Guid.NewGuid())
                                {
                                    ChangedObject = data.OldValue,
                                    CreationDate = data.CreationDate,
                                    Entity = data.Entity,
                                    NewValue = newValue,
                                    OldValue = oldValue,
                                    PropertyName = prop.Name,
                                    Type = NotifyCollectionChangedAction.Replace
                                };
                                IDifference_Output?.Invoke(this, diff);
                            }
                        }
                    }
                }
            }
            else if (data.OldValue is ITask || data.NewValue is ITask || data.NewValue is IProject || data.OldValue is IProject)
            {
                if (data.OldValue != null)
                {
                    //отправляем старые данные в релокатор на удаление
                    Object_Output?.Invoke(this, null);
                }
                if (data.NewValue != null)
                {
                    //Отправляем новые данные в релокатор на добавление
                    Object_Output?.Invoke(this, null);
                }
            }
            else
            {
                IDifference_Output?.Invoke(this, data);
            }
        }
    }
}
