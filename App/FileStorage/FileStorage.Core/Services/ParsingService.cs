using FileStorage.Core.Models;
using FileStorage.Core.Services.Interfaces;
using System;
using System.IO;

namespace FileStorage.Core.Services
{
    public class ParsingService : IParsingService
    {        
        public ContainerForCommand ParseCommand(string input)
        {
            var vs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var textCommand = vs[0];
            var fromPath = vs.Length > 1 ? vs[1] : string.Empty;
            var toPath = vs.Length > 2 ? vs[2] : string.Empty;
            ContainerForCommand command = null;
            if (Enum.TryParse(textCommand, out FileOperation fileOperation))
            {
                command = new ContainerForCommand(fileOperation, fromPath, toPath);
            }
            return command;
        }
    }
}