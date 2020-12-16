using System;
using System.IO;

namespace FileStorage
{
    public class CommandsManager
    {
        //public string Command { get; }
        //public string Param1 { get; set; }
        //public string Param2 { get; set; }

        //public enum FileOperation : byte
        //{
        //    user_info,
        //    file_upload,
        //    file_download,
        //    file_move,
        //    file_remove,
        //    file_info
        //}
        //public CommandsManager()
        //{

        //}
        //public CommandsManager(string command, string param1)
        //{
        //    Command = command;
        //    Param1 = param1;
        //}
        //public CommandsManager(string command, string param1, string param2)
        //{
        //    Command = command;
        //    Param1 = param1;
        //    Param2 = param2;
        //}
        //public static void Manager(FileOperation fileOperation, string Param1, string Param2)


        public static void Manager(string input)
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