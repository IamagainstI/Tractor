using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Credentials
{
    public interface IUserPasswordCredentials : ICredentials
    {
        string User { get; }
        string Password { get; }
    }
}
