# KatlaSport Project

## Шаг 8. Hive Section List

### Задание

Добавить возможность просматривать список секций.

### Выполнение

1. "step8".
2. Добавить во front-end модель [HiveSectionListItem](../KatlaSportNg/src/app/hive-management/models/hive-section-list-item.ts) все поля из back-end модели [HiveSectionListItem](../KatlaSport.Services.Models/HiveManagement/HiveSectionListItem.cs).
3. Добавить реализацию метода getHiveSections в сервис [hive.service](../KatlaSportNg/src/app/hive-management/services/hive.service.ts).

```typescript
getHiveSections(hiveId: number): Observable<Array<HiveSectionListItem>> {
  return this.http.get<Array<HiveSectionListItem>>(`${this.url}${hiveId}/sections`);
}
```

4. Добавить реализацию метода ngOnInit в код компонента [HiveSectionListComponent](../KatlaSportNg/src/app/hive-management/lists/hive-section-list.component.ts).

```typescript
ngOnInit() {
  this.route.params.subscribe(p => {
    this.hiveId = p['id'];
    this.hiveService.getHiveSections(this.hiveId).subscribe(s => this.hiveSections = s);
  })
}
```

5. Добавить список секций в таблицу в коде разметки компонента [HiveSectionListComponent](../KatlaSportNg/src/app/hive-management/lists/hive-section-list.component.html). Используйте [HiveListComponent](../KatlaSportNg/src/app/hive-management/lists/hive-section-list.component.html) в качестве примера.
6. Для каждой секции в таблице должна быть кнопка "Edit", которая должна производить переход на страницу "/section/hive_section_id".
7. Собрать проект, исправить ошибки. Сохранить изменения.
8. "step8" -> "master".

### Проверка

1. Отрыть [http://localhost/hives](http://localhost:4200/hives).
2. Перейти на список секторов с помощью кнопки "View sectors".
3. Перейти на редактор сектора с помощью кнопки "Edit".

### Материалы

Материалы для самостоятельного изучения:
* [Angular Tutorial & Fundamentals](https://angular.io/docs)
  * OnInit
  * HttpClient
  * Services
