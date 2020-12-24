using FileStorage.Core.Models;
using FileStorage.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FileStorage.Core.Services
{
    public class MetaFileInfoSerializerService : IMetaFileInfoSerializerService
    {
        public string Serialize(MetaFileInfoEntity metaFileInfoEntity)
        {
            return $"{metaFileInfoEntity.Id} {metaFileInfoEntity.Name} { metaFileInfoEntity.Extension} {metaFileInfoEntity.Size} {metaFileInfoEntity.CreationDate} {metaFileInfoEntity.DownloadsNumber}";
        }

        public MetaFileInfoEntity DeserializeString(string stringContent, string metaFilePath)
        {
            var parsedString = stringContent.Split(" ");

            return new MetaFileInfoEntity(metaFilePath)
            {
                Id = Guid.Parse(parsedString[0]),
                Name = parsedString[1],
                DownloadsNumber = Int32.Parse(parsedString[7])
            };
        }

        public List<MetaFileInfoEntity> DeserializeFileContent(string content, string metaFilePath)
        {
            var rows = content.Split(new[] { '\n' }).Where(x => !string.IsNullOrEmpty(x));
            var collection = new List<MetaFileInfoEntity>();
            foreach (var row in rows)
            {
                collection.Add(DeserializeString(row, metaFilePath));
            }
            return collection;
        }
    }
}
