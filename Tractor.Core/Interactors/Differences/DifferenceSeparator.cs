using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.Difference;

namespace Tractor.Core.Interactors.Differences
{
    public class DifferenceSeparator : Pipeline<IEnumerable<IDifference>, IEnumerable<IDifference>>, IPipelineIO<IEnumerable<IDifference>, IEnumerable<IDifference>>
    {
        public EventHandler<IEnumerable<IDifference>> Input => (x, y) => Separate(y);

        public event EventHandler<IEnumerable<IDifference>> Output;

        public void Separate(IEnumerable<IDifference> differences)
        {
            List<IDifference> result = new List<IDifference>();
            var groups = differences.GroupBy(x => (x.ChangedObject, x.PropertyName));
            foreach (var group0 in groups)
            {
                switch (group0.Count())
                {
                    case 0:
                    case 1:
                        throw new Exception("Неожиданное случилось!");                        
                    case int _ when group0.Any(x => x.Type != NotifyCollectionChangedAction.Replace):
                    case 2:
                        result.AddRange(group0);
                        break;
                    default:
                        MergedDifference mergedgroup = new MergedDifference(Guid.NewGuid());
                        List<IDifference> differencesgroup = new List<IDifference>();
                        if(group0 is IMergedDifference merged)
                        {
                            mergedgroup.MergedIDs.Add(group0);
                        }
                        else
                        {
                            differencesgroup.AddRange(group0);
                        }                                     
                        var inter = mergedgroup.MergedIDs.Intersect(differencesgroup.Select(x => x.ID));
                        MergedDifference before = new MergedDifference(Guid.NewGuid());
                        MergedDifference after = new MergedDifference(Guid.NewGuid());
                        before.MergedIDs.AddRange(mergedgroup.MergedIDs.TakeWhile(x => x != inter.First()));
                        after.MergedIDs.AddRange(mergedgroup.MergedIDs.TakeWhile(x => x != inter.Last()));
                        result.Add(before);
                        result.AddRange(differencesgroup);
                        result.Add(after);
                        break;
                }
            }
            Output?.Invoke(this, result);
        }
    }
}
