using System;
using System.IO;

namespace FileStorage
{
    public class CommandsManager
    {        
        public void ShowCommands()
        {
            Console.WriteLine($"Введите команду из списка:");
            Console.WriteLine("user_info");
            Console.WriteLine("file_upload <path to file>");
            Console.WriteLine("file_download <file name> <destination path>");
            Console.WriteLine("file_move <source file name> <destination file name>");
            Console.WriteLine("file_remove <file name>");
            Console.WriteLine("file_info <file name>");
            Console.WriteLine();
        }

        public Command ParseCommand(string input)
        {
            var vs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var textCommand = vs[0];
            var fromPath = vs.Length > 1 ? vs[1] : string.Empty;
            var toPath = vs.Length > 2 ? vs[2] : string.Empty;
            Command command = null;
            if (Enum.TryParse(textCommand, out FileOperation fileOperation))
            {
                command = new Command(fileOperation, fromPath, toPath);
            }
            return command;
        }


        public  void Manager(string input)
        {
            string[] vs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string param1 = vs[1];

            FileInfo fi = new FileInfo(param1);
            long size = fi.Length;

            switch (vs.Length)
            {
                case 1:
                    {
                        switch (vs[0])
                        {
                            case "user_info":
                                //TODO: реализовать отображение информации о пользователе (логин, общий объём хранимых данных), вставить метаинфо для вывода на консоль
                                Console.WriteLine($"Login: {Authenticator.Login}");
                                Console.WriteLine($"Password: {Authenticator.Password}");
                                //Console.WriteLine($"Storage used: {} Mb");
                                break;
                        }
                    }
                    break;

                case 2:
                    {

                        switch (vs[0])
                        {

                            case "file_remove":
                                //TODO: реализовать удаление файла file-name из хранилища. Пользовательская корзина не предусмотрена, поэтому удаление осуществляется раз и навсегда.


                                Console.WriteLine($"The file {param1} has been removed");
                                break;

                            case "file_info":


                                Console.WriteLine($"Name: {param1}");
                                Console.WriteLine($"Extension: {Path.GetExtension(param1)}");
                                Console.WriteLine($"File size: {size} Gb");
                                Console.WriteLine("Creation date: " + File.GetCreationTime(param1).ToString());
                                Console.WriteLine($"Login: {Authenticator.Login}");
                                break;

                            case "file_upload":
                                //TODO: реализовать загрузку файла


                                Console.WriteLine($"The file {param1} has been uploaded");
                                Console.WriteLine($"File name: {Path.GetFileName(param1)}");
                                Console.WriteLine($"File size: {size} Gb");
                                Console.WriteLine($"Extension: {Path.GetExtension(param1)}");
                                break;
                        }
                    }
                    break;

                case 3:
                    {
                        string param2 = vs[2];
                        switch (vs[0])
                        {
                            case "file_download":
                                //    //TODO: реализовать скачивание файла с именем file-name из хранилища в директорию destination-path. Если файл уже существует, то выдавать сообщение об ошибке, вытащить имя файла для вывода на консль
                                //    Console.WriteLine($"The file {Param1} has been downloaded");
                                break;

                            case "file_move":
                                //    //TODO: реализовать переименование файла в рамках хранилища - из пути source-file-name в destination-file-name, вытащить метаинфо для вывода на консоль
                                //    Console.WriteLine($"The file {Param1} has been moved to {Param2}");
                                break;
                        }
                    }
                    break;

                default:
                    {
                        Console.WriteLine("Неправильная команда");
                    }
                    break;
            }
        }
    }
}