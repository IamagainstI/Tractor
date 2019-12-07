using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tractor.Core;
using Tractor.Core.Interactors.Differences;
using Tractor.Core.Model;
using Tractor.Core.Objects.Difference;

using static System.Guid;

namespace testApp
{
    class Program
    {
        static void Main(string[] args)
        {
            object A0 = new object();
            object A1 = new object();

            IEnumerable<IDifference> store0 = null;
            IEnumerable<IDifference> store1 = null;

            DifferenceMerger a = new DifferenceMerger();
            DifferenceSeparator b = new DifferenceSeparator();
            ExternalInput<IEnumerable<IDifference>> c0 = new ExternalInput<IEnumerable<IDifference>>();
            ExternalInput<IEnumerable<IDifference>> c1 = new ExternalInput<IEnumerable<IDifference>>();
            ExternalOutput<IEnumerable<IDifference>> d0 = new ExternalOutput<IEnumerable<IDifference>>((x, y) => store0 = y);
            ExternalOutput<IEnumerable<IDifference>> d1 = new ExternalOutput<IEnumerable<IDifference>>((x, y) => store1 = y);
            _ = c0 >> a >> b >> d1;
            List<IDifference> @out = new List<IDifference>()
            {
                new Difference(NewGuid())
                {
                    ChangedObject = A1,
                    CreationDate = new DateTime(2222, 1, 1),
                    NewValue = 0,
                    OldValue = null,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                },
                new Difference(NewGuid())
                {
                    ChangedObject = A1,
                    CreationDate = new DateTime(2222, 1, 2),
                    NewValue = 1,
                    OldValue = 0,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                },
                new Difference(NewGuid())
                {
                    ChangedObject = A1,
                    CreationDate = new DateTime(2222, 1, 3),
                    NewValue = 2,
                    OldValue = 1,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                },
                new Difference(NewGuid())
                {
                    ChangedObject = A1,
                    CreationDate = new DateTime(2222, 1, 4),
                    NewValue = 3,
                    OldValue = 2,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                },
                new Difference(NewGuid())
                {
                    ChangedObject = A1,
                    CreationDate = new DateTime(2222, 1, 5),
                    NewValue = 4,
                    OldValue = 3,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                },
                new Difference(NewGuid())
                {
                    ChangedObject = A0,
                    CreationDate = new DateTime(2222, 1, 1),
                    NewValue = 0,
                    OldValue = null,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                },
                new Difference(NewGuid())
                {
                    ChangedObject = A0,
                    CreationDate = new DateTime(2222, 1, 2),
                    NewValue = 1,
                    OldValue = 0,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                },
                new Difference(NewGuid())
                {
                    ChangedObject = A0,
                    CreationDate = new DateTime(2222, 1, 3),
                    NewValue = 2,
                    OldValue = 1,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                },
                new Difference(NewGuid())
                {
                    ChangedObject = A0,
                    CreationDate = new DateTime(2222, 1, 4),
                    NewValue = 3,
                    OldValue = 2,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                },
                new Difference(NewGuid())
                {
                    ChangedObject = A0,
                    CreationDate = new DateTime(2222, 1, 5),
                    NewValue = 4,
                    OldValue = 3,
                    Type = System.Collections.Specialized.NotifyCollectionChangedAction.Replace
                }
            };
            c0.Send(@out);
            c1.Send(@out.Where(x => x.CreationDate != new DateTime(2222, 1, 3) && x.CreationDate != new DateTime(2222, 1, 4)).Concat(store0));
        }
    }
}
