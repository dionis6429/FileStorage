using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage
{
    public class FileStorageManager
    {
        public FileStorageManager(Command command)
        {
            Command = command;
        }
        public Command Command { get; set; }

        public void RunCommand()
        {

        }
    }
}
