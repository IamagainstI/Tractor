﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects
{
    public interface IEntity : IStuff, IEquatable<IEntity>
    {
        string Name { get; }
    }
}
