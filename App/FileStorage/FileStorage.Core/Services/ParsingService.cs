using FileStorage.Core.Exceptions;
using FileStorage.Core.Models;
using FileStorage.Core.Services.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace FileStorage.Core.Services
{
    public class ParsingService : IParsingService
    {        
        public ContainerForCommand ParseCommand(string input)
        {
            ContainerForCommand command = null;
            try
            {
                var vs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (!vs.Any()) throw new ParsingException("Parsed string does not contain elements");

                var textCommand = vs[0];
                var fromPath = vs.Length > 1 ? vs[1] : string.Empty;
                var toPath = vs.Length > 2 ? vs[2] : string.Empty;

                if (Enum.TryParse(textCommand, out FileOperation fileOperation))
                {
                    command = new ContainerForCommand(fileOperation, fromPath, toPath);
                }

                if(command is null)  throw new CommandException("The command is wrong");

            }
            catch (Exception ex)
            {
                Console.WriteLine("some text of exception");
                //Log ex
            }

            return command;
        }
    }
}