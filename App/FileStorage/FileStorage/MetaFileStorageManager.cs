using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage
{
    public class MetaFileStorageManager
    {
        public MetaFileStorageManager(Command command)
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
            //TODO: handle param1 instead of string.empty
            StorageFile sf = new StorageFile(Path.GetFileName(string.Empty));
            Stream stream = File.Open("FileStorage.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, sf);
            stream.Close();
            sf = null;
            stream = File.Open("FileStorage.dat", FileMode.Open);
            formatter = new BinaryFormatter();
            sf = (StorageFile)formatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine(sf.ToString());
        }
    }
}
