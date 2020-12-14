using System;
using System.IO;
using System.Reflection;

namespace FileStorage
{   
    class Program
    {
        static void Main(string[] args)
        {

            #region Authentication
            do
            {
                Console.WriteLine("Введите логин: ");
                var login = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                var password = Console.ReadLine();
                switch (Authenticator.Authenticate(login, password))
                {
                    case false:
                        Console.WriteLine("Неверный логин или пароль. Повторите попытку.");
                        Console.WriteLine();
                        break;
                    case true:
                        Console.WriteLine("Регистрация прошла успешно");
                        Console.WriteLine();
                        break;
                }
            }
            while
            (true);
            #endregion


            //string path = @"c:\Users\s.taras\source\repos\FileStorage\App\FileStorage\FileStorage\StorageFile.txt";

            //FileInfo fileInf = new FileInfo(path);
            //if (fileInf.Exists)
            //{
            //    Console.WriteLine($"Файл {fileInf.Name}, представляющий хранилище, обнаружен");
            //}
            //else
            //{
            //    Console.WriteLine($"Файл {fileInf.Name}, представляющий хранилище, по указанному пути отсутствует");
            //}
           

            //Type type = Type.GetType("FileStorage.StorageFile");
            //var members = type.GetMembers();
            //foreach (MemberInfo memberInfo in members)
            //{
            //    Console.WriteLine(memberInfo.Name);               
            //}



            //StorageFile storageFile = new StorageFile("firstfile", "exe");
            //using (var sw = new StreamWriter(path, true))
            //{
            //    sw.Write(storageFile.Name + " ");
            //    sw.Write(storageFile.Extension + " ");
            //    sw.Write(storageFile.Size + " ");
            //    sw.Write(storageFile.CreationData + " ");
            //    sw.WriteLine(storageFile.DownloadsNunber);
            //}



            //using (var sr = new StreamReader(@"c:\Users\s.taras\source\repos\FileStorage\App\FileStorage\FileStorage\StorageFile.txt"))
            //{
            //    var text = sr.ReadToEnd();
            //    Console.WriteLine(text);
            //}

        }
    }
}
