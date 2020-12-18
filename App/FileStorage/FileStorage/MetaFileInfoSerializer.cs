using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage
{
    public class MetaFileInfoSerializer
    {
        public string Serialize(MetaFileInfoEntity metaFileInfoEntity)
        {
            return $"{metaFileInfoEntity.Id} {metaFileInfoEntity.Name} {metaFileInfoEntity.Size} {metaFileInfoEntity.Location}";
        }

        public MetaFileInfoEntity DeserializeString(string stringContent)
        {
            var parsedString = stringContent.Split(" ");
            return new MetaFileInfoEntity()
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
