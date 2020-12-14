using System;

namespace FileStorage
{
    public static class Authenticator
    {
        public static string Login = "q";
        public static string Password = "Q";
        
        public static bool Authenticate(string login, string password)
        {
            return Login == login && Password == password;            
        }

    }
}
