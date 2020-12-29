using FileStorage.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services.Interfaces
{
    public abstract class BaseStorageService
    {
        protected MetaFileInfoSettings MetaFileInfoSettings { get; private set; }
        protected ContainerForCommand ContainerForCommand { get; private set; }
        public BaseStorageService(ContainerForCommand containerForCommand, MetaFileInfoSettings metaFileInfoSettings)
        {
            ContainerForCommand = containerForCommand;
            MetaFileInfoSettings = metaFileInfoSettings;
        }
        public abstract void UserInfo();

        public abstract void FileUpload();

        public abstract void FileDownload();

        public abstract void FileMove();

        public abstract void FileRemove();

        public abstract void FileInfo();

        public abstract void FileFind();
    }
}
