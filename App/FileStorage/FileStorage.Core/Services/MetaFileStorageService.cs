using FileStorage.Core.Models;
using FileStorage.Core.Services.Interfaces;
using FileStorage.Core.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace FileStorage.Core.Services
{
    public class MetaFileStorageService : BaseStorageService
    {
        private readonly IMetaFileInfoSerializerService _metaFileInfoSerializerService;
        private readonly IAuthenticationService _authenticationService;
        public MetaFileStorageService(ContainerForCommand containerForCommand,
            MetaFileInfoSettings metaFileInfoSettings,
            IMetaFileInfoSerializerService metaFileInfoSerializerService,
            IAuthenticationService authenticationService
            )
            : base(containerForCommand, metaFileInfoSettings)
        {
            _metaFileInfoSerializerService = metaFileInfoSerializerService;
            _authenticationService = authenticationService;
        }

        public override void FileInfo() //file info <file-name>" - отображение информации о файле file-name
        {
            //MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer(MetaFileInfo.FullPath);
            //metaFileInfoSerializer = metaFileInfoSerializer.DeserializeString()
            //Console.WriteLine("File name: {0}", metaFileInfoEntity.Name);
            //    Console.WriteLine("File extension: {0}", metaFileInfoEntity.Extension);
            //    Console.WriteLine("Creation date: {0}", metaFileInfoEntity.CreationDate);
            //    Console.WriteLine($"File size: {metaFileInfoEntity.Size} bites");
            //    Console.WriteLine($"Downloads number: {metaFileInfoEntity.DownloadsNumber}");
        }

        public override void UserInfo()
        {
            Console.WriteLine($"{Constants.Login_Label} {_authenticationService.Login}");
            Console.WriteLine($"{Constants.CreationDate_Label} {File.GetLastWriteTime(_authenticationService.Login)}");
            Console.WriteLine($"{Constants.UsedStorage_Label} {File.GetCreationTime(_authenticationService.Login)}");
        }
        public override void FileUpload() //file upload <path-to-file>" - загрузка файла, находящегося по пути path-to-file в хранилище;
        {
            var metaFileInfoEntity = new MetaFileInfoEntity(ContainerForCommand.From);
            using (StreamWriter sw = new StreamWriter(MetaFileInfoSettings.FullPath, true))
            {
                sw.WriteLine(_metaFileInfoSerializerService.Serialize(metaFileInfoEntity));
            }
        }
        public override void FileDownload() //file download <file-name> <destination-path>" - скачивание файла c именем file-name из хранилища в директорию destination-path;
        {

            var fileInfo = new FileInfo(MetaFileInfoSettings.FullPath);
            var filesWithoutDownloadedFile = new List<MetaFileInfoEntity>();
            var changedDownloadsNumber = new List<MetaFileInfoEntity>();

            using (StreamReader sr = new StreamReader(MetaFileInfoSettings.FullPath))
            {
                var collection = _metaFileInfoSerializerService.DeserializeFileContent(sr.ReadToEnd(), MetaFileInfoSettings.FullPath);
                filesWithoutDownloadedFile = collection.Where(x => !x.Name.Contains(ContainerForCommand.From)).ToList();
                changedDownloadsNumber = collection.Where(x => x.Name.Contains(ContainerForCommand.From)).ToList();
                changedDownloadsNumber[0].DownloadsNumber++;
            }

            using (StreamWriter sw = new StreamWriter(fileInfo.Open(FileMode.Truncate)))
            {
                var sum = filesWithoutDownloadedFile.Union(changedDownloadsNumber);
                foreach (var file in sum)
                {
                    sw.WriteLine(_metaFileInfoSerializerService.Serialize(file));
                }
            }
        }
        public override void FileMove() //file move <source-file-name> <destination-file-name>" - переименование файла в рамках хранилища: из пути source-file-name в destination-file-name"
        {
            var fileInfo = new FileInfo(MetaFileInfoSettings.FullPath);
            var filesWithoutSourceFile = new List<MetaFileInfoEntity>();
            var changedNameFile = new List<MetaFileInfoEntity>();

            using (StreamReader sr = new StreamReader(MetaFileInfoSettings.FullPath))
            {
                var collection = _metaFileInfoSerializerService.DeserializeFileContent(sr.ReadToEnd(), MetaFileInfoSettings.FullPath);
                filesWithoutSourceFile = collection.Where(x => !x.Name.Contains(ContainerForCommand.From)).ToList();
                changedNameFile = collection.Where(x => x.Name.Contains(ContainerForCommand.From)).ToList();
                changedNameFile[0].Name = ContainerForCommand.To;
            }

            using (StreamWriter sw = new StreamWriter(fileInfo.Open(FileMode.Truncate)))
            {
                var sum = filesWithoutSourceFile.Union(changedNameFile);
                foreach (var file in sum)
                {
                    sw.WriteLine(_metaFileInfoSerializerService.Serialize(file));
                }
            }
        }
        public override void FileRemove() //file remove <file-name>" - удаление файла file-name из хранилища. Пользовательская корзина не предусмотрена, поэтому удаление осуществляется раз и навсегда;
        {
            var fileInfo = new FileInfo(MetaFileInfoSettings.FullPath);
            var filesWithoutFileToRemove = new List<MetaFileInfoEntity>();

            using (StreamReader sr = new StreamReader(MetaFileInfoSettings.FullPath))
            {
                var collection = _metaFileInfoSerializerService.DeserializeFileContent(sr.ReadToEnd(), MetaFileInfoSettings.FullPath);
                filesWithoutFileToRemove = collection.Where(x => !x.Name.Contains(ContainerForCommand.From)).ToList();
            }

            using (StreamWriter sw = new StreamWriter(fileInfo.Open(FileMode.Truncate)))
            {
                foreach (var file in filesWithoutFileToRemove)
                {
                    sw.WriteLine(_metaFileInfoSerializerService.Serialize(file));
                }
            }
        }
    }
}
