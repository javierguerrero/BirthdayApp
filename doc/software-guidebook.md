# Software Guidebook

## Introduction

BirthdayBot

## Context

![](https://lh4.googleusercontent.com/xJRYRj0FDfaO3PqwTBxpuMqeCLuBp66HZkB2J6YB-TBmKUbptAy6_B_hu1A0TfDXUz4=w2400)

## Functional Overview

## Quality Attributes

## Constraints

## Principles

## Software Architecture

![](https://lh6.googleusercontent.com/xhQmeNMIbQD2XSbiuNhTN-gnfB84PiLjm8KGQZLelabX9Y4DeLd8AR2O6t9pNemeWLA=w2400)

## Infrastructure Architecture

## Deployment

## Operation and Support

Azure Function



## Development Environment

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

```
$env:SqlConnectionString="Server=tcp:sqlserver-birthdaybot.database.windows.net,1433;Initial Catalog=sqldb-birthdaybot-prod;Persist Security Info=False;User ID=dbadmin;Password=NOfumar34*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"	
```




















Azure name convention

https://learn.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming



https://www.labnol.org/google-drive-image-hosting-220515
