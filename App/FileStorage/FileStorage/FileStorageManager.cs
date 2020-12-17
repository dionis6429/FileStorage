using System;
using System.Collections.Generic;
using System.Text;

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
                case FileOperation.file_download:
                    FileDownload();
                    break;
                case FileOperation.file_move:
                    FileDownload();
                    break;
                default:
                    break;
            }
        }

        private void FileDownload()
        {

        }

    }
}
