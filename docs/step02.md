# KatlaSport Project

## Шаг 2. CatalogueProduct

### Задание

Расширить модель CatalogueProduct в проекте KatlaSport.DataAccess, добавив новые поля Description, ManufacturerCode и Price.
Для этого шага в коде есть подсказки "TODO STEP 2".

### Выполнение

1. Создать новую ветку с именем "step2":

```sh
$ git checkout -b step2
$ git branch
  master
  step1
* step2
```

2. Добавить новые поля Description, ManufacturerCode и Price в класс EF-модели [CatalogueProduct](../KatlaSport.DataAccess/ProductCatalogue/CatalogueProduct.cs):

```cs
/// <summary>
/// Gets or sets a product description.
/// </summary>
public string Description { get; set; }

/// <summary>
/// Gets or sets a product manufacturer code.
/// </summary>
public string ManufacturerCode { get; set; }

/// <summary>
/// Gets or sets a product price.
/// </summary>
public decimal? Price { get; set; }
```

3. Добавить описание свойства Description, ManufacturerCode и Price в файл конфигурации класса [CatalogueProductConfiguration](../KatlaSport.DataAccess/ProductCatalogue/CatalogueProductConfiguration.cs).

Ограничения:
* Description - максимальная длина строки 300 символов, необязательное поле.
* ManufacturerCode - максимальная длина строки 10 символов, обязательное поле.
* Price - обязательное поле.

```cs
Property(i => i.Description).HasColumnName("product_description").HasMaxLength(300);
Property(i => i.ManufacturerCode).HasColumnName("product_manufacturer_code").HasMaxLength(10);
Property(i => i.Price).HasColumnName("product_price").IsOptional();
```

4. Добавить новые поля Description, ManufacturerCode и Price в класс API-модели [UpdateProductRequest](../KatlaSport.Services.Models/ProductManagement/UpdateProductRequest.cs):

```cs
/// <summary>
/// Gets or sets a product description.
/// </summary>
public string Description { get; set; }

/// <summary>
/// Gets or sets a product manufacturer code.
/// </summary>
public string ManufacturerCode { get; set; }

/// <summary>
/// Gets or sets a product price.
/// </summary>
public decimal Price { get; set; }
```

5. Добавить новые правила в класс валидатора [UpdateProductRequestValidator](../KatlaSport.Services.Models/ProductManagement/UpdateProductRequestValidator.cs) для FluentValidation:

```cs
RuleFor(r => r.Description).Length(0, 300);
RuleFor(r => r.ManufacturerCode).Length(4, 10);
RuleFor(r => r.Price).GreaterThanOrEqualTo(0);
```
6. Изменить маппинг в классе [ProductManagementMappingProfile](../KatlaSport.Services/ProductManagement/ProductManagementMappingProfile.cs):

Было:

```cs
CreateMap<DataAccessProduct, Product>();
```

Стало:

```cs
CreateMap<DataAccessProduct, Product>()
    .ForMember(li => li.Description, opt => opt.MapFrom(p => p.Description == null ? string.Empty : p.Description))
    .ForMember(li => li.ManufacturerCode, opt => opt.MapFrom(p => p.ManufacturerCode == null ? string.Empty : p.ManufacturerCode));
```

6. Добавить новую миграцию с именем "AddProductDescriptionManCodePrice":

```sh
PM> Add-Migration -Name AddProductDescriptionManCodePrice
```

7. Собрать проект и исправить ошибки и предупреждения.

8. Обновить базу данных.

```sh
PM> Update-Database
```

9. Сохранить изменения как отдельный коммит.

```sh
$ git status
$ git diff
$ git add *
$ git commit -m "Add Description, ManufacturerCode and Price property to CatalogueProduct and UpdateProductRequest model. Create a new migration AddProductDescriptionManCodePrice. Add new rules to UpdateProductRequestValidator."
$ git log
$ git push -u origin step2
```

10. Слить ветку "step2" с веткой "master".

```sh
$ git checkout master
$ git branch
* master
  step1
  step2
$ git merge --squash step2
$ git commit -m "Merge step2. Add Description, ManufacturerCode and Price property to CatalogueProduct and UpdateProductRequest model. Create a new migration AddProductDescriptionManCodePrice. Add new rules to UpdateProductRequestValidator."
$ git push
```

### Проверка

### Материалы

Материалы для самостоятельного изучения:
* [Введение в Entity Framework](https://metanit.com/sharp/entityframework/1.1.php)
  * Fluent API и аннотации
* [FluentValidation](https://github.com/JeremySkinner/FluentValidation/wiki/a.-Index)
  * Creating a Validator Class
  * Built in Validators
