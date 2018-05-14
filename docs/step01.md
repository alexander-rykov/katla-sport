# KatlaSport Project

## Шаг 1. ProductCategory

### Задание

Расширить модель ProductCategory в проекте KatlaSport.DataAccess, добавив в модель новое поле Description. Для этого шага в коде есть подсказки "TODO STEP 1".

### Выполнение

0. Открыть "Git Bash" и перейти в рабочий каталог репозитория katla-sport.

```sh
Epamuser@MachineName MINGW64 ~
$ cd c:/epam-lab/katla-sport

Epamuser@MachineName MINGW64 /c/epam-lab/katla-sport (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

nothing to commit, working tree clean
```

1. Создать новую ветку с именем "step1":

Создать ветку командой [git checkout](https://git-scm.com/book/ru/v1/Ветвление-в-Git-Основы-ветвления-и-слияния):

```sh
$ git checkout -b step1
```

Проверить, что новая ветка "step1" является текущей командой [git branch](https://git-scm.com/book/ru/v1/Ветвление-в-Git-Управление-ветками):

```sh
$ git branch
  master
* step1
```

2. Добавить новое поле Description в класс [ProductCategory](../KatlaSport.DataAccess/ProductCatalogue/ProductCategory.cs):

```cs
public class ProductCategory
{
    ...

    /// <summary>
    /// Gets or sets a product category description.
    /// </summary>
    public string Description { get; set; }
}
```

3. Добавить описание свойства Description в файл конфигурации класса EF-модели [ProductCategoryConfiguration](../KatlaSport.DataAccess/ProductCatalogue/ProductCategoryConfiguration.cs) с ограничением на длину строки. Максимальная длина строки - 300 символов.

```cs
internal sealed class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
{
    public ProductCategoryConfiguration()
    {
        ...
        Property(i => i.Description).HasColumnName("category_description").HasMaxLength(300);
    }
}
```

4. Добавить новую миграцию с именем "AddCategoryDescription":

* Открыть Package Manager Console (комбинация клавиш для быстрого доступа - Alt T N O).
* Установить в окне консоли переключатель "Default project" на значение "KatlaSport.DataAccess".
* В коммандной строке консоли запустить "Add-Migration -Name AddCategoryDescription" для создания новой миграции.
* Пересобрать проект командой меню "Build\Rebuild solution". Исправить новые ошибки и предупреждения из окна "Error List".
* В коммандной строке консоли запустить "Update-Database".

5. Сохранить изменения как отдельный коммит.

Просмотреть список измененных файлов командой [git status](https://git-scm.com/book/ru/v1/Основы-Git-Запись-изменений-в-репозиторий):

```sh
$ git status
```

Просмотреть изменения в файлах командой [git diff](https://git-scm.com/book/ru/v1/Основы-Git-Запись-изменений-в-репозиторий):

```sh
$ git diff
```

Добавить изменения командой [git add](https://git-scm.com/book/ru/v1/Основы-Git-Запись-изменений-в-репозиторий):

```sh
$ git add *
```

Создать новый коммит с понятным описанием командой [git commit](https://git-scm.com/book/ru/v1/Основы-Git-Запись-изменений-в-репозиторий):

```sh
$ git commit -m "Add Description property to ProductCategory model. Create a new migration AddCategoryDescription."
```

Просмотреть журнал ветки c помощью команды [git log](https://git-scm.com/book/ru/v1/Основы-Git-Просмотр-истории-коммитов):

```sh
$ git log
```

6. Опубликовать ветку.

Опубликовать ветку "step1" в удаленном репозитории командой git push.

```sh
$ git push -u origin step1
```

7. Слить ветку "step1" с веткой "master".

Переключиться на ветку "master" и проверить, что она является основной:

```sh
$ git checkout master
$ git branch
* master
  step1
```

Влить изменения из ветки "step1" в ветку "master":

```sh
$ git merge --squash step1
```

Создать новый коммит с понятным описанием:

```sh
$ git commit -m "Merge step1. Add Description property to ProductCategory model. Create a new migration AddCategoryDescription."
```

Опубликовать изменения в ветке "master":

```sh
$ git push
```

### Проверка

1. Запустить swagger-console.
2. Открыть раздел "ProductCategories".
3. Запустить "GET /api/categories/{id}" с параметром "id" = "1".
4. Скопировать json-объект из "Response Body".
5. Открыть "PUT /api/categories/{id}".
6. Вставить json-объект в поле "updateRequest", вставить "1" в "id".
7. Заменить "null" значение поля "description" на текст "Description for Running Shoes".
8. Нажать кнопку "Try it out!"
9. GET /api/categories/1.
10. Найти "description" в "Response Body".
11. Открыть [ProductCategoriesController](../KatlaSport.WebApi/Controllers/ProductCategoriesController.cs) в Visual Studio.
12. Поставить точку останова в начале метода GetProductCategory.
13. Снова запустить "GET /api/categories/{id}".
14. Войти в метод GetCategoryAsync класса [ProductCategoryService](../KatlaSport.Services/ProductManagement/ProductCategoryService.cs) используя "Debug\Step Into" или F11.

```cs
public async Task<ProductCategory> GetCategoryAsync(int id)
{
    ...
    return Mapper.Map<DbProductCategory, ProductCategory>(dbCategories[0]); // Посмотреть dbCategories[0].
}
```

15. "Debug\Step Over" или F10 до вызова Mapper.Map().
16. Посмотреть состояние объекта dbCategories[0], найти поле Description.
17. Выйти из метода и посмотреть состояние переменной category в методе ProductCategoriesController.GetProductCategory.

```cs
public async Task<IHttpActionResult> GetProductCategory([FromUri] int id)
{
    var category = await _categoryService.GetCategoryAsync(id);
    return Ok(category); // Посмотреть состояние переменной category.
}
```

Обратите внимание, что в коде нет присваивания полю ProductCategory.Description значения ProductCategory.Description. Это присваивание происходит автоматически во время вызова метода Mapper.Map.

18. "Debug\Continue" или F5.
19. Поставить точку останова на set поля Description класса [ProductCategory](../KatlaSport.Services.Models/ProductManagement/ProductCategory.cs):

```cs
public string Description { get; set; } // Поставить точку останова на set.
```

20. Запустить GET.
21. Посмотреть стек вызовов "Debug\Windows\Call Stack" (Alt D W C).
22. Debug\Continue.

### Материалы

Материалы для самостоятельного изучения:
* [Введение в Entity Framework](https://metanit.com/sharp/entityframework/1.1.php)
  * Введение в Entity Framework
  * Взаимодействие с данными. Подходы
  * Основы Entity Framework
* [First look at the Visual Studio Debugger](https://docs.microsoft.com/en-us/visualstudio/debugger/debugger-feature-tour)
* [Tutorial: Learn to debug using Visual Studio](https://docs.microsoft.com/en-us/visualstudio/debugger/getting-started-with-the-debugger)

Дополнительные материалы:
* [Introduction to Entity Framework](https://msdn.microsoft.com/en-us/library/aa937723(v=vs.113).aspx)
* [ADO.NET Entity Framework](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/)
* [Debugging in Visual Studio](https://docs.microsoft.com/en-us/visualstudio/debugger/index)