# KatlaSport Project

## Шаг 11. HiveController

### Задание

В контроллере HivesController реализовать методы для добавления, редактирования и удаления сущности Hive. Все методы должны быть асинхронными и вызывать соответствующие методы сервиса через интерфейс IHiveService. Используйте существующие контроллеры ProductsController и ProductCategoriesController в качестве образца.

### Выполнение

1. Создать ветку.
2. Реализовать метод AddHive:

* Метод запроса HTTP и URL: POST /api/hives.
* Метод должен принимать JSON в теле запроса со следующей структурой (используйте класс UpdateHiveRequest):

```
{
	"name": "string",
	"code": "string",
	"address": "string"
}
```

* Задокументируйте коды ответа HTTP: Created, BadRequest, Conflict, InternalServerError.
* Метод должен проверять поля модели на валидность.
* Метод должен возвращать header "Location" с указанием на URI созданного ресурса.

3. Реализовать метод UpdateHive:

* Метод запроса HTTP и URL: PUT /api/hives/{hiveId}.
* Метод должен принимать JSON в теле запроса со следующей структурой:

```
{
	"name": "string",
	"code": "string",
	"address": "string"
}
```

* Задокументируйте коды ответа HTTP: NoContent, BadRequest, Conflict, NotFound, InternalServerError.
* Метод должен проверять поля модели на валидность.

4. Реализовать метод DeleteHive:

* Метод запроса HTTP и URL: DELETE /api/hives/{hiveId}.
* Задокументируйте коды ответа HTTP: NoContent, BadRequest, Conflict, NotFound, InternalServerError.
* Метод должен проверять hiveId >= 1.

5. Добавить в HiveManagementMappingProfile новый маппинг:

```cs
CreateMap<UpdateHiveRequest, DataAccessHive>()
    .ForMember(r => r.LastUpdated, opt => opt.MapFrom(p => DateTime.UtcNow));
```

5. Собрать проект, исправить ошибки. "commit", "push". Влить в "master".

### Проверка

Используйте swagger-консоль для проверки работоспособности новых методов API веб-сервиса.

### Материалы

Материалы для самостоятельного изучения:
* [POST HTTP](https://ru.wikipedia.org/wiki/POST_(HTTP))
* [PUT HTTP](https://ru.wikipedia.org/wiki/HTTP#PUT)
* [HTTP Status Codes](http://www.restapitutorial.com/httpstatuscodes.html)

Дополнительные материалы:
* [Коды ответа HTTP](https://developer.mozilla.org/ru/docs/Web/HTTP/Status)
* [RESTful API Server – Doing it the right way (Part 1)](http://blog.mugunthkumar.com/articles/restful-api-server-doing-it-the-right-way-part-1/)
* [RESTful API для сервера – делаем правильно (Часть 1)](https://habr.com/post/144011/)
* [API design](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design)
* [10 Best Practices for Better RESTful API](https://blog.mwaysolutions.com/2014/06/05/10-best-practices-for-better-restful-api/)
* [Best Practices for Designing a Pragmatic RESTful API](https://www.vinaysahni.com/best-practices-for-a-pragmatic-restful-api)
* [CORS](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api#enable-cors)
* [IHttpActionResult](https://github.com/aspnet/Mvc/issues/5507)
