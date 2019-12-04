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
                        throw new Exception("Неожиданное случилось!");                        
                    case 1:
                        result.AddRange(group0);
                        break;
                    default:
                        List<Guid> ids = new List<Guid>();
                        Dictionary<Guid, IDifference> diffs = new Dictionary<Guid, IDifference>();
                        List<IDifference> sorted = group0.ToList();
                        sorted.Sort((x, y) => x.CompareTo(y));
                        foreach (IDifference diff in sorted)
                        {
                            if (diff is IMergedDifference merge)
                            {
                                Guid prev;
                                foreach (Guid id in merge.MergedIDs)
                                {
                                    if (!diffs.ContainsKey(id))
                                    {
                                        ids.Insert(ids.IndexOf(prev)+1, id);
                                        diffs[id] = null;
                                    }
                                    else
                                    {
                                        prev = id;
                                    }
                                }
                            }
                            else
                            {
                                ids.Add(diff.ID);
                                diffs[diff.ID] = diff; 
                            }
                        }
                        List<Guid> missed = new List<Guid>();
                        foreach (Guid id in ids)
                        {
                            if (diffs[id] != null)
                            {
                                switch (missed.Count)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        Difference diff = new Difference(missed.Last())
                                        {
                                            ChangedObject = group0.Key.ChangedObject,
                                            PropertyName = group0.Key.PropertyName,
                                            NewValue = diffs[id].OldValue,
                                            OldValue = result.LastOrDefault()?.NewValue,
                                            Type = NotifyCollectionChangedAction.Replace
                                        };
                                        missed.Clear();
                                        result.Add(diff);
                                        break;
                                    default:
                                        MergedDifference merge = new MergedDifference(missed.Last())
                                        {
                                            ChangedObject = group0.Key.ChangedObject,
                                            PropertyName = group0.Key.PropertyName,
                                            NewValue = diffs[id].OldValue,
                                            OldValue = result.LastOrDefault()?.NewValue,
                                            Type = NotifyCollectionChangedAction.Replace
                                        };
                                        merge.MergedIDs.AddRange(missed);
                                        missed.Clear();
                                        result.Add(merge);
                                        break;
                                }
                                result.Add(diffs[id]);
                            }
                            else
                            {
                                missed.Add(id);
                            }
                        }
                        break;
                }
            }
            Output?.Invoke(this, result);
        }
    }
}
