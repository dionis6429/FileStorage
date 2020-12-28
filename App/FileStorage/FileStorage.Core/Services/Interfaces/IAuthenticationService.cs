using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services.Interfaces
{
    public  interface IAuthenticationService
    {
        public string Login { get; }
        bool Authenticate(string login, string password);
    }
}
