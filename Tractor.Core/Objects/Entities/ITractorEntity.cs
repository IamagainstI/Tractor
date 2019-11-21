using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Entities
{
    public interface ITractorEntity : IEntity
    {
        bool CheckAvailability(DateTime dateTime, TimeSpan timeSpan); // сделал пока bool
    }
}
