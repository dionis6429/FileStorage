using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage
{
    public class MetaFileInfoEntity
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; private set; }
    }
}
