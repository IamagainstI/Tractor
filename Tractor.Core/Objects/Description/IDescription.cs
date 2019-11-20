using System;
using System.Collections.Generic;
using EmptyBox.IO.Storage;

namespace Tractor.Core.Objects
{
    public interface IDescription
    {
		IList<ILabel> Labels { get; }
        void DescriptionChanged(IDescription Difference);
        IList<IStorageItem> Attachments { get; }
    }
}