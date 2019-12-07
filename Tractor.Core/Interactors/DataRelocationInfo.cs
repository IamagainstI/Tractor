using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Interactors
{
    public sealed class DataRelocationInfo
    {
        public object OldStorage { get; set; }
        public object NewStorage { get; set; }
        public object Object { get; set; }
    }
}
