using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Stages
{
    public interface IStage
    {
        IDictionary<string, bool> StageDictionary { get; }
    }
}
