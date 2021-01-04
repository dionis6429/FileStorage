using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException(string message) : base(message)
        {

        }
    }
}
