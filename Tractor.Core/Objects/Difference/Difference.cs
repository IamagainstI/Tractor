using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Difference
{
    class Difference : IDifference
    {
        public DateTime CreationDate { get; }

        public byte[] GetDifferenceHash()
        {
            throw new NotImplementedException();
        }
    }
}
