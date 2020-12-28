using FileStorage.Core.Services.Interfaces;
using FileStorage.Core.Shared;
using System;

namespace FileStorage.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public string _login = "1";
        public string _password = "2";

        public bool Authenticate(string login, string password)
        {
            return _login == login && _password == password;
        }

        public string Login
        {
            get
            {
                return _password;
            }
        }
    }
}
