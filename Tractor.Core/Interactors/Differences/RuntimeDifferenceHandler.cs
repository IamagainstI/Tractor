using EmptyBox.Automation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Interactors.Differences
{
    public class RuntimeDifferenceHandler : Pipeline<IDifference>, IPipelineOutput<IDifference>,
        IPipelineInput<IProject>,
        IPipelineInput<ITask>
    {
        Dictionary<object, Difference> Differences = new Dictionary<object, Difference>();

        EventHandler<IProject> IPipelineInput<IProject>.Input => (x, y) => AddSubscription(y);
        EventHandler<ITask> IPipelineInput<ITask>.Input => (x,y) => AddSubscription(y);

        public event EventHandler<IDifference> Output;

        public void AddSubscription(IProject obj)
        {
            obj.PropertyChanging += Obj_PropertyChanging;
            obj.PropertyChanged += Obj_PropertyChanged;
            obj.CollectionChanged += Obj_CollectionChanged;
        }

        private void Obj_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            PropertyInfo propInfo = sender.GetType().GetTypeInfo().GetProperty(Differences[sender].PropertyName);
            Differences[sender].Type = e.Action;
            Differences[sender].NewValue = (e.NewStartingIndex, e.NewItems);
            Differences[sender].OldValue = (e.OldStartingIndex, e.OldItems);
            Output?.Invoke(this, Differences[sender]);
            Differences.Remove(sender);
        }

        private void Obj_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyInfo propInfo = sender.GetType().GetTypeInfo().GetProperty(e.PropertyName);
            Differences[sender].NewValue = propInfo.GetValue(sender);
            Output?.Invoke(this, Differences[sender]);
            Differences.Remove(sender);
        }

        private void Obj_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            PropertyInfo propInfo = sender.GetType().GetTypeInfo().GetProperty(e.PropertyName);
            Difference diff = new Difference(Guid.NewGuid());
            diff.ChangedObject = sender;
            diff.PropertyName = e.PropertyName;
            diff.CreationDate = DateTime.Now;
            if (!typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(propInfo.PropertyType))
            {
                diff.OldValue = propInfo.GetValue(sender);
                diff.Type = NotifyCollectionChangedAction.Replace;
            }
            Differences[sender] = diff;
        }

        public void AddSubscription(ITask obj)
        {
            obj.PropertyChanging += Obj_PropertyChanging;
            obj.PropertyChanged += Obj_PropertyChanged;
        }
    }
}
