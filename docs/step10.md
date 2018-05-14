# KatlaSport Project

## Шаг 10. Delete/Restore

### Задание

Добавить колонки кнопки "Delete" и "Restore" на страницу "Hive List" для удаления или восстановления элемента списка.

### Выполнение

1. Создать ветку.
2. Добавить в шаблон hive-list.component.html для каждой строки таблицы новую группу с одной кнопкой "Restore". Группа должна отображаться, если "hive.isDeleted == true" (используйте [ngIf](https://angular.io/api/common/NgIf)). Событие по кнопке - onRestore(hive.id).
3. В классе компонента hive-list.component.ts реализовать функцию "onRestore".
3. В классе сервива hive.service.ts реализовать функцию "setHiveStatus".
4. Собрать проект, исправить ошибки. "commit", "push". Влить в "master".

### Проверка

1. Открыть [http://localhost/hives](http://localhost:4200/hives).
2. Нажать кнопку "Delete" для любой строки таблицы.
3. Кнопка "Delete" должна исчезнуть, должна появиться кнопка "Restore".
4. Нажать "Restore".
5. Кнопка "Restore" должна исчезнуть, должна появиться кнопка "Delete".

### Материалы

Материалы для самостоятельного изучения:
* Angular Fundamentals
  * [Observables](https://angular.io/guide/observables)
  * [HttpClient](https://angular.io/guide/http)
