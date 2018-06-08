# KatlaSport Project

## Первый запуск

### Создание базы данных

1. Запустить Visual Studio.
2. Открыть "SQL Server Object Explorer".
3. Найти "(localdb)\MSSQLLocalDB".
4. Добавить новую базу данных с именем "KatlaDB".

### Сборка back-end проекта

1. Откройте [KatlaSport.sln](../KatlaSport.sln) в Visual Studio. Приложение состоит из нескольких проектов:
2. Откройте Solution Explorer.
3. Установите *KatlaSport.WebApi* как ["Startup Project"](https://msdn.microsoft.com/en-us/library/a1awth7y.aspx)
4. Открыть Solution Explorer. Открыть меню для Solution 'KatlaSport'. Restore NuGet packages.
5. Открыть Solution Explorer. Открыть меню для Solution 'KatlaSport'. Build solution.
6. Меню "Debug\Start Debugging" (Alt+D, Alt+S).
7. Откроется браузер на странице [Swagger](http://localhost:56952/swagger/ui/index).

### Сборка front-end проекта

1. Перейти в каталог KatlaSportNg и собрать проект.

```sh
D:\epam-lab\katla-sport-ng
$ cd KatlaSportNg
D:\epam-lab\katla-sport-ng\KatlaSportNg
$ ng build

Date: 2018-06-08T13:25:20.060Z
Hash: e1b9cf821744cf58374d
Time: 16616ms
chunk {main} main.js, main.js.map (main) 107 kB [initial] [rendered]
chunk {polyfills} polyfills.js, polyfills.js.map (polyfills) 227 kB [initial] [rendered]
chunk {runtime} runtime.js, runtime.js.map (runtime) 5.4 kB [entry] [rendered]
chunk {styles} styles.js, styles.js.map (styles) 199 kB [initial] [rendered]
chunk {vendor} vendor.js, vendor.js.map (vendor) 4.11 MB [initial] [rendered]
```

2. Запустить Angular Live Development Server.

```sh
D:\epam-lab\katla-sport-ng\KatlaSportNg
$ ng serve

** Angular Live Development Server is listening on localhost: 4200, open your browser on http://localhost:4200/ **

Date: 2018-06-08T13:25:58.588Z
Hash: f85abc281ec234e5936b
Time: 13447ms
chunk {main} main.js, main.js.map (main) 108 kB [initial] [rendered]
chunk {polyfills} polyfills.js, polyfills.js.map (polyfills) 227 kB [initial] [rendered]
chunk {runtime} runtime.js, runtime.js.map (runtime) 5.4 kB [entry] [rendered]
chunk {styles} styles.js, styles.js.map (styles) 199 kB [initial] [rendered]
chunk {vendor} vendor.js, vendor.js.map (vendor) 4.43 MB [initial] [rendered]
i ｢wdm｣: Compiled successfully.
```

3. Открыть в браузере страницу [localhost:4200](http://localhost:4200/).
