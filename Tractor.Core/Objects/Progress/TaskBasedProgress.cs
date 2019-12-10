using EmptyBox.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.Progress
{

    public class TaskBasedProgress : IProgress
    {
        #region Public events
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public double ProgressPercentage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
            where T : IEquatable<T>
        {
            if (!field.Equals(newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        public DateTime TimeLastChangeProgress { get; set; }
        public ITaskStorage Tasks { get; set; }
        public Guid ID { get; }

        public bool Equals(IProgress other)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
