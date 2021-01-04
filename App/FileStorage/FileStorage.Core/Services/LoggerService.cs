using FileStorage.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FileStorage.Core.Exceptions;

namespace FileStorage.Core.Services
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message, string path = null)
        {
            Console.WriteLine(message);
        }
    }
}
