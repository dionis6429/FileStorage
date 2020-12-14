using System;


namespace FileStorage
{
    public class StorageFile
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; private set; }
        public DateTime CreationData { get; set; }
        public int DownloadsNunber { get; private set; }

        public StorageFile(string name, string extention)
        {
            Name = name;
            Extension = extention;
        }


    }
}
