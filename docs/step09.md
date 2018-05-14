# KatlaSport Project

## Шаг 9. SetStatus

### Задание

Реализовать метод SetStatus в классах HiveService и HiveSectionService. Использовать реализацию метода [ProductCategoryService](../KatlaSport.Services/ProductManagement/ProductCategoryService.cs).SetStatusAsync как образец. Использовать только асинхронные методы ToArrayAsync и SaveChangesAsync при работе с IProductStoreHiveContext.

### Выполнение

1. Создать ветку.
2. Реализовать метод SetStatus в классе [HiveService](../KatlaSport.Services/HiveManagement/HiveService.cs).
3. Реализовать метод SetStatus в классе [HiveSectionService](../KatlaSport.Services/HiveManagement/HiveSectionService.cs).
4. Собрать проект, исправить ошибки. "commit", "push". Влить в "master".

### Проверка

* PUT /api/hives/1/status/true.
* GET /api/hives/1.
* PUT /api/sections/1/status/true.
* GET /api/sections/1.

### Материалы

Материалы для самостоятельного изучения:
* [What Is REST?](http://www.restapitutorial.com/lessons/whatisrest.html)
* [Using HTTP Methods for RESTful Services](http://www.restapitutorial.com/lessons/httpmethods.html)
