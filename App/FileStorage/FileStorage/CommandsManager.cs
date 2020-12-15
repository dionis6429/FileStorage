using System;

namespace FileStorage
{
    public class CommandsManager
    {
        public string Command { get; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }

        public enum FileOperation : byte
        {
            Upload,
            Download,
            Move,
            Remove,
            Info
        }
        public CommandsManager(string command, string param1)
        {
            Command = command;
            Param1 = param1;
        }
        public CommandsManager(string command, string param1, string param2)
        {
            Command = command;
            Param1 = param1;
            Param2 = param2;
        }
        public static void Manager(FileOperation fileOperation, string Param1, string Param2)
        {
            switch (fileOperation)
            {
                case FileOperation.Upload:

                    //TODO: реализовать загрузку файла, вставить метаинфо для вывода на консоль
                    Console.WriteLine($"The file {Param1} has been uploaded");
                    Console.WriteLine($"File name: {}");
                    Console.WriteLine($"File size: {} Gb");
                    Console.WriteLine($"Extension: {}");
                    break;

                case FileOperation.Download:
                    //TODO: реализовать скачивание файла с именем file-name из хранилища в директорию destination-path. Если файл уже существует, то выдавать сообщение об ошибке, вытащить имя файла для вывода на консль
                    Console.WriteLine($"The file {Param1} has been downloaded");
                    break;

                case FileOperation.Move:
                    //TODO: реализовать переименование файла в рамках хранилища - из пути source-file-name в destination-file-name, вытащить метаинфо для вывода на консоль
                    Console.WriteLine($"The file {Param1} has been moved to {Param2}");
                    break;

                case FileOperation.Remove:
                    //TODO: реализовать удаление файла file-name из хранилища. Пользовательская корзина не предусмотрена, поэтому удаление осуществляется раз и навсегда. Вытащить имя файла для вывода на консоль
                    Console.WriteLine($"The file {Param1} has been removed");
                    break;

                case FileOperation.Info:
                    //TODO: реализовать  отображение информации о файле file-name. Должна быть отображена следующая информация - имя, расширение, размер, дата загрузки, логин пользователя в системе и т.д., вставить метаинфо для вывода на консоль
                    Console.WriteLine($"Name: {Param1}");
                    Console.WriteLine($"Extension: {}");
                    Console.WriteLine($"File size: {} Gb");
                    Console.WriteLine($"Creation date: {}");
                    Console.WriteLine($"Login: {}");
                    break;
            }
        }
    }
}
