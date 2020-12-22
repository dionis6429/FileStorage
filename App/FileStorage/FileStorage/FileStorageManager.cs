using System;
using System.IO;


namespace FileStorage
{
    public class FileStorageManager
    {
        public FileStorageManager(Command command)
        {
            Command = command;
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
                    FileInfo();
                    break;

                default:
                    break;
            }
        }
        private void FileUpload() //file upload <path-to-file>" - загрузка файла, находящегося по пути path-to-file в хранилище;
        {
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);
            string path = Command.From;
            string newPath = $"c:\\Users\\s.taras\\source\\repos\\FileStorage\\App\\FileStorage\\FileStorage\\{metaFileInfoEntity.Name}";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                Console.WriteLine($"File {metaFileInfoEntity.Name} is uploaded");
            }
        }
        private void FileDownload() //file download <file-name> <destination-path>" - скачивание файла c именем file-name из хранилища в директорию destination-path;
        {
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);
            string path = $"c:\\Users\\s.taras\\source\\repos\\FileStorage\\App\\FileStorage\\FileStorage\\{metaFileInfoEntity.Name}";
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
            string path = $"c:\\Users\\s.taras\\source\\repos\\FileStorage\\App\\FileStorage\\FileStorage\\{metaFileInfoEntity.Name}";
            metaFileInfoEntity.Name = Command.To;
            string newPath = $"c:\\Users\\s.taras\\source\\repos\\FileStorage\\App\\FileStorage\\FileStorage\\{metaFileInfoEntity.Name}";
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
            string path = $"c:\\Users\\s.taras\\source\\repos\\FileStorage\\App\\FileStorage\\FileStorage\\{metaFileInfoEntity.Name}";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                Console.WriteLine("File is removed");
            }
        }
        private void FileInfo() //file info <file-name>" - отображение информации о файле file-name
        {
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);
            string path = $"c:\\Users\\s.taras\\source\\repos\\FileStorage\\App\\FileStorage\\FileStorage\\{metaFileInfoEntity.Name}";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("File name: {0}", fileInf.Name);
                Console.WriteLine("File extension: {0}", fileInf.Extension);
                Console.WriteLine("Creation date: {0}", fileInf.CreationTime);
                Console.WriteLine($"File size: {fileInf.Length} bites");
                Console.WriteLine($"Downloads number: {metaFileInfoEntity.DownloadsNumber}");
            }
        }
    }
}
