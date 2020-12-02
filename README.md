# Diary
Стек:
	Back-end:
		1).Net Framework 4.7.2
		2) ASP.NET MVC 5
		3) Entity Framework 6
		4) Autofac, Autofac.MVC 6 | IoC
		5) Rhino.Moks 3.6.1 | Unit tests
		6) MSTest 2.1.2 | Unit tests
		7)Visual Studio 2019
		8) Microsoft SQL Server  14.0 (2017)
		9) Microsoft SQL Server Managment Studio 18.5 (2020)
	Front-end:
		1)less
		2)JQuery 3.5.1
		3)js-cookie 3 | Для работы с cookie на клиенте
		4)WebCompiler (расширение для Visual Studio) | Для автоматического билда less файлов
	Others:
		1)Github
		2)Jira software 2020 | Для планирования и отслеживания хода работы над проектом
		3)GitHub Desktop
		4)Github for Jira(smart commits) | Для отслеживания изменений в коде проекта на сайте Jira

Особенности развертывания
1) Изменить строку подключения к базе данных в файле Web.comfig 
	1.1)configuration.appSettings["DiaryDbConnection"] - имя выбранной строки подключения
	1.2) configuration.connectionStrings - все доступные строки подключения (выбрать свою)
2) База данных создается и заполняется автоматически в Debug (DiaryDAL.Strategies.InitializationStrategies.DiaryDbDebugInitializer)

3) Сайт нужно развернуть на IIS.
		
Note: При использовании СУБД помимо MS SQL  возможно придется делать дополнительные изменения