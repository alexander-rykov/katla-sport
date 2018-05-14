# KatlaSport Project

## Шаг 4. Product Category List

### Задание

Добавить колонку "Products" на страницу "Product Category List" с количеством продуктов для этой категории. Для этого шага в коде есть подсказки "TODO STEP 4".

### Выполнение

1. "step4".
2. Открыть HTML-шаблон компонента [product-category-list](../KatlaSportNg/src/app/product-management/lists/product-category-list.component.html).
3. Добавить колонку Products в заголовок таблицы:

```html
<th scope="col">Products</th>
```

4. Добавить ячейку с количеством продуктов в строку таблицы:

```html
<td>{{productCategory.productCount}}</td>
```

7. Собрать проект, исправить ошибки. Сохранить изменения.
8. "step4" -> "master".

### Проверка

1. Отрыть [http://localhost/categories](http://localhost:4200/categories).
2. Найти колонку Products с количеством продуктов в каждой категории.

### Материалы

Материалы для самостоятельного изучения:
* [Angular Tutorial](https://angular.io/tutorial/toh-pt2)
  * Displaying a List

Дополнительные материалы:
* [Displaying Data](https://angular.io/guide/displaying-data)
* [Template Syntax](https://angular.io/guide/template-syntax)
