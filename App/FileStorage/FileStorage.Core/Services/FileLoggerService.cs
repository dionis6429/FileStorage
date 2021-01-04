using FileStorage.Core.Exceptions;
using FileStorage.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileStorage.Core.Services
{
    public class FileLoggerService : ILoggerService
    {

        public void Log(string message, string path = null)
        {
            if (path == null) throw new Exception("Path should not be null.");

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
