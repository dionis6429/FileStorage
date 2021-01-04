using FileStorage.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services.Interfaces
{
    public interface IFileLoggerService
    {
        void FileLog(ExceptionInfoEntity exceptionInfoEntity, ExceptionInfoSettings exceptionInfoSettings, string message);
    }
}
