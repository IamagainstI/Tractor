using System;
using System.Collections.Generic;
using Tractor.Core.Objects;

namespace Tractor.Core
{
    public class Description : IDescription
    {
        public IList<Label> Labels => throw new NotImplementedException();

        public void DescriptionChanged(IDescription Difference)
        {
            throw new NotImplementedException();
        }
    }
}

