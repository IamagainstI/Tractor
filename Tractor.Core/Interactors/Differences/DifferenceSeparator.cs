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
                        List<IMergedDifference> mergedgroup = new List<IMergedDifference>();
                        List<IDifference> differencesgroup = new List<IDifference>();
                        foreach(var group1 in group0)
                        {
                            if (group1 is IMergedDifference merged)
                            {
                                mergedgroup.Add((IMergedDifference)group1);
                            }
                            else
                            {
                                differencesgroup.Add(group1);
                            }
                        }
                        var first = mergedgroup.Select(x => x.MergedIDs).First();
                        var last = mergedgroup.Select(x => x.MergedIDs).Last();
                        var inter = mergedgroup.Select(x => x.MergedIDs.Intersect(differencesgroup.Select(y => y.ID)));
                        List<MergedDifference> before = new List<MergedDifference>();
                        MergedDifference after = new MergedDifference(Guid.NewGuid());                       
                        before.Add(mergedgroup.Select(y => y.MergedIDs).TakeWhile(x => x != inter.First())));
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
