using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Exceptions
{
    public class PathException : Exception
    {
        public PathException()
        {

        }

        public PathException(string message) : base(message)
        {

        }

        public PathException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
