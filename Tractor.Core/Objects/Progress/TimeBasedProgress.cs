using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public class TimeBasedProgress : ITimeBasedProgress
    {
        public BaseProgress Percentage => throw new NotImplementedException();

        public DateTime TimeLastChangeProgress => throw new NotImplementedException();

        double IProgress.Percentage => throw new NotImplementedException();

        public bool Equals(IProgress other)
        {
            throw new NotImplementedException();
        }
    }
}
