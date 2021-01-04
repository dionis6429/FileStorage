using FileStorage.Core.Exceptions;
using FileStorage.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileStorage.Core.Services
{
    public class FileLoggerService : IFileLoggerService
    {
        public void FileLog(ExceptionInfoEntity exceptionInfoEntity, ExceptionInfoSettings exceptionInfoSettings, string message)
        {
            using (StreamWriter sw = new StreamWriter(exceptionInfoSettings.FullLogPath, true))
            {
                sw.WriteLine($"{exceptionInfoEntity.Id}, {exceptionInfoEntity.TargetSite}, {exceptionInfoEntity.Message}, {message}");
            }
        }
    }
}
