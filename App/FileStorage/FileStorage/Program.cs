﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Extensions.Configuration;

namespace FileStorage
{
    class Program
    {       
        static void Main(string[] args)
        {
            #region appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var path = config.GetSection("MetaFileInfo").Get<MetaFileInfo>().Path;
            #endregion

            #region Authentication

            //bool isAuthenticated = false;

            //while (true && !isAuthenticated)
            //{
            //    Console.WriteLine("Введите логин: ");
            //    var login = Console.ReadLine();

            //    Console.WriteLine("Введите пароль: ");
            //    var password = Console.ReadLine();

            //    if (Authenticator.Authenticate(login, password))
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

            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine($"Файл {fileInf.Name}, представляющий хранилище, обнаружен");
            }
            else
            {
                Console.WriteLine($"Файл {fileInf.Name}, представляющий хранилище, по указанному пути отсутствует");
            }

            do
            {
                var commandManager = new CommandsManager();
                commandManager.ShowCommands();
                string input = Console.ReadLine();
                var command = commandManager.ParseCommand(input);
            }
            while (true);

            //CommandsManager cm = new CommandsManager();

            //TODO: handle param1 instead of string.empty
            StorageFile sf = new StorageFile(Path.GetFileName(string.Empty));
            Stream stream = File.Open("FileStorage.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, sf);
            stream.Close();
            sf = null;
            stream = File.Open("FileStorage.dat", FileMode.Open);
            formatter = new BinaryFormatter();
            sf = (StorageFile)formatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine(sf.ToString());



            #region Serialization
            ////объект для сериализации
            //StorageFile storageFile = new StorageFile();
            //Console.WriteLine("Объект создан");

            ////создаем объект бинари форматтер
            //BinaryFormatter formatter = new BinaryFormatter();

            //// получаем поток, куда будем записывать сериализованный поток
            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, storageFile);
            //    Console.WriteLine("Объект сериализован");
            //}

            ////десириализация из файла Meta.txt
            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    StorageFile newStorageFile = (StorageFile)formatter.Deserialize(fs);
            //    Console.WriteLine("Объект десериализован");

            //}
            #endregion
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
