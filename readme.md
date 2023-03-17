# BirthdayApp - Software Guidebook

## Introduction

This software guidebook provides an overview of the BirthdayApp. It includes a summary of the following:

- The requirements, constraints and principles behind the solution.
- The software architecture, including the high-level technology choices and structure of the software.
- The infrastructure architecture and how the software is deployed.
- Operational and support aspects of the application.

## Context

BirthdayApp is a software solution that enables you to manage your contacts and remember the birthdays of your friends, family, and coworkers. With this application, you can easily add new contacts to your birthday list and receive reminders when their birthdays are approaching.

In addition, BirthdayApp allows you to automatically send birthday greetings to your contacts, so you never forget to send your best wishes on your loved ones' special day. You can personalize your birthday messages and schedule them to be automatically sent on the exact date of the birthday.

With BirthdayApp, you'll never have to worry about forgetting your friends' and family's birthdays, and you can always surprise them with a personalized greeting on their special day!

Here's a context diagram tha provides a visual summary of this:

![](https://drive.google.com/uc?id=1vX7S926bLIMZbfIzyQGVxxPKNQMvl0Ml)

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

# Azure Resources

    Azure function
    	Ingresar a "Settings >> Configuration" y crear una nueva "application setting" con el nombre "SqlConnectionString"
    	Para que la función pueda acceder al servidor de BD, tenemos que entrar a este y marcar la opción "Allow Azure services and resources to access to this server"

Azure name convention

https://learn.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming

https://www.labnol.org/google-drive-image-hosting-220515
