using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public class BaseProgress : IProgress
    {
        public DateTime TimeLastChangeProgress { get; set; }
        public double ProgressPercentage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Equals(IProgress other)
        {
            if (other is BaseProgress _other)
            {
                return other.ProgressPercentage == ProgressPercentage && other.TimeLastChangeProgress == TimeLastChangeProgress;
            }
            else
            {
                return false;
            }
        }
    }
}
