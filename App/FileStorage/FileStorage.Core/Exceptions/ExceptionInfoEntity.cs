using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Exceptions
{
    public class ExceptionInfoEntity : Exception
    {
        public Guid Id { get; set; }
        public ExceptionInfoEntity() : base ()
        {
            Id = Guid.NewGuid();
        }
    }
}
