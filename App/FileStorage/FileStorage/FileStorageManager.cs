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
                default:
                    break;
            }
        }

        private void FileUpload()
        {
            MetaFileInfoEntity metaFileInfoEntity = new MetaFileInfoEntity(Command.From);
            string path = Command.From;
            string newPath = $"c:\\Users\\s.taras\\source\\repos\\FileStorage\\App\\FileStorage\\FileStorage\\{metaFileInfoEntity.Name}";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
            }
        }

        private void FileDownload()
        {

        }
            


        
        private void FileMove()
        {

        }

    }
}
