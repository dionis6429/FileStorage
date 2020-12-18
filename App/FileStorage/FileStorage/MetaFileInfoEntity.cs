using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileStorage
{
    public class MetaFileInfoEntity
    {
        public string Location { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; private set; }
        public DateTime CreationDate { get; set; }
        public int DownloadsNunber { get; private set; }

        public MetaFileInfoEntity(string location)
        {
            Location = location;
            Name = Path.GetFileName(location);
            Extension = Path.GetExtension(location);
            CreationDate = File.GetCreationTime(location);
            Size = 0;
            DownloadsNunber = 0;
        }
    }
}
