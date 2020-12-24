using FileStorage.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services.Interfaces
{
    public interface IMetaFileInfoSerializerService
    {
        string Serialize(MetaFileInfoEntity metaFileInfoEntity);

        MetaFileInfoEntity DeserializeString(string stringContent, string metaFilePath);

        List<MetaFileInfoEntity> DeserializeFileContent(string content, string metaFilePath);
    }
}
