# KatlaSport Project

## Шаг 3. ProductCount

### Задание

Расширить модель ProductCategoryListItem в проекте KatlaSport.Services.Models, добавив новое поле ProductCount. Добавить в класс ProductCategoryService вычисление значения поля ProductCount. Для этого шага в коде есть подсказки "TODO STEP 3".

### Выполнение

1. Создать новую ветку с именем "step3":

```sh
$ git checkout -b step3
$ git branch
  master
  step1
  step2
* step3
```

2. Добавить новое поле ProductCount в класс API-модели [ProductCategoryListItem](../KatlaSport.Services.Models/ProductManagement/ProductCategoryListItem.cs):

```cs
/// <summary>
/// Gets or sets a count of products in a product category.
/// </summary>
public int ProductCount { get; set; }
```

3. Расширить код метода GetCategoriesAsync в классе [ProductCategoryService](../KatlaSport.Services/ProductManagement/ProductCategoryService.cs) - установить для каждой категории значение поля ProductCount. Обязательно использовать асинхронный метод  CountAsync и оператор await для вызова.

```cs
foreach (var c in categories)
{
    c.ProductCount = await _context.Products.Where(p => p.CategoryId == c.Id).CountAsync();
}
```

4. Собрать проект, исправить ошибки и предупреждения (если есть).

5. Сохранить изменения как отдельный коммит.

```sh
$ git status
$ git diff
$ git add *
$ git commit -m "Add ProductCount to ProductCategoryListItem model. Get ProductCount evaluation logic to ProductCategoryService.GetCategoriesAsync."
$ git log
$ git push -u origin step3
```

11. Слить ветку "step3" с веткой "master".

```sh
$ git checkout master
$ git branch
* master
  step1
  step2
  step3
$ git merge --squash step3
$ git commit -m "Merge step3. Add ProductCount to ProductCategoryListItem model. Get ProductCount evaluation logic to ProductCategoryService.GetCategoriesAsync."
$ git push
```

### Проверка

1. Запустить swagger-console.
2. Открыть раздел "ProductCategories".
3. Запустить "GET /api/categories".
4. Найти в "Response Body" json-поле "productCount".

### Материалы

Материалы для самостоятельного изучения:
* [Введение в Entity Framework](https://metanit.com/sharp/entityframework/1.1.php)
  * LINQ to Entities
  * Асинхронность
* [Getting Started with LINQ in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/getting-started-with-linq)
