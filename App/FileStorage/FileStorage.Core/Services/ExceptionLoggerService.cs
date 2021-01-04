using FileStorage.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FileStorage.Core.Exceptions;

namespace FileStorage.Core.Services
{
    public class ExceptionLoggerService : ILoggerService
    {
        public void LogConsole(string message)
        {
            Console.WriteLine(message);
        }
        public void LogFile(ExceptionInfoEntity exceptionInfoEntity, ExceptionInfoSettings exceptionInfoSettings, string message)
        {
            using (StreamWriter sw = new StreamWriter(exceptionInfoSettings.FullLogPath, true))
            {
                sw.WriteLine($"{exceptionInfoEntity.Id}, {exceptionInfoEntity.TargetSite}, {exceptionInfoEntity.Message}, {message}");
            }
        }
    }
}
