using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public class TimeBasedProgress : ITimeBasedProgress
    {
        public Progress Percentage => throw new NotImplementedException();

        public DateTime TimeLastChangeProgress => throw new NotImplementedException();

        public double ProgressPercentage => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Equals(IProgress other)
        {
            throw new NotImplementedException();
        }

    }
}
