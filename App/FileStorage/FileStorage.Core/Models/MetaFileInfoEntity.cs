using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileStorage.Core.Models
{
    public class MetaFileInfoEntity
    {
        public string Location { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; private set; }
        public DateTime CreationDate { get; set; }
        public int DownloadsNumber { get; set; }

        public MetaFileInfoEntity(string location)
        {
            Location = location;
            Name = Path.GetFileName(location);
            Extension = Path.GetExtension(location);
            CreationDate = File.GetCreationTime(location);
            Size = 0;
            DownloadsNumber = 0;
            Id = Guid.NewGuid();
        }
    }
}
