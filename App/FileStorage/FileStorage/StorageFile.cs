using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileStorage
{
    [Serializable]
    public class StorageFile : ISerializable
    {        
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; private set; }
        public DateTime CreationDate { get; set; }
        public int DownloadsNunber { get; private set; }

        public StorageFile()
        {

        }
        public StorageFile(string name)
        {
            Name = name;
            //Extension = extention;
        }
        public override string ToString()
        {
            return Name; 
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Extension", Extension);
            info.AddValue("Size", Size);
            info.AddValue("CreationDate", CreationDate);
            info.AddValue("DownloadsNumber", DownloadsNunber);
        }

        public StorageFile(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Extension = (string)info.GetValue("Extension", typeof(string));
            Size = (int)info.GetValue("Size", typeof(int));
            CreationDate = (DateTime)info.GetValue("CreationDate", typeof(DateTime));
            DownloadsNunber = (int)info.GetValue("DownloadsNumber", typeof(int));
        }
    }
}
