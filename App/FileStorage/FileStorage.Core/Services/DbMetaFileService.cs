using FileStorage.Core.Services.Interfaces;
using FileStorage.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.Data.Repositories;
using FileStorage.Core.Models;

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
            throw new NotImplementedException();
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
