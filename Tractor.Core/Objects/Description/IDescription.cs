using System;
using System.Collections.Generic;
using EmptyBox.IO.Storage;

namespace Tractor.Core.Objects
{
    public interface IDescription : IEquatable<IDescription>
    {
		IList<ILabel> Labels { get; }
        void DescriptionChanged(IDescription Difference);
        IList<IStorageItem> Attachments { get; }

        void AddLabel(ILabel label);
        void RemoveLabel(ILabel label);
        void AddAttachment(IStorageItem storageItem);
        void RemoveAttachment(IStorageItem storageItem);

    }
}