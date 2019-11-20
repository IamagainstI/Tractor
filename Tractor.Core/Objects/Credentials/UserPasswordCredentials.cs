using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Objects.Credentials
{
    public class UserPasswordCredentials : IUserPasswordCredentials
    {
        public string User => throw new NotImplementedException();

        public string Password => throw new NotImplementedException();
    }
}
