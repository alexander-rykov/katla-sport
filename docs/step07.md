# KatlaSport Project

## Шаг 7. HiveSectionsController Deadlock

### Задание

Исправить deadlock в HiveSectionsController.

### Выполнение

1. Создать ветку.
2. GET /api/sections. Запрос не отвечает.
3. GET /api/sections/1. Запрос не отвечает.
4. Перезапустить .NET приложение.
5. Поставить точки останова в HiveSectionsController.GetHiveSections и HiveSectionsController.GetHiveSection.
6. GET /api/sections. Посмотреть значение переменной hives после вызова метода сервиса.
7. GET /api/sections/1. Посмотреть значение переменной hive после вызова метода сервиса.
8. Открыть "Debug\Windows\Threads" и посмотреть значение ID текущего потока до и после вызова метода сервиса.
9. Исправить код методов GetHiveSections и GetHiveSection, чтобы ликвидировать deadlock.
10. Собрать проект, исправить ошибки и предупреждения (если есть).
12. Сохранить изменения как отдельный коммит с понятным описанием "Fix deadlock in HiveSectionsController.".
13. "commit", "push". Влить в "master".

### Проверка

* GET /api/hives возвращает результат.
* GET /api/hives/1 возвращает результат.

### Материалы

Материалы для самостоятельного изучения:
* [Six Essential Tips for Async](https://channel9.msdn.com/Series/Three-Essential-Tips-for-Async)
* [The C# async await Workout](https://channel9.msdn.com/Events/dotnetConf/2017/T316)
* [Effectively use async/await with ASP.NET Web API](https://stackoverflow.com/a/31192718)

Дополнительные материалы:
* [Don't Block on Async Code](https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html)
* [Async and Await](https://blog.stephencleary.com/2012/02/async-and-await.html)
* [Async OOP](https://blog.stephencleary.com/2013/01/async-oop-0-introduction.html)
* [AsyncFixer](https://marketplace.visualstudio.com/items?itemName=SemihOkur.AsyncFixer) - AsyncFixer helps developers in finding and correcting common async/await misuses.
