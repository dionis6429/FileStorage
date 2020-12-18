using System;
using System.IO;

namespace FileStorage
{
    //[Serializable]
    public class StorageFile
    {
        public string Location { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; private set; }
        public DateTime CreationDate { get; set; }
        public int DownloadsNunber { get; private set; }

       public StorageFile(string location)
        {
            Location = location;
            Name = Path.GetFileName(location);
            Extension = Path.GetExtension(location);
            CreationDate = File.GetCreationTime(location);
            Size = 0;
            DownloadsNunber = 0;
        }

        //public override string ToString()
        //{
        //    return string.Format("Name: {0} Extension: {1} Size: {2} CreationDate: {3} DownloadsNumber: {4}", Name, Extension, Size, CreationDate, DownloadsNunber);
        //}

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("Name", Name);
        //    info.AddValue("Extension", Extension);
        //    info.AddValue("Size", Size);
        //    info.AddValue("CreationDate", CreationDate);
        //    info.AddValue("DownloadsNumber", DownloadsNunber);
        //}

        //public StorageFile(SerializationInfo info, StreamingContext context)
        //{
        //    Name = (string)info.GetValue("Name", typeof(string));
        //    Extension = (string)info.GetValue("Extension", typeof(string));
        //    Size = (int)info.GetValue("Size", typeof(int));
        //    CreationDate = (DateTime)info.GetValue("CreationDate", typeof(DateTime));
        //    DownloadsNunber = (int)info.GetValue("DownloadsNumber", typeof(int));
        //}
    }
}
