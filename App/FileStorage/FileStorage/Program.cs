using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FileStorage
{
    class Program
    {       
        static void Main(string[] args)
        {
            #region appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var path = config.GetSection("MetaFileInfo").Get<MetaFileInfo>().Path;
            #endregion

            #region Authentication

            //bool isAuthenticated = false;

            //while (true && !isAuthenticated)
            //{
            //    Console.WriteLine("Введите логин: ");
            //    var login = Console.ReadLine();

            //    Console.WriteLine("Введите пароль: ");
            //    var password = Console.ReadLine();

            //    if (Authenticator.Authenticate(login, password))
            //    {
            //        isAuthenticated = true;
            //        Console.WriteLine("Регистрация прошла успешно");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Неверный логин или пароль. Повторите попытку.");
            //    }
            //}
            #endregion

            #region Create Meta Storage File
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            #endregion      

            var commandManager = new CommandsManager();
            commandManager.ShowCommands();
            string input = Console.ReadLine();
            var command = commandManager.ParseCommand(input);

            //if (command != null && command.FileOperation == FileOperation.user_info)
            //{
                
            //}
            //else
            //{
            //    Console.WriteLine("Wrong command. Press 'Enter' to quit");
            //    Console.Read();
            //}

            var metaFileStorageManager = new MetaFileStorageManager(command, path);
            metaFileStorageManager.RunCommand();

            var fileStorageManager = new FileStorageManager(command);
            fileStorageManager.RunCommand();


            // END
        }
    }
}
