using System;
using System.Drawing;
using Tractor.Core.Objects;

namespace Tractor.Core.Objects.Descriptions.Labels
{
    public class Label : ILabel
    {
        public string Name { get; }
        public Color Color { get; }

        public bool Equals(ILabel other)
        {
            return ((Name == other.Name) && (Color == other.Color));
        }
    }
}


