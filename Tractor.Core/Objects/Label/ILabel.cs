using System;
using Tractor.Core.Model;

namespace Tractor.Core.Objects
{
    public interface ILabel
    {
        string Color { get; }
        string Name { get; }
    }
}