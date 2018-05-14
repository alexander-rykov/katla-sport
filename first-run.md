# KatlaSport Project

## Первый запуск

### Создание базы данных

1. Открыть оснастку "Сервисы" и [проверить состояние сервиса БД](https://www.youtube.com/watch?v=SFJq7V8mrWA). Start the service if it is off.
2. Запустить Visual Studio.
3. Открыть "SQL Server Object Explorer".
4. Открыть вкладку Local.
5. Выбрать сервер "MACHINENAME\SQLExpress", где MACHINENAME - имя рабочей станции.
6. Добавить новую базу данных с именем "KatlaDB".

### Сборка проекта

1. Откройте [KatlaSport.sln](KatlaSport.sln) в Visual Studio. Приложение состоит из нескольких проектов:
2. Откройте Solution Explorer.
3. Установите *KatlaSport.WebApi* как ["Startup Project"](https://msdn.microsoft.com/en-us/library/a1awth7y.aspx)
5. Открыть Solution Explorer. Открыть меню для Solution 'KatlaSport'. Restore NuGet packages.
6. Открыть Solution Explorer. Открыть меню для Solution 'KatlaSport'. Build solution.
