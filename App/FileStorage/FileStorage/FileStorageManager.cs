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
                case FileOperation.file_move:
                    FileMove();
                    break;
                default:
                    break;
            }
        }

        private void FileUpload()
        {
            StorageFile sf = new StorageFile(Command.From);
            string path = Command.From;
            string newPath = "c:\\";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
            }

        }
        private void FileMove()
        {

        }

    }
}
