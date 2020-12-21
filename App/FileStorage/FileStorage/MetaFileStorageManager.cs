using System;
using System.IO;
using System.Linq;


namespace FileStorage
{
    public class MetaFileStorageManager
    {
        public Command Command { get; set; }
        public string MetaFilePath { get; set; }
        public MetaFileStorageManager(Command command, string metaFilePath)
        {
            Command = command;
            MetaFilePath = metaFilePath;
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

                default:
                    break;
            }
        }

        private void UserInfo()
        {
            Console.WriteLine($"Login: {Authenticator.Login}");
            Console.WriteLine($"Creation Date: {File.GetLastWriteTime(Authenticator.Login)}");
            Console.WriteLine($"Storage Used: {File.GetCreationTime(Authenticator.Login)}");
        }
        private void FileUpload() //file upload <path-to-file>" - загрузка файла, находящегося по пути path-to-file в хранилище;
        {
            MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer();
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);

            using (StreamWriter sw = new StreamWriter(MetaFilePath, true))
            {
                sw.WriteLine(metaFileInfoSerializer.Serialize(metaFileInfoEntity));
            }
        }
        private void FileDownload() //file download <file-name> <destination-path>" - скачивание файла c именем file-name из хранилища в директорию destination-path;
        {
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(MetaFilePath);
            MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer();

            using (StreamReader sr = new StreamReader(MetaFilePath))
            {
                metaFileInfoSerializer.DeserializeFileContent(sr.ReadToEnd());

            }
        }
        private void FileMove() //file move <source-file-name> <destination-file-name>" - переименование файла в рамках хранилища: из пути source-file-name в destination-file-name"
        {
            //в стриме найти имя и заменить его
        }
        private void FileRemove() //file remove <file-name>" - удаление файла file-name из хранилища. Пользовательская корзина не предусмотрена, поэтому удаление осуществляется раз и навсегда;
        {
            MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer();

            using (StreamReader sr = new StreamReader(MetaFilePath))
            {
                var collection = metaFileInfoSerializer.DeserializeFileContent(sr.ReadToEnd());
                var filesWithoutFileToRemove = collection.Where(x => !x.Name.Contains(Command.From));
                File.WriteAllText(MetaFilePath, string.Empty);
                using (StreamWriter sw = new StreamWriter(MetaFilePath, true))
                {
                    foreach (var file in filesWithoutFileToRemove)
                    {
                        sw.WriteLine(metaFileInfoSerializer.Serialize(file));
                    }
                }
            }
        }

    }
}
