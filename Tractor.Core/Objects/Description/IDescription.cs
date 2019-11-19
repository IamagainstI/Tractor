using System;
using System.Collections.Generic;

namespace Tractor.Core.Objects
{
    public interface IDescription
    {
		IList<Label> Labels { get; }
        void DescriptionChanged(IDescription Difference);

    }
}