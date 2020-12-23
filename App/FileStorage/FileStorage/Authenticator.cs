using System;

namespace FileStorage
{
    public static class Authenticator
    {
        public static string Login = "1";
        public static string Password = "2";
        
        public static bool Authenticate(string login, string password)
        {
            return Login == login && Password == password;            
        }
    }
}
