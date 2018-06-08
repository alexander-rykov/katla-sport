# KatlaSport Project

## Необходимые инструменты

В качестве системы контроля версий будет использован Git и бесплатная площадка для хранения репозиториев - Github. В этом руководстве для работы с Git используется командная строка.

Для разработки back-end части потребуется Visual Studio IDE, а для front-end - Node.Js и Visual Studio Code IDE.

В качестве СУБД приложениие использует SQL Server.

### Git и SSH-ключ

1. Открыть [Downloading Git](https://git-scm.com/download/win) и загрузить установщик.
2. Запустить установщик Git.
3. Выбрать следующие настройки:
    * В окне "Choosing the default editor used by Git" выбрать "Use the Nano editor by default".
    * В окне "Choosing HTTPS transport backend" выбрать "Use the OpenSSL library".
	* В окне "Adjusting your PATH environment" выбрать "Use Git from Windows command prompt".
	* В окне "Configuring the line ending conversions" выбрать "Checkout Windows-style, commit Unix-style line endings".
	* В окне "Configuring extra options" выбрать "Enable Git Credential Manager".
4. Установить.
5. В "Пуск" найти и запустить "Git Bash".
6. Сгенерируйте SSH-ключ, используя ваш почтовый ящик вместо firstname_lastname@epam.com. Нажать Enter 3 раза.
```sh
epamuser@vm-orbital MINGW64 ~
$ ssh-keygen -t rsa -b 4096 -C "firstname_lastname@epam.com"
Generating public/private rsa key pair.
Enter file in which to save the key (/c/Users/epamuser/.ssh/id_rsa): <ENTER>
Created directory '/c/Users/epamuser/.ssh'.
Enter passphrase (empty for no passphrase): <ENTER>
Enter same passphrase again: <ENTER>
Your identification has been saved in /c/Users/epamuser/.ssh/id_rsa.
Your public key has been saved in /c/Users/epamuser/.ssh/id_rsa.pub.
```
7. Открыть файл id_rsa.pub, используя путь из "Your identification has been saved in...".
```sh
notepad.exe c:\Users\epamuser\.ssh\id_rsa.pub
```

### Github и установка SSH-ключа

1. Создать аккаунт на [github](https://github.com) или использовать существующий.
2. Войти на сайт - "Sign in".
3. Открыть настройки ["Settings\SSH and GPG keys"](https://github.com/settings/keys).
4. Нажать ["New SSH key"](https://github.com/settings/ssh/new).
5. Вставить ключ из файла id_rsa.pub в поле Key.
6. Нажать "Add SSH key".

### Visual Studio

1. Открыть [Visual Studio Downloads](https://www.visualstudio.com/downloads/).
2. Нажать на кнопку "Free download" для Visual Studio Community 2017 и загрузить web-установщик.
3. Запустить установщик.
4. В разделе "Workloads" включить ["ASP.NET and web development"](https://www.visualstudio.com/vs/support/selecting-workloads-visual-studio-2017/).
5. В разделе "Individual components" включить компоненты ".NET Framework 4.7.1 SDK" и ".NET Framework 4.7.1 targeting pack".
6. В разделе "Individual components" найти компонент "SQL Server Express 2016 LocalDB" и включить, если он выключен.
7. Установить.

### NodeJS

1. Открыть ["Downloads"](https://nodejs.org/en/download/).
2. Выбрать ["Current"](https://nodejs.org/en/download/current), "Windows Installer" и загрузить установщик.
3. Установить с настройками по-умолчанию.

### Angular/CLI

Установка Angular/CLI возможно только после установки NodeJs.

1. Открыть консоль командной строки и ввести "npm -g i @angular/cli":

```sh
C:\Users\epamuser>npm -g i @angular/cli
C:\Users\epamuser\AppData\Roaming\npm\ng -> C:\Users\epamuser\AppData\Roaming\npm\node_modules\@angular\cli\bin\ng

> @angular/cli@6.0.1 postinstall C:\Users\epamuser\AppData\Roaming\npm\node_modules\@angular\cli
> node ./bin/ng-update-message.js

+ @angular/cli@6.0.1
updated 9 packages in 20.781s
```
2. Проверить версию CLI:

```sh
C:\Users\epamuser>ng --version
Angular CLI: 6.0.1
Node: 10.1.0
OS: win32 x64
...
```

### Visual Studio Code

Для работы с front-end потребуется VS Code.

1. Открыть [Visual Studio Code](https://code.visualstudio.com/).
2. Нажать на кнопку "Download for Windows" (Stable Build) и загрузить установщик.
3. Установить с настройками по-умолчанию.

### (Не требуется) .NET Framework 4.7.1

Если у вас уже установлена Visual Studio, но не установлен фреймворк версии 4.7.1, то его можно установить через Visual Studio Installer (описано выше) или загрузить и установить эти пакеты вручную:

1. Установить [Microsoft .NET Framework 4.7.1 (Web Installer)](https://www.microsoft.com/en-us/download/details.aspx?id=56115).
2. Установить [Microsoft .NET Framework 4.7.1 Developer Pack](https://www.microsoft.com/en-us/download/details.aspx?id=56119)

### (Не требуется) SQL Server

Для выполнения этого проекта достаточно установить LocalDB через VS Installer. Также можно использовать полноценную версию СУБД - SQL Server EE 2016.

1. Открыть [SQL Server Express Edition](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express).
2. Нажать на кнопку "Download now" и загрузить web-установщик.
3. Выбрать "Custom".
4. В окне выбрать пункт "New SQL Server stand-alone installation or add features to an exising installation". (См. [экраны в руководстве](http://help.dugeo.com/m/Insight4-0/l/438911-downloading-and-installing-sql-server).)
5. В разделе "Feature Selection" выбрать ["LocalDB"](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-2016-express-localdb?view=sql-server-2017).
6. В разделе "Instance Configuration" - "Named Instance" = "SQLExpress".
7. Чтобы уменьшить время запуска Windows можно в разделе "Server Configuration" можно выбрать "Startup Type" = "Manual". В этом случае СУБД не будет автоматически стартовать сразу после запуска ОС и потребуется ручной запуск через оснастку ["Сервисы"](https://www.dmosk.ru/miniinstruktions.php?mini=services-windows).
8. В разделе "Database Engine Configuration" выбрать "Authenticatio Mode" = "Mixed Mode" и задать пароль администратора. Для создания сильного пароля можно использовать [Secure Password Generator](https://passwordsgenerator.net).
9. Установить.

## Репозитории

Для работы потребуется [сделать личные копии репозиториев](https://help.github.com/articles/fork-a-repo/) katla-sport и katla-sport-ng, а затем клонировать их на локальный диск.

1. Открыть [github.com](https://github.com/).
2. Войти на сайт под своим аккаунтом.
3. Открыть репозиторий [katla-sport](https://github.com/epam-lab/katla-sport).
4. Нажать кнопку "Fork".
5. Открыть репозиторий [katla-sport-ng](https://github.com/epam-lab/katla-sport-ng).
6. Нажать кнопку "Fork".
7. Откройте "Git CMD" в "Пуск".
8. Перейдите в рабочий каталог:

```sh
C:\Users\epamuser>d:
D:\>mkdir epam-lab
D:\>cd epam-lab
```

9. Перейдите на страницу личного репозитория katla-sport. Например, если имя вашего пользователя mygituser, то страница - https://github.com/mygituser/katla-sport.
10. Нажмите на кнопку "Clone or download" и скопируйте в окне "Clone with SSH" путь к репозиторию.
11. Клонируйте репозиторий:

```sh
D:\epam-lab>git clone https://github.com/mygituser/katla-sport/
Cloning into 'katla-sport'...
The authenticity of host 'github.com (192.30.253.113)' can't be established.
RSA key fingerprint is SHA256:...
Are you sure you want to continue connecting (yes/no)? yes
Warning: Permanently added 'github.com,192.30.253.113' (RSA) to the list of known hosts.
remote: Counting objects: ...
remote: Compressing objects: ...
remote: Total ...
Receiving objects: ..
Resolving deltas: ...
```

12. Повторите для katla-sport-ng.

```sh
D:\epam-lab>git clone https://github.com/mygituser/katla-sport-ng/
Cloning into 'katla-sport-ng'...
...
```

13. Настройте имя и email для Git:

```sh
D:\epam-lab\git config --global user.email "myemail@gmail.com"
D:\epam-lab\git config --global user.name "Firstname Lastname"
``