using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EmptyBox.IO.Storage;
using Tractor.Core.Objects;
using Tractor.Core.Objects.Description;

namespace Tractor.Core
{
    public class Description : IDescription
    {

        #region Public events
        public event DescriptionChangeEventHandler DescriptionChange;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Public Objects
        public IList<ILabel> Labels { get; }

        public IList<IStorageItem> Attachments { get; }
        #endregion Public Objects

        #region Public Metods
        public void AddAttachment(IStorageItem storageItem)
        {
            throw new NotImplementedException();
        }

        public void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
             where T : IEquatable<T>
        {
            //ToDo написать это
        }

        public void AddLabel(ILabel label)
        {
            if ((label != null) && (!Labels.Contains(label)))
            {
                Labels.Add(label);
                //ToDo добавить вызов обработчика событий (каких?)
            }
        }

        public void DescriptionChanged(IDescription Difference) //? 
        {
            throw new NotImplementedException();
        }

        public bool Equals(IDescription other)
        {
            throw new NotImplementedException();
        }

        public void RemoveAttachment(IStorageItem storageItem)
        {
            if (Attachments.Contains(storageItem))
            {
                Attachments.Remove(storageItem);
                //ToDo добавить вызовы обработчика собыитий
            }
        }

        public void RemoveLabel(ILabel label)
        {
            if (Labels.Contains(label))
            {
                Labels.Remove(label);
                //ToDo добавтиь вызов обработчика событий
            }
        }
        #endregion
    }
}

