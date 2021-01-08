using FileStorage.Core.Services.Interfaces;
using FileStorage.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services
{
    public class DbMetaFileService : BaseStorageService
    {
        private readonly IRepository<FileStorageDBEntity> _repository;
        public DbMetaFileService(IRepository<FileStorageDBEntity> repository)
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
