using System;
using System.Drawing;
using Tractor.Core.Model;

namespace Tractor.Core.Objects.Descriptions.Labels
{
    public interface ILabel : IEquatable<ILabel>
    {
        Color Color { get; }
        string Name { get; }
    }
}