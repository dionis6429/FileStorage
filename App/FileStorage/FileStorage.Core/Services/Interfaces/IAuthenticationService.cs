﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services.Interfaces
{
    public  interface IAuthenticationService
    {
        bool Authenticate(string login, string password);
    }
}
