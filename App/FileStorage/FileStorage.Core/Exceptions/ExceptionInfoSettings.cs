using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Exceptions
{
    public class ExceptionInfoSettings
    {
        public string LogPath { get; set; }
        public string LogName { get; set; }
        public string FullLogPath
        {
            get

            {
                return $"{ LogPath }{ LogName }";
            }
        }
    }
}
