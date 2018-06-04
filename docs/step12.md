# KatlaSport Project

## Шаг 12. Hive Editor

### Задание

Добавить возможность создания нового хранилища, редактирование и удаление существующего.

### Выполнение

1. Создать ветку.
2. Реализовать в сервисе HiveService методы addHive, updateHive и deleteHive.
3. Добавить в разметку HiveFormComponent поля "Hive Code" и "Hive Address" для редактирования полей модели  hive.code и hive.address.

Правило валидации для "Hive Code":
* Количество символов не менее и не более 5.

Правило валидации для "Hive Address":
* Количество символов не более 300.

4. Добавить в разметку HiveFormComponent кнопки "Back", "Save", "Delete", "Undelete" и "Purge".
5. Реализовать в HiveFormComponent методы onSubmit, onDelete, onUndelete и onPurge.
6. Собрать проект, исправить ошибки. "commit", "push". Влить в "master".

### Проверка

1. Открыть [http://localhost/hives](http://localhost:4200/hives).
2. Добавить новое хранилище.
3. Отредактировать существующее хранилище.
4. Удалить хранилище.

### Материалы

Материалы для самостоятельного изучения:
* Angular Tutorial
  * [Service](https://angular.io/tutorial/toh-pt4)
  * [HttpClient](https://angular.io/guide/http)
