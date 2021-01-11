using FileStorage.Core.Models;
using FileStorage.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FileStorage.Tests
{
    [TestClass]
    public class MetaFileInfoSerializerServiceTests
    {
        [TestMethod]
        public void Serialize_MetaFileInfoEntity()
        {
            //Arrange
            var metaFileInfoSerializerService = new MetaFileInfoSerializerService();
            var metaFileInfoEntity = new MetaFileInfoEntity(@"c:\Users\s.taras\source\repos\FileStorage\App\FileStorage\FileStorage.Tests\Apress.pdf");
            string expected = $"{metaFileInfoEntity.Id} Apress.pdf .pdf 0 {metaFileInfoEntity.CreationDate} 0";
            string actual;

            //Act 
            actual = metaFileInfoSerializerService.Serialize(metaFileInfoEntity);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeserializeString()
        {
            //Arrange
            var metaFileInfoSerializerService = new MetaFileInfoSerializerService();
            string stringContent = "0623e038-63e1-43a7-b005-c646a586293a Apress.pdf .pdf 0 12/21/2020 3:43:05 PM 0";
            string metaFilePath = @"c:\Users\s.taras\source\repos\FileStorage\App\FileStorage\FileStorage.Tests\Meta.txt";
            string actual = "0623e038-63e1-43a7-b005-c646a586293a Apress.pdf 0";

            //Act 
            var a = metaFileInfoSerializerService.DeserializeString(stringContent, metaFilePath);
            string expected = $"{a.Id} {a.Name} {a.DownloadsNumber}";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeserializeFileContent()
        {
            //Arrange
            var metaFileInfoSerializerService = new MetaFileInfoSerializerService();
            string stringContent = "0623e038-63e1-43a7-b005-c646a586293a Apress.pdf .txt 0 12/24/2020 8:31:36 AM 0\r\n229b3568-1a8b-43fc-a477-ca828cb9df8e readme.md .txt 0 12/24/2020 8:31:36 AM 0\r\n91eafa50-c09c-4e94-9c89-0a1f09b59f0c TOTALCMD64.EXE .txt 0 12/24/2020 8:31:36 AM 2\r\n";
            string metaFilePath = @"c:\Users\s.taras\source\repos\FileStorage\App\FileStorage\FileStorage.Tests\Meta.txt";
            int expected = 3;

            //Act
            var collection = metaFileInfoSerializerService.DeserializeFileContent(stringContent, metaFilePath);

            //Assert
            Assert.AreEqual(expected, collection.Count);

        }
    }
}
