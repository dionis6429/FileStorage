using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace FileStorage
{
    [Serializable()]
    public class StorageFile
    {        
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; private set; }
        public DateTime CreationData { get; set; }
        public int DownloadsNunber { get; private set; }

        public StorageFile()
        {

        }
        public StorageFile(string name, string extention)
        {
            Name = name;
            Extension = extention;
        }
        public override string ToString()
        {
            return Name; 
        }

    }
}
