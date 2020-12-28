using FileStorage.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Core.Services
{
    public class DisplayService 
    {
        public static void DisplayMessages(IList<string> messages, bool waitForEntry = false)
        {
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
            if(waitForEntry)  Console.ReadLine();
        }
    }
}
