using FileStorage.Core.Services.Interfaces;
using FileStorage.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.Data.Repositories;
using FileStorage.Core.Models;
using System.Linq;

namespace FileStorage.Core.Services
{
    public class DbMetaFileService : BaseStorageService
    {
        private readonly IRepository _repository;
        public DbMetaFileService(
            ContainerForCommand containerForCommand,
            MetaFileInfoSettings metaFileInfoSettings, 
            IRepository repository) : base(containerForCommand, metaFileInfoSettings)
        {
            _repository = repository;
        }

        public override void FileDownload()
        {
            throw new NotImplementedException();
        }

        public override void FileFind()
        {
            throw new NotImplementedException();
        }

        public override void FileInfo()
        {
            var files = _repository.From<FileStorageDBEntity>().ToList();
            var file = _repository.GetById<FileStorageDBEntity>(1);
            _repository.Delete<FileStorageDBEntity>(1);

            //add
            var newFile = new FileStorageDBEntity
            {
                CreationDate = DateTime.Now,
                DownloadsNumber = 1,
                Extension = ".exe",
                Name = "FileName"
            };
            _repository.Save<FileStorageDBEntity>(newFile);

            //edit
            file.Name = "FileName1";
            _repository.Save<FileStorageDBEntity>(file);
        }

        public override void FileMove()
        {
            throw new NotImplementedException();
        }

        public override void FileRemove()
        {
            throw new NotImplementedException();
        }

        public override void FileUpload()
        {
            throw new NotImplementedException();
        }

        public override void UserInfo()
        {
            throw new NotImplementedException();
        }
    }
}
