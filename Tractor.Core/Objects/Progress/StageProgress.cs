using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tractor.Core.Objects.Progress
{
    class StageProgress : IStageProgress
    {
        private DateTime _TimeLastchangeProgress;
        public IDictionary<string, bool> StageDictionary { get; }
        #region Public events
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public double ProgressPercentage
        {
            get
            {
                int count = 0;
                foreach (var DoneStage in StageDictionary)
                {
                    if (DoneStage.Value == true)
                    {
                        count++;
                    }
                }
                return count / StageDictionary.Count();
            }
        }

        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
        {
            if (!Equals(field, newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        public DateTime TimeLastChangeProgress 
        {
            get => _TimeLastchangeProgress;
            set => OnPropertyChange(ref _TimeLastchangeProgress, value);
        }

        public Guid ID { get; }

        public StageProgress(Guid id)
        {
            ID = id;
        }

        public bool Equals(IProgress other)
        {
            return ID == other.ID;
        }

        public object Clone()
        {
            var result = new StageProgress(ID);
            result._TimeLastchangeProgress = _TimeLastchangeProgress;
            foreach (var item in StageDictionary)
            {
                result.StageDictionary.Add(item);
            }
            return result;
        }
    }
}
