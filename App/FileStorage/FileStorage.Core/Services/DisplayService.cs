using FileStorage.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services
{
    public class DisplayService : IDisplayService
    {
        public void DisplayMessages(IList<string> messages)
        {
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
            Console.ReadLine();
        }
    }
}
