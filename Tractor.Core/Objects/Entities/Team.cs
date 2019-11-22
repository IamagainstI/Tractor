using EmptyBox.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tractor.Core.Model;
using Tractor.Core.Objects.Difference;
using Tractor.Core.Objects.Entities;

namespace Tractor.Core.Objects
{
    public class Team : ITeam
    {
        #region Public objects
        public Guid ID { get; }
        public string Name { get; set; }
        public IDictionary<IEntity, IEntityRole> Members { get; }
        #endregion

        #region Public events
        public event TeamChangeEventHandler TeamChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        //ToDo добавить события на добавление членов команды
        #endregion

        #region Protected metods
        protected void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
         where T : IEquatable<T>
        {
            if (!field.Equals(newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); // уведомляем интерфейс
                IDifference difference = null;
                switch (name)
                {
                    case nameof(Name):
                        difference = new TeamDifferenceNameChanged((string)(object)newValue, this, DateTime.Now);
                        break;
                }
                TeamChanged?.Invoke(difference); //уведомляем базу данных
            }
        }
        #endregion


        #region Public metods
        public bool Equals(IEntity other)
        {
            if (other != null)
            {
                return ID == other.ID;
            }
            return false;
        }

        public void AddMember(IEntity item, IEntityRole itemRole)
        {

            if (Members.ContainsKey(item))
            {
                throw new ArgumentException();
            }
            else
            {
                Members.Add(item, itemRole);
                //TODO добавить вызов событий
            }
        }

        public void RemoveMember(IEntity item)
        {

            if (!Members.ContainsKey(item))
            {
                throw new ArgumentException();
            }
            else
            {
                Members.Remove(item);
                //TODO добавить вызов событий
            }
        }
        #endregion
    }
}
