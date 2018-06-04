# KatlaSport Project

## Шаг 10. Delete/Restore

### Задание

Добавить кнопки "Delete" и "Restore" на страницы "Hive List" и "Hive Section List" для удаления или восстановления элемента списка.

### Выполнение

1. Создать ветку.
2. Добавить в код разметки компонента HiveListComponent новую группу с одной кнопкой "Restore". Группа должна отображаться для каждой строки таблицы, если "hive.isDeleted == true" (используйте [ngIf](https://angular.io/api/common/NgIf)). Событие по кнопке - onRestore(hive.id).
3. Реализовать в компоненте HiveListComponent функцию "onRestore".
4. Реализовать в сервисе HiveService функцию "setHiveStatus".
5. Добавить в код разметки компонента HiveSectionListComponent кнопки "Delete" и "Undelete" c обработчиками "onDelete" и "onUndelete" соответственно.
6. Добавить в компонент HiveSectionListComponent функции "onDelete" и "onUndelete".
7. Реализовать в сервисе HiveSectionService функцию "setHiveSectionStatus".
8. Собрать проект, исправить ошибки. "commit", "push". Влить в "master".

### Проверка

1. Открыть [http://localhost/hives](http://localhost:4200/hives).
2. Нажать кнопку "Delete" для любой строки таблицы.
3. Кнопка "Delete" должна исчезнуть, должна появиться кнопка "Undelete".
4. Нажать "Undelete".
5. Кнопка "Undelete" должна исчезнуть, должна появиться кнопка "Delete".
6. Открыть список секций.
7. Проверить кнопку "Delete".
8. Проверить кнопку "Undelete".

### Материалы

Материалы для самостоятельного изучения:
* Angular Fundamentals
  * [Observables](https://angular.io/guide/observables)
  * [HttpClient](https://angular.io/guide/http)
