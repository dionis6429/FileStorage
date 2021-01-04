using FileStorage.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services.Interfaces
{
    public interface ILoggerService
    {
        void Log(string message, string path = null);
    }
}
