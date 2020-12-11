using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage
{
    public static class Authenticator
    {
        public static string Login = "";
        public static string Password = "";

        public static bool Authenticate(string login, string password)
        {
            return Login == login && Password == password;
        }
    }
}
