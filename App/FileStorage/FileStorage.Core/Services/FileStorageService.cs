﻿using FileStorage.Core.Models;
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
            var metaFileInfoEntity = new MetaFileInfoEntity(ContainerForCommand.From);
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
            var metaFileInfoEntity = new MetaFileInfoEntity(ContainerForCommand.From);
            string path = $"{MetaFileInfoSettings.Path}{MetaFileInfoSettings.Name}";
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

        }

        public override void UserInfo()
        {
            
        }
    }
}