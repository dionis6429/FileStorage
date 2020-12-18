using System;
using System.IO;


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
        private void FileUpload()
        {
            MetaFileInfoSerializer metaFileInfoSerializer = new MetaFileInfoSerializer();
            MetaFileInfoEntity metaFileInfo = new MetaFileInfoEntity(Command.From);
                                    
            using (StreamWriter writer = new StreamWriter(MetaFilePath))
            {
                writer.WriteLine(metaFileInfoSerializer.Serialize(metaFileInfo));
            }
        }
        private void FileDownload()
        {

        }

        //private void FileUpload()
        //{
        //    //TODO: handle param1 instead of string.empty

        //    StorageFile sf = new StorageFile(Command.From);
        //    Stream stream = File.Open(MetaFilePath, FileMode.Create);
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    formatter.Serialize(stream, sf);
        //    stream.Close();
        //    //sf = null;
        //    stream = File.Open(MetaFilePath, FileMode.Open);
        //    formatter = new BinaryFormatter();
        //    sf = (StorageFile)formatter.Deserialize(stream);
        //    stream.Close();
        //    Console.WriteLine(sf.ToString());
        //}
        private void FileMove()
        {

        }

    }
}
