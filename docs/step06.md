# KatlaSport Project

## Шаг 6. Hive List

### Задание

Добавить колонки "Code" и "Name" на страницу "Hive List" для отображения кода и имени каждой категории. Для этого шага в коде есть подсказки "TODO STEP 6".

### Выполнение

1. "step6".
2. Открыть модель [HiveListItem](../KatlaSportNg/src/app/hive-management/models/hive-list-item.ts).
3. Добавить в конструктор параметры name и code:

```ts
public name: string,
public code: string,
```

4. Открыть разметку компонента [HiveListComponent](../KatlaSportNg/src/app/hive-management/lists/hive-list.component.html).
5. Добавить в заголовок таблицы колонки "Code" и "Name".
6. Добавить в строку таблицы колонки для отображения code и name полей модели.
7. Добавить кнопку перехода на секции:

```html
<div class="btn-group mr-2" role="group" aria-label="View group">
  <button routerLink="/hive/{{hive.id}}/sections" type="button" class="btn btn-primary">View sections</button>
</div>
```

8. Добавить кнопку перехода на редактор:

```html
<div class="btn-group" role="group" aria-label="Edit group">
  <button routerLink="/hive/{{hive.id}}" type="button" class="btn btn-primary">Edit</button>
</div>
```

9. Собрать проект, исправить ошибки и предупреждения (если есть).
10. Сохранить изменения как отдельный коммит с понятным описанием "Add Code and Name columns to hive-list component.".
11. "step6" -> "master".


### Проверка

1. Открыть [http://localhost/hives](http://localhost:4200/hives).
2. Найти колонки "Name" и "Code".
3. Найти кнопки "View sections" и "Edit".

### Материалы

Материалы для самостоятельного изучения:
* [Angular Tutorial](https://angular.io/tutorial/toh-pt2)
  * Displaying a List

Дополнительные материалы:
* [Displaying Data](https://angular.io/guide/displaying-data)
* [Template Syntax](https://angular.io/guide/template-syntax)
