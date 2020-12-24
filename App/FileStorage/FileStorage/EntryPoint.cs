using FileStorage.Core.Models;
using FileStorage.Core.Services;
using FileStorage.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileStorage.UI
{
    public class EntryPoint
    {
        private readonly string _consoleCommand;
        private readonly IParsingService _parsingService;
        private readonly IDisplayService _displayService;
        private readonly IMetaFileInfoSerializerService _metaFileInfoSerializerService;
        public EntryPoint(string consoleCommand)
        {
            _consoleCommand = consoleCommand;
            _parsingService =  new ParsingService();
            _displayService = new DisplayService();
            _metaFileInfoSerializerService = new MetaFileInfoSerializerService();
        }
        public void Execute()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var metaFileInfoSettings = config.GetSection("MetaFileInfoSettings").Get<MetaFileInfoSettings>();

            if (!File.Exists(metaFileInfoSettings.FullPath))
            {
                File.Create(metaFileInfoSettings.FullPath);
            }

            var messages = new List<string>()
            {
            $"Введите команду из списка:",
            "user_info",
            "file_upload <path to file>",
            "file_download <file name> <destination path>",
            "file_move <source file name> <destination file name>",
            "file_remove <file name>",
            "file_info <file name>"
            };

            _displayService.DisplayMessages(messages);

            var containerForCommand = _parsingService.ParseCommand(_consoleCommand);

            var storageServices = new List<BaseStorageService>()
            {
                new MetaFileStorageService(containerForCommand, metaFileInfoSettings, _metaFileInfoSerializerService),
                new FileStorageService(containerForCommand, metaFileInfoSettings),
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
                    default:
                        break;
                }
            }

        }
    }
}
