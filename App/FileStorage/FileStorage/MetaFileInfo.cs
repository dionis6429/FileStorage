using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage
{
    public class MetaFileInfo
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
