using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException()
        {

        }

        public CommandException(string message) : base(message)
        {

        }

        public CommandException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
