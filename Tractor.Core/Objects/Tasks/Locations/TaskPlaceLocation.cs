using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Model;

namespace Tractor.Core.Objects.Tasks.Locations
{
    public class TaskPlaceLocation : ITaskLocation
    {
        public Guid ID { get; }
        public TaskPlaceLocation(Guid id)
        {
            ID = id;
        }
        public bool Equals(ITaskLocation other)
        {
            return ID == other.ID;
        }
    }
}
