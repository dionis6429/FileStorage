using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Models
{
    public class MetaFileInfoSettings
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public string FullPath
        {
            get

            {
                return $"{ Path }{ Name }";
            }
        }
    }
}
