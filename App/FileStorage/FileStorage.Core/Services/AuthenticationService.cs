using FileStorage.Core.Services.Interfaces;
using FileStorage.Core.Shared;
using System;

namespace FileStorage.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool Authenticate(string login, string password)
        {
            return Constants.Login == login && Constants.Password == password;
        }
    }
}
