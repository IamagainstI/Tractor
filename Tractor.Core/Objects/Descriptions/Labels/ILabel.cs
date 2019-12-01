using System;
using System.ComponentModel;
using System.Drawing;
using Tractor.Core.Model;

namespace Tractor.Core.Objects.Descriptions.Labels
{
    public interface ILabel : IEquatable<ILabel>, INotifyPropertyChanged, INotifyPropertyChanging
    {
        Color Color { get; set; }
        string Name { get; set; }
    }
}