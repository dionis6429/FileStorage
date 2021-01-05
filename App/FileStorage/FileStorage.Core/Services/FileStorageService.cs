using FileStorage.Core.Exceptions;
using FileStorage.Core.Models;
using FileStorage.Core.Services.Interfaces;
using System;
using System.IO;


namespace FileStorage.Core.Services
{
    public class FileStorageService : BaseStorageService
    {
        public FileStorageService(ContainerForCommand containerForCommand, MetaFileInfoSettings metaFileInfoSettings) : base(containerForCommand, metaFileInfoSettings)
        {

        }

        public override void FileUpload()
        {
            if (string.IsNullOrEmpty(ContainerForCommand.From) || !File.Exists(ContainerForCommand.From)) throw new FileNotFoundException($"File was not found {ContainerForCommand.From}");

            var metaFileInfoEntity = new MetaFileInfoEntity(ContainerForCommand.From);

            if (File.Exists(MetaFileInfoSettings.Path + metaFileInfoEntity.Name)) throw new FileLoadException($"File {metaFileInfoEntity.Name} has already uploaded");

            string newPath = $"{MetaFileInfoSettings.Path}{metaFileInfoEntity.Name}";
            FileInfo fileInf = new FileInfo(MetaFileInfoSettings.FullPath);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                Console.WriteLine($"File {metaFileInfoEntity.Name} is uploaded");
            }
        }

        public override void FileDownload()
        {
            if (string.IsNullOrEmpty(ContainerForCommand.To) || !Directory.Exists(ContainerForCommand.To)) throw new DirectoryNotFoundException($"Directory was not found {ContainerForCommand.To}");

            if (!File.Exists(MetaFileInfoSettings.Path + ContainerForCommand.From)) throw new FileNotFoundException($"File was not found {ContainerForCommand.From}");

            var metaFileInfoEntity = new MetaFileInfoEntity(ContainerForCommand.From);
            string path = $"{MetaFileInfoSettings.Path}{metaFileInfoEntity.Name}";
            string newPath = ContainerForCommand.To + metaFileInfoEntity.Name;
            var fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                Console.WriteLine("File is downloaded");
            }
        }

        public override void FileMove()
        {
            if (string.IsNullOrEmpty(ContainerForCommand.To)) throw new ArgumentException($"Invalid argument {ContainerForCommand.To}");

            if (File.Exists(ContainerForCommand.To)) throw new ArgumentException($"File {ContainerForCommand.To} exists");

            if (!File.Exists(ContainerForCommand.From)) throw new FileNotFoundException($"File {ContainerForCommand.From} was not found");

            var metaFileInfoEntity = new MetaFileInfoEntity(ContainerForCommand.From);
            string path = $"{metaFileInfoEntity.Name}";
            metaFileInfoEntity.Name = ContainerForCommand.To;
            string newPath = $"{MetaFileInfoSettings.Path}{MetaFileInfoSettings.Name}";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.MoveTo(newPath, true);
                Console.WriteLine("File is renamed");
            }
        }

        public override void FileRemove()
        {
            if (string.IsNullOrEmpty(ContainerForCommand.From) || !File.Exists(MetaFileInfoSettings.Path + ContainerForCommand.From)) throw new FileNotFoundException($"File was not found {ContainerForCommand.From}");

            var metaFileInfoEntity = new MetaFileInfoEntity(ContainerForCommand.From);
            string path = $"{MetaFileInfoSettings.Path}{metaFileInfoEntity.Name}";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                Console.WriteLine("File is removed");
            }
        }

        public override void FileInfo()
        {
            if (string.IsNullOrEmpty(ContainerForCommand.From) || !File.Exists(MetaFileInfoSettings.Path + ContainerForCommand.From)) throw new FileNotFoundException($"File {ContainerForCommand.From} was not found ");
        }

        public override void UserInfo()
        {
            
        }

        public override void FileFind()
        {
            
        }
    }
}
