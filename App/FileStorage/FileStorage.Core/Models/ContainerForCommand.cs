using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Models
{
    public class ContainerForCommand
    {
        public ContainerForCommand(FileOperation fileOperation, string from, string to)
        {
            FileOperation = fileOperation;
            From = from;
            To = to;
        }
        public FileOperation FileOperation { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }
}
