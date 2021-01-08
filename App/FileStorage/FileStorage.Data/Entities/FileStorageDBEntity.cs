using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Data.Entities
{
    public class FileStorageDBEntity : Entity
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime CreationDate { get; set; }
        public int DownloadsNumber { get; set; }
    }
}
