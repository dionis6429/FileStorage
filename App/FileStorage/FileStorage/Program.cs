using System;
using System.Collections.Generic;
using System.IO;
using FileStorage.Core.Models;
using FileStorage.Core.Services;
using FileStorage.Core.Services.Interfaces;
using FileStorage.Core.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileStorage.UI
{
    public class Program
    {
        public
        static void Main(string[] args)
        {
            var provider = RegisterServicesAndGetServiceProvider();


            var _authenticationService = provider.GetService<IAuthenticationService>();
            var _parsingService = provider.GetService<IParsingService>();
            var _metaFileInfoSerializerService = provider.GetService<IMetaFileInfoSerializerService>();

            var config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                  .AddJsonFile("appsettings.json", false)
                  .Build();

            var metaFileInfoSettings = config.GetSection("MetaFileInfoSettings").Get<MetaFileInfoSettings>();

            #region Authentication

            bool isAuthenticated = false;

            while (true && !isAuthenticated)
            {
                Console.WriteLine("Введите логин: ");
                var login = Console.ReadLine();

                Console.WriteLine("Введите пароль: ");
                var password = Console.ReadLine();
                if (_authenticationService.Authenticate(login, password))
                {
                    isAuthenticated = true;
                    Console.WriteLine("Регистрация прошла успешно");
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль. Повторите попытку.");
                }
            }
            #endregion

            #region Create Meta File
            if (!File.Exists(metaFileInfoSettings.FullPath))
            {
                File.Create(metaFileInfoSettings.FullPath);
            }
            #endregion

            #region Show Menu  
            var messages = new List<string>()
            {
            $"Введите команду из списка:",
            "user_info",
            "file_upload <path to file>",
            "file_download <file name> <destination path>",
            "file_move <source file name> <destination file name>",
            "file_remove <file name>",
            "file_info <file name>",
            "file_find <file name>"
            };
            DisplayService.DisplayMessages(messages);

            #endregion

            string input = Console.ReadLine();
            var containerForCommand = _parsingService.ParseCommand(input);

            var storageServices = new List<BaseStorageService>()
            {
                new FileStorageService(containerForCommand, metaFileInfoSettings),
                new MetaFileStorageService(containerForCommand, metaFileInfoSettings, _metaFileInfoSerializerService, _authenticationService)
            };

            foreach (var service in storageServices)
            {
                switch (containerForCommand.FileOperation)
                {
                    case FileOperation.file_upload:
                        service.FileUpload();
                        break;

                    case FileOperation.file_download:
                        service.FileDownload();
                        break;

                    case FileOperation.file_move:
                        service.FileMove();
                        break;

                    case FileOperation.file_remove:
                        service.FileRemove();
                        break;

                    case FileOperation.file_info:
                        service.FileInfo();
                        break;

                    case FileOperation.file_find:
                        service.FileFind();
                        break;

                    case FileOperation.user_info:
                        service.UserInfo();
                        break;

                    default:
                        break;
                }
            }

        }

        private static ServiceProvider RegisterServicesAndGetServiceProvider()
        {
            return new ServiceCollection()
                                    .AddScoped<IAuthenticationService, AuthenticationService>()
                                    .AddScoped<IMetaFileInfoSerializerService, MetaFileInfoSerializerService>()
                                    .AddScoped<IParsingService, ParsingService>()
                                    .BuildServiceProvider();
        }
    }
}
