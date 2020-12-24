using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services.Interfaces
{
    public  interface IDisplayService
    {
        void DisplayMessages(IList<string> messages);
    }
}
