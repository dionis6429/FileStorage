


# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)

 что надо сделать, чтобы запустить ваше приложение:
- аккаунты и пароли к приложению
- какие пути и где необходимо поменять чтобы всё заработало
- аргументы командной строки:
- "--l" (login) - уникальный логин пользователя в системе;
- "--p" (password) - пароль пользователя;
- "user info" - информация о пользователе;
- "file upload <path-to-file>" - загрузка файла, находящегося по пути path-to-file в хранилище;
- "file download <file-name> <destination-path>" - скачивание файла c именем file-name из хранилища в директорию destination-path;
В случае, если указанный файл уже существует, приложение выдаст сообщение об ошибке;
- "file move <source-file-name> <destination-file-name>" - переименование файла в рамках хранилища: из пути source-file-name в destination-file-name";
- "file remove <file-name>" - удаление файла file-name из хранилища. Пользовательская корзина не предусмотрена, поэтому удаление осуществляется раз и навсегда;
- "file info <file-name>" - отображение информации о файле file-name;
---
- "file export <destination-path> --format <format>" - сохранение метаинформации о файлах по заданному пути destination-path в формате format (json или xml).В случае отсуствия поля format по умолчанию используется json;
- "file export --info" - отображение списка поддерживаемых форматов;

