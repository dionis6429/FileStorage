using System;
using System.Collections.Generic;


namespace FileStorage
{
    public class MetaFileInfoSerializer
    {
        public string Serialize(MetaFileInfoEntity metaFileInfoEntity)
        {
            return $"{metaFileInfoEntity.Id} {metaFileInfoEntity.Name} { metaFileInfoEntity.Extension} {metaFileInfoEntity.Size} {metaFileInfoEntity.CreationDate} {metaFileInfoEntity.DownloadsNunber}";
        }

        public MetaFileInfoEntity DeserializeString(string stringContent)
        {
            var parsedString = stringContent.Split(" ");
            return new MetaFileInfoEntity("c:\\git-example\\lab-file-storage\\README.md ")
            {
                Id = Convert.ToInt32(parsedString[0])
            };
        }

        public List<MetaFileInfoEntity> DeserializeFileContent(string content)
        {
            var rows = content.Split(new[] { '\r', '\n' });
            var collection = new List<MetaFileInfoEntity>();
            foreach (var row in rows)
            {
                collection.Add(DeserializeString(row));
            }
            return collection;
        }
    }
}
