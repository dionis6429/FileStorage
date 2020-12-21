using System;
using System.Collections.Generic;
using System.Linq;


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
            return new MetaFileInfoEntity()
            {
                Id = Guid.Parse(parsedString[0])
            };
        }

        public List<MetaFileInfoEntity> DeserializeFileContent(string content)
        {
            var rows = content.Split(new[] { '\n' }).Where(x => !string.IsNullOrEmpty(x));
            var collection = new List<MetaFileInfoEntity>();
            foreach (var row in rows)
            {
                collection.Add(DeserializeString(row));
            }
            return collection;
        }
    }
}
