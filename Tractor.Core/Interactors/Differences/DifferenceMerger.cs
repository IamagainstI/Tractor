using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.Difference;

namespace Tractor.Core.Interactors.Differences
{
    public class DifferenceMerger : Pipeline<IEnumerable<IDifference>, IEnumerable<IDifference>>, IPipelineIO<IEnumerable<IDifference>, IEnumerable<IDifference>>
    {
        public EventHandler<IEnumerable<IDifference>> Input => (x, y) => Merge(y);

        public event EventHandler<IEnumerable<IDifference>> Output;

        public void Merge(IEnumerable<IDifference> differences)
        {
            List<IDifference> result = new List<IDifference>();
            var groups = differences.GroupBy(x => (x.ChangedObject, x.PropertyName));
            foreach (var group0 in groups)
            {
                switch (group0.Count())
                {
                    case 0:
                        throw new Exception("Неожиданное случилось!");
                    case int _ when group0.Any(x => x.Type != NotifyCollectionChangedAction.Replace):
                    case 1:
                        result.AddRange(group0);
                        break;
                    default:
                        var sorted = group0.OrderBy(x => x.CreationDate);
                        IDifference baseDiff = sorted.Last();
                        MergedDifference diff = new MergedDifference(baseDiff.ID)
                        {
                            Entity = baseDiff.Entity,
                            CreationDate = baseDiff.CreationDate,
                            ChangedObject = baseDiff.ChangedObject,
                            Type = baseDiff.Type,
                            PropertyName = baseDiff.PropertyName,
                            NewValue = baseDiff.NewValue,
                            OldValue = sorted.First().OldValue
                        };
                        diff.MergedIDs.AddRange(sorted.Select(x => x.ID));
                        result.Add(diff);
                        break;
                }
            }
            Output?.Invoke(this, result);
        }
    }
}
