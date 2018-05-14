# KatlaSport Project

## Шаг 11. HiveSectionsController+HiveSectionService

### Задание

В контроллере HiveSectionsController и в сервисе HiveSectionService реализовать методы для добавления, редактирования и удаления сущности HiveSection. Все методы должны быть асинхронными.

### Выполнение

1. Создать ветку.
2. Добавить новый класс модели UpdateHiveSectionRequest в каталог [HiveManagement](../KatlaSport.Services.Models/HiveManagement) с полями Name и Code.
3. Добавить новый класс валидатора UpdateHiveSectionRequestValidator в каталог [HiveManagement](../KatlaSport.Services.Models/HiveManagement) по образцу [UpdateHiveRequestValidator](../KatlaSport.Services.Models/HiveManagement/UpdateHiveRequestValidator.cs).
4. Реализовать метод контроллера AddHiveSection (POST /api/sections) и соответствующий метод сервиса CreateHiveSectionAsync.
5. Реализовать метод контроллера UpdateHiveSection (PUT /api/sections/{hiveSectionId}) и соответствующий метод сервиса UpdateHiveSectionAsync.
6. Реализовать метод контроллера DeleteHiveSection (DELETE /api/sections/{hiveSectionId}) и соответствующий метод сервиса DeleteHiveSectionSync.
7. Собрать проект, исправить ошибки. "commit", "push". Влить в "master".

### Проверка

Используйте swagger-консоль для проверки работоспособности новых методов API веб-сервиса.

### Материалы

Дополнительные материалы:
* [FluentValidation in ASP.NET WebAPI](https://medium.com/resdiary-product-team/fluentvalidation-in-asp-net-webapi-edb4d078b296)
