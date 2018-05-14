# KatlaSport Project

## Шаг 12. Hive Editor

### Задание

Добавить возможность создания нового хранилища, редактирование и удаление существующего.

### Выполнение

1. Создать ветку.
2. В hive.service.ts реализовать методы addHive, updateHive и deleteHive.
3. В hive-form.component.html добавить поля "Hive Code" и "Hive Address" для редактирования поле hive.code и hive.address.

Правило валидации для "Hive Code":
* Количество символов не менее и не более 5.

Правило валидации для "Hive Address":
* Количество символов не более 300.

4. В hive-form.component.html добавить кнопки "Back", "Save", "Delete", "Undelete" и "Purge".
5. В hive-form.component.ts реализовать методы onSubmit, onDelete, onUndelete и onPurge.
6. Собрать проект, исправить ошибки. "commit", "push". Влить в "master".

### Проверка

1. Открыть [http://localhost/hives](http://localhost:4200/hives).
2. Добавить новый хайв.
3. Отредактировать хайв.
4. Удалить хайв.

### Материалы

Материалы для самостоятельного изучения:
* Angular Tutorial
  * [Service](https://angular.io/tutorial/toh-pt4)
  * [HttpClient](https://angular.io/guide/http)
