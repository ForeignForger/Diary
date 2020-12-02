# Diary
**Стек**
* Сервер:
  * .Net Framework 4.7.2
  * ASP.NET MVC 5
  * Entity Framework 6
  * Autofac, Autofac.MVC 6 | IoC
  * Rhino.Moks 3.6.1 | Unit tests
  * MSTest 2.1.2 | Unit tests
  * Visual Studio 2019
  * Microsoft SQL Server  14.0 (2017)
  * Microsoft SQL Server Managment Studio 18.5 (2020)
* Клиент:
  * less
  * JQuery 3.5.1
  * js-cookie 3 | Для работы с cookie на клиенте
  * WebCompiler (расширение для Visual Studio) | Для автоматического билда less файлов
* Другие:
  * Github
  * Jira software 2020 | Для планирования и отслеживания хода работы над проектом
  * GitHub Desktop
  * Github for Jira(smart commits) | Для отслеживания изменений в коде проекта на сайте Jira
   
**Особенности развертывания**:
  * Изменить строку подключения к базе данных в файле Web.comfig 
    * configuration.connectionStrings - все доступные строки подключения (добавить свою)
    * configuration.appSettings["DiaryDbConnection"] - имя выбранной строки подключения (выбрать свою)
  * База данных создается и заполняется автоматически в Debug (DiaryDAL.Strategies.InitializationStrategies.DiaryDbDebugInitializer)
  * Сайт нужно развернуть на IIS.
  
**Note**: При использовании СУБД помимо MS SQL  возможно придется делать дополнительные изменения
