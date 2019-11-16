using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Model
{
    public enum TaskState : byte
    {
        ToDo = 0,
        InWork = 1,
        Canceled = 254,
        Done = 255
    }
}
