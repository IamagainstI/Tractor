using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    public class BaseProgress : IProgress
    {
        public DateTime TimeLastChangeProgress { get; set; }
        public double Percentage { get; set; }
        public bool Equals(IProgress other)
        {
            return other.Percentage == Percentage;
        }
    }
}
