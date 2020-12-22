using System;
using System.Collections.Generic;
using System.Linq;


namespace FileStorage
{
    public class MetaFileInfoSerializer
    {
        public string MetaFilePath { get; set; }
        public MetaFileInfoSerializer(string metaFilePath)
        {
            MetaFilePath = metaFilePath;
        }
        public string Serialize(MetaFileInfoEntity metaFileInfoEntity)
        {
            return $"{metaFileInfoEntity.Id} {metaFileInfoEntity.Name} { metaFileInfoEntity.Extension} {metaFileInfoEntity.Size} {metaFileInfoEntity.CreationDate} {metaFileInfoEntity.DownloadsNumber}";
        }

        public MetaFileInfoEntity DeserializeString(string stringContent)
        {
            var parsedString = stringContent.Split(" ");

            return new MetaFileInfoEntity(MetaFilePath)
            {
                Id = Guid.Parse(parsedString[0]),
                Name = parsedString[1],
                DownloadsNumber = Int32.Parse(parsedString[7])
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
