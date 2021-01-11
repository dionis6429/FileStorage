using FileStorage.Core.Services.Interfaces;
using FileStorage.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.Data.Repositories;
using FileStorage.Core.Models;
using System.Linq;
using System.IO;
using FileStorage.Core.Shared;

namespace FileStorage.Core.Services
{
    public class DbMetaFileService : BaseStorageService
    {
        private readonly IRepository _repository;
        private readonly IAuthenticationService _authenticationService;
        public DbMetaFileService(
            ContainerForCommand containerForCommand,
            MetaFileInfoSettings metaFileInfoSettings,
            IRepository repository, IAuthenticationService authenticationService) : base(containerForCommand, metaFileInfoSettings)
        {
            _repository = repository;
            _authenticationService = authenticationService;
        }

        public override void FileDownload()
        {
            var files = _repository.From<FileStorageDBEntity>().ToList();
            var file = files.Find(x => x.Name == ContainerForCommand.From);
            file.DownloadsNumber++;
            _repository.Save(file);
        }

        public override void FileFind()
        {
            var files = _repository.From<FileStorageDBEntity>().ToList();
            var foundfiles = files.FindAll(x => x.Name.Contains(ContainerForCommand.From));

            foreach (var file in foundfiles)
            {
                Console.WriteLine(file.Name);
            }
        }

        public override void FileInfo()
        {
            var files = _repository.From<FileStorageDBEntity>().ToList();
            var file = files.Find(x => x.Name == ContainerForCommand.From);

            Console.WriteLine("File name: {0}", file.Name);
            Console.WriteLine("File extension: {0}", file.Extension);
            Console.WriteLine("Creation date: {0}", file.CreationDate);
            Console.WriteLine($"Downloads number: {file.DownloadsNumber}");
        }

        public override void FileMove()
        {
            var files = _repository.From<FileStorageDBEntity>().ToList();
            var file = files.Find(x => x.Name == ContainerForCommand.From);
            file.Name = ContainerForCommand.To;
            file.Extension = Path.GetExtension(MetaFileInfoSettings.Path + ContainerForCommand.To);
            _repository.Save(file);
        }

        public override void FileRemove()
        {
            var files = _repository.From<FileStorageDBEntity>().ToList();
            var file = files.Find(x => x.Name == ContainerForCommand.From);
            _repository.Delete<FileStorageDBEntity>(file.Id);
        }

        public override void FileUpload()
        {
            var newFile = new FileStorageDBEntity
            {
                CreationDate = DateTime.Now,
                DownloadsNumber = 0,
                Extension = Path.GetExtension(ContainerForCommand.From),
                Name = Path.GetFileName(ContainerForCommand.From),
            };
            _repository.Save(newFile);
        }

        public override void UserInfo()
        {
            Console.WriteLine($"{Constants.Login_Label} {_authenticationService.Login}");
            Console.WriteLine($"{Constants.CreationDate_Label} {File.GetLastWriteTime(_authenticationService.Login)}");
            Console.WriteLine($"{Constants.UsedStorage_Label} {File.GetCreationTime(_authenticationService.Login)}");
        }
    }
}
