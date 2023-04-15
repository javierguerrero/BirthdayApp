

### Clean Architecture
- [Clean Architecture Project Setup From Scratch With .NET 7](https://www.youtube.com/watch?v=Ru6_b50wdfo)
- [Clean Architecture With Document Database, Minimal APIs, And CQRS In .NET 7
](https://www.youtube.com/watch?v=fe4iuaoxGbA)



### Migrations commnands in EF Core

**Adding a migration**

```
PM> Add-Migration
```

- Startup project: BirthdayBot
- Default project in PMC: Infrastructure

**Create or Update the Database**

```
PM> Update-Database
```

**Remove a migration**

```
PM> Remove-Migration
```

**Deshacer último Update-Database**

```
PM> Update-Database [Migration_Name]
```

**Variable de entorno: ConnectionString**

```
$env:SqlConnectionString="Server=DESKTOP-UAKPHLG\SQLEXPRESS; Database=sqldb-birthdaybot-dev; Trusted_Connection=True; TrustServerCertificate=True;"
```

https://www.labnol.org/google-drive-image-hosting-220515
https://www.markdownguide.org/basic-syntax/
