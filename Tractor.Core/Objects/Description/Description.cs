using System;
using System.Collections.Generic;
using EmptyBox.IO.Storage;
using Tractor.Core.Objects;

namespace Tractor.Core
{
    public class Description : IDescription
    {
        public IList<Label> Labels => throw new NotImplementedException();

        public IList<IStorageItem> Attachments => throw new NotImplementedException();

        IList<ILabel> IDescription.Labels => throw new NotImplementedException();

        public void DescriptionChanged(IDescription Difference)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IDescription other)
        {
            throw new NotImplementedException();
        }
    }
}

