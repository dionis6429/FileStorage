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
    }
}