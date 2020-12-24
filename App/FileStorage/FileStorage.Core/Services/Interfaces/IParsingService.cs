using FileStorage.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services.Interfaces
{
    public interface IParsingService
    {
        ContainerForCommand ParseCommand(string input);
    }
}
