using System;
using System.IO;


namespace FileStorage
{
    public class FileStorageManager
    {
        public MetaFileInfo MetaFileInfo { get; set; }
        public FileStorageManager(Command command, MetaFileInfo metaFileInfo)
        {
            Command = command;
            MetaFileInfo = MetaFileInfo;
        }
        public Command Command { get; set; }
        public void RunCommand()
        {
            switch (Command.FileOperation)
            {
                case FileOperation.file_upload:
                    FileUpload();
                    break;

                case FileOperation.file_download:
                    FileDownload();
                    break;

                case FileOperation.file_move:
                    FileMove();
                    break;

                case FileOperation.file_remove:
                    FileRemove();
                    break;

                case FileOperation.file_info:
                    //FileInfo();
                    break;

                default:
                    break;
            }
        }
        private void FileUpload() //file upload <path-to-file>" - загрузка файла, находящегося по пути path-to-file в хранилище;
        {
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);
            string path = Command.From;
            string newPath = $"{MetaFileInfo.Path}{metaFileInfoEntity.Name}";
            FileInfo fileInf = new FileInfo(MetaFileInfo.FullPath);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                Console.WriteLine($"File {metaFileInfoEntity.Name} is uploaded");
            }
        }
        private void FileDownload() //file download <file-name> <destination-path>" - скачивание файла c именем file-name из хранилища в директорию destination-path;
        {
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);
            string path = $"{MetaFileInfo.Path}{metaFileInfoEntity.Name}";
            string newPath = Command.To + metaFileInfoEntity.Name;
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                Console.WriteLine("File is downloaded");
            }
        }
        private void FileMove() //file move <source-file-name> <destination-file-name>" - переименование файла в рамках хранилища: из пути source-file-name в destination-file-name"
        {
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);
            string path = $"{metaFileInfoEntity.Name}";
            metaFileInfoEntity.Name = Command.To;
            string newPath = $"{MetaFileInfo.Path}{metaFileInfoEntity.Name}";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.MoveTo(newPath, true);
                Console.WriteLine("File is renamed");
            }
        }
        private void FileRemove() //file remove <file-name>" - удаление файла file-name из хранилища. Пользовательская корзина не предусмотрена, поэтому удаление осуществляется раз и навсегда;
        {
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);
            string path = $"{MetaFileInfo.Path}{metaFileInfoEntity.Name}";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                Console.WriteLine("File is removed");
            }
        }

    }
}
