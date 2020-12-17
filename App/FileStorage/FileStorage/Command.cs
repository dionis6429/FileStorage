using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage
{
    public class Command
    {
        public Command(FileOperation fileOperation, string from, string to)
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
