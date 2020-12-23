using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace FileStorage
{
    public class MetaFileStorageManager
    {
        public Command Command { get; set; }
        public MetaFileInfo MetaFileInfo { get; set; }
        public MetaFileStorageManager(Command command, MetaFileInfo metaFileInfo)
        {
            Command = command;
            MetaFileInfo = metaFileInfo;
        }

        public void RunCommand()
        {
            switch (Command.FileOperation)
            {
                case FileOperation.user_info:
                    UserInfo();
                    break;

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
                    FileInfo();
                    break;
                default:
                    break;
            }
        }

        private void FileInfo() //file info <file-name>" - отображение информации о файле file-name
        {
            //MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer(MetaFileInfo.FullPath);
            //metaFileInfoSerializer = metaFileInfoSerializer.DeserializeString()
            //Console.WriteLine("File name: {0}", metaFileInfoEntity.Name);
            //    Console.WriteLine("File extension: {0}", metaFileInfoEntity.Extension);
            //    Console.WriteLine("Creation date: {0}", metaFileInfoEntity.CreationDate);
            //    Console.WriteLine($"File size: {metaFileInfoEntity.Size} bites");
            //    Console.WriteLine($"Downloads number: {metaFileInfoEntity.DownloadsNumber}");
        }

        private void UserInfo()
        {
            Console.WriteLine($"{Constants.Login_Label} {Authenticator.Login}");
            Console.WriteLine($"{Constants.CreationDate_Label} {File.GetLastWriteTime(Authenticator.Login)}");
            Console.WriteLine($"{Constants.UsedStorage_Label} {File.GetCreationTime(Authenticator.Login)}");
        }
        private void FileUpload() //file upload <path-to-file>" - загрузка файла, находящегося по пути path-to-file в хранилище;
        {
            MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer(MetaFileInfo.FullPath);
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);

            using (StreamWriter sw = new StreamWriter(MetaFileInfo.FullPath, true))
            {
                sw.WriteLine(metaFileInfoSerializer.Serialize(metaFileInfoEntity));
            }
        }
        private void FileDownload() //file download <file-name> <destination-path>" - скачивание файла c именем file-name из хранилища в директорию destination-path;
        {
            MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer(MetaFileInfo.FullPath);
            var fileInfo = new FileInfo(MetaFileInfo.FullPath);
            var filesWithoutDownloadedFile = new List<MetaFileInfoEntity>(); 
            var changedDownloadsNumber = new List<MetaFileInfoEntity>();

            using (StreamReader sr = new StreamReader(MetaFileInfo.FullPath))
            {
                var collection = metaFileInfoSerializer.DeserializeFileContent(sr.ReadToEnd());
                filesWithoutDownloadedFile = collection.Where(x => !x.Name.Contains(Command.From)).ToList();
                changedDownloadsNumber = collection.Where(x => x.Name.Contains(Command.From)).ToList();
                changedDownloadsNumber[0].DownloadsNumber++;
            }

            using (StreamWriter sw = new StreamWriter(fileInfo.Open(FileMode.Truncate)))
            {
                var sum = filesWithoutDownloadedFile.Union(changedDownloadsNumber);
                foreach (var file in sum)
                {
                    sw.WriteLine(metaFileInfoSerializer.Serialize(file));
                }
            }
        }
        private void FileMove() //file move <source-file-name> <destination-file-name>" - переименование файла в рамках хранилища: из пути source-file-name в destination-file-name"
        {
            MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer(MetaFileInfo.FullPath);
            var fileInfo = new FileInfo(MetaFileInfo.FullPath);
            var filesWithoutSourceFile = new List<MetaFileInfoEntity>();
            var changedNameFile = new List<MetaFileInfoEntity>();

            using (StreamReader sr = new StreamReader(MetaFileInfo.FullPath))
            {
                var collection = metaFileInfoSerializer.DeserializeFileContent(sr.ReadToEnd());
                filesWithoutSourceFile = collection.Where(x => !x.Name.Contains(Command.From)).ToList();
                changedNameFile = collection.Where(x => x.Name.Contains(Command.From)).ToList();
                changedNameFile[0].Name = Command.To;
            }

            using (StreamWriter sw = new StreamWriter(fileInfo.Open(FileMode.Truncate)))
            {
                var sum = filesWithoutSourceFile.Union(changedNameFile);
                foreach (var file in sum)
                {
                    sw.WriteLine(metaFileInfoSerializer.Serialize(file));
                }
            }
        }
        private void FileRemove() //file remove <file-name>" - удаление файла file-name из хранилища. Пользовательская корзина не предусмотрена, поэтому удаление осуществляется раз и навсегда;
        {
            MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer(MetaFileInfo.FullPath);
            var fileInfo = new FileInfo(MetaFileInfo.FullPath);
            var filesWithoutFileToRemove = new List<MetaFileInfoEntity>();

            using (StreamReader sr = new StreamReader(MetaFileInfo.FullPath))
            {
                var collection = metaFileInfoSerializer.DeserializeFileContent(sr.ReadToEnd());
                filesWithoutFileToRemove = collection.Where(x => !x.Name.Contains(Command.From)).ToList();
            }

            using (StreamWriter sw = new StreamWriter(fileInfo.Open(FileMode.Truncate)))
            {
                foreach (var file in filesWithoutFileToRemove)
                {
                    sw.WriteLine(metaFileInfoSerializer.Serialize(file));
                }
            }
        }
    }
}
