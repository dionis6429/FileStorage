using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


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
            //TODO: handle param1 instead of string.empty
            
            StorageFile sf = new StorageFile(Command.From);
            Stream stream = File.Open("c:\\Users\\s.taras\\source\\repos\\FileStorage\\App\\FileStorage\\FileStorage\\Meta.txt", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, sf);
            stream.Close();
            //sf = null;
            stream = File.Open("c:\\Users\\s.taras\\source\\repos\\FileStorage\\App\\FileStorage\\FileStorage\\Meta.txt", FileMode.Open);
            formatter = new BinaryFormatter();
            sf = (StorageFile)formatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine(sf.ToString());
        }
        private void FileMove()
        {

        }

    }
}
