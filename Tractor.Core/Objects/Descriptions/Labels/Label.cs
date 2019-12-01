using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Tractor.Core.Objects;

namespace Tractor.Core.Objects.Descriptions.Labels
{
    public class Label : ILabel
    {
        private string _Name;
        private Color _Color;

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        private void OnPropertyChange<T>(ref T field, T newValue, [CallerMemberName]string name = null)
        {
            if (true)
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public Label(Guid id = new Guid())
        {
            ID = id;
        }

        public Color Color 
        {
            get => _Color;
            set => OnPropertyChange(ref _Color, value); 
        }
        public string Name 
        { 
            get => _Name; 
            set => OnPropertyChange(ref _Name, value); 
        }

        public Guid ID { get; }

        public bool Equals(ILabel other)
        {
            return ((Name == other.Name) && (Color == other.Color));
        }

        public object Clone()
        {
            Label label = new Label(ID);
            label._Name = Name;
            label._Color = Color;
            return label;
        }
    }
}


