using System;
using System.Collections.Generic;
using EmptyBox.IO.Storage;
using Tractor.Core.Objects;

namespace Tractor.Core
{
    public class Description : IDescription
    {
        #region Public Objects
        public IList<ILabel> Labels { get; }

        public IList<IStorageItem> Attachments { get; }

        public void AddAttachment(IStorageItem storageItem)
        {
            throw new NotImplementedException();
        }
        #endregion Public Objects

        #region Public Metods
        public void AddLabel(ILabel label)
        {
            throw new NotImplementedException();
        }

        public void DescriptionChanged(IDescription Difference)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IDescription other)
        {
            throw new NotImplementedException();
        }

        public void RemoveAttachment(IStorageItem storageItem)
        {
            throw new NotImplementedException();
        }

        public void RemoveLabel(ILabel label)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

