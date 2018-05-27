# KatlaSport Project

## Шаг 5. Async HiveService+HivesController

### Задание

Заменить методы классов Классы HiveService и HivesController, которые написаны в синхронном стиле, на асинхронные версии с применением модификатора async и оператора await.

### Выполнение

1. "step5".

2. Исправить [IHiveService](../KatlaSport.Services.Models/HiveManagement/IHiveService.cs), чтобы методы соответствовали [TAP](https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap).

  * Обернуть возвращаемые типы методов в Task<>. В случае, если метод возвращает void, заменить void на Task.
  * Добавить Task в комментарий <return> или добавить комментарий <return>, если его не было.
  * Добавить Async после имени метода.

Было:

```cs
/// <summary>
/// Gets something.
/// </summary>
/// <returns>A <see cref="Something"/>.</returns>
Something GetSomething();

/// <summary>
/// Does something.
/// </summary>
void DoSomething();
```

Стало:

```cs
/// <summary>
/// Gets something.
/// </summary>
/// <returns>A <see cref="Task{Something}"/>.</returns>
Task<Something> GetSomethingAsync();

/// <summary>
/// Does something.
/// </summary>
/// <returns>A <see cref="Task"/>.</returns>
Task DoSomethingAsync();
```

3. Изменить методы сервиса [HiveService](../KatlaSport.Services/HiveManagement/HiveService.cs), чтобы они стали асинхронными.

  * Исправить сигнатуры методов, чтобы они соответствовали сигнатурам методов в интерфейсе IHiveService.
  * Применить к сигнатурам методов модификатор [async](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/async).
  * Заменить синхронный вызов метода ToArray на асинхронный ToArrayAsync.
  * Заменить синхронный вызов метода SaveChanges на асинхронный SaveChangesAsync.
  * Добавить к вызовам ToArrayAsync и SaveChangesAsync оператор [await](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/await).

Пример:

```cs
public async Task<Something> GetSomethingAsync()
{
	var list = await _context.EntitySet.ToArrayAsync();
	return list.FirstOrDefault();
}
```

4. Исправить [HivesController](../KatlaSport.WebApi/Controllers/HivesController.cs).

  * Исправить сигнатуры синхронных методов - применить async и обернуть IHttpActionResult в Task<T>.
  * Добавить к вызовам асинхронных методов сервиса оператор await.

5. Удалить из интерфейса [IAsyncEntityStorage](../KatlaSport.DataAccess/IAsyncEntityStorage.cs) метод SaveChanges.
6. Удалить из класса [DomainContextBase](../KatlaSport.DataAccess/DomainContextBase.cs) метод SaveChanges.
7. Собрать проект, исправить ошибки и предупреждения (если есть).
8. Сохранить изменения как отдельный коммит с понятным описанием "Replace sync. method calls in HivesController and HiveService with async.".
9. "step5" -> "master".

### Проверка

1. GET /api/hives возвращает результат.
2. GET /api/hives/1 возвращает результат.
3. Поставить точку останова в HivesController.GetHives на строке с вызовом \_hiveService.GetHives();
4. GET /api/hives.
5. Debug\Windows\Threads (Alt D W H).
6. Записать ID и Managed ID текущего потока.
7. F10.
8. Debug\Windows\Threads.
9. Сравнить ID и Managed ID текущего потока с записанными значениями.

### Материалы

Материалы для самостоятельного изучения:
* [Task-based Asynchronous Pattern](https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap)
* [Анатомия веб-сервиса](https://habr.com/company/oleg-bunin/blog/309324/)
* [Effectively use async/await with ASP.NET Web API](https://stackoverflow.com/a/31192718)

Дополнительные материалы:
* [Top 5 ways to debug async/await and multi-threaded code in Visual Studio](https://blog.oz-code.com/debugging-multi-threaded-code-using-visual-studio-ozcode/)
