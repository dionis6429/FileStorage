using System;
using System.Collections.Generic;
using System.IO;
using FileStorage.Core.Models;
using FileStorage.Core.Services;
using FileStorage.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FileStorage.UI
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region Authentication

            //bool isAuthenticated = false;

            //while (true && !isAuthenticated)
            //{
            //    Console.WriteLine("Введите логин: ");
            //    var login = Console.ReadLine();

            //    Console.WriteLine("Введите пароль: ");
            //    var password = Console.ReadLine();

            //    if (new AuthenticationService().Authenticate(login, password))
            //    {
            //        isAuthenticated = true;
            //        Console.WriteLine("Регистрация прошла успешно");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Неверный логин или пароль. Повторите попытку.");
            //    }
            //}
            #endregion

            string input = Console.ReadLine();
            var entryPoint = new EntryPoint(input);
            entryPoint.Execute();
        }
    }
}
