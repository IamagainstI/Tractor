using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Routers.Command
{
    public enum ProgressState : ulong
    {
        Failed = 0,
        InWork = 1,
        Finished = 2
    }
}
