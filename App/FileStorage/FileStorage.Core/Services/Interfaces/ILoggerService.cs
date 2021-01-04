using FileStorage.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services.Interfaces
{
    public interface ILoggerService
    {
        void LogConsole(string message);
        void LogFile(ExceptionInfoEntity exceptionInfoEntity, ExceptionInfoSettings exceptionInfoSettings, string message);
    }
}
