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

### Users

1. Authenticated

### External Systems

There are two types of systems that BirthdayApp integrates with.

1. **Twilio:** Twilio’s Programmable SMS API helps you add robust messaging capabilities to your applications.
2. **E-mail System:** The SMTP server for Gmail is a free SMTP server that anyone across the globe can use. It allows you to manage email transactions from your Gmail account via email clients or web applications. [More info](https://www.siteground.com/kb/gmail-smtp-server/)

## Functional Overview

This section provides a summary of the functionality provided by the BirthdayApp. We are going to focus on a technique called "Example Mapping" that is a simple and efficent way to facilitate your requirement workshops.

![](https://drive.google.com/uc?id=12j-geiqN9bqj_C5yokVXyqe2oiRbcr64)

### Gestionar contactos

```
Como: usuario
Quiero: realizar altas, bajas y modificaciones de contactos
Para: enviar saludos de cumpleaños

    1. Rule: Agregar nuevo contacto incluyendo datos mínimos de nombre, fecha de nacimiento, email y celular.
        a. Datos completos
            * Peter selecciona la opción 'nuevo contacto'
            * Ingresa los datos: nombre('Javier'), fecha de nacimiento ('17/02/1982'), email('javier@mail.com') y celular('+51985693128')
            * Guarda los datos
            * Contacto creado exitosamente
        b. Datos incompletos
            * Peter selecciona la opción 'nuevo contacto'
            * Ingreso los datos: nombre('Javier'), email('javier@gmail.com)
            * Guarda los datos
            * Mensaje de error: todo los campos son obligatorios
    2. Rule: Editar Contacto
        a. Modificar celular
            * Tim selecciona contacto 'Javier' de la lista de contactos
            * Cambiar celular('+51976268172')
            * Guarda cambio
            * Cambio aceptado
    3. Rule: Eliminar Contacto
        a. Eliminación confirmada
            * Hay un contacto 'Javier' en la lista de contactos
            * George elige la opción de eliminar al contacto 'Javier'
            * Aparece cuadro de diálogo para confirmar elimimación
            * Selecciona que si
            * Se elimina contacto de la lista de contactos
```

### Recordar los cumpleaños del día

```
Como: usuario
Quiero: Recibir una notificación vía email con la lista de personas cumplen años hoy
Para: saludarlos personalmente

    1. Rule: abc
        a. xyz
        b. mnp

    2. Rule: prq
        a. uyt
        b. pow
```

### Enviar saludo de cumpleaños automáticamente por SMS

```
Como: usuario
Quiero: mandar saludos vía SMS a los que cumplen años hoy
Para: mitigar el riesgo de olvidar el saludo de esa fecha especial

    1. Rule:
    2. Rule:
```

## Quality Attributes

This section provides information about the desired quality attributes (non-functional require-
ments) of the BirthdayApp.

### Performance

All pages on BirthdayApp should load and render in under five seconds, for fifty concurrent users.

### Security

All authentication must be done via a third-party mechanism such as Twitter, Facebook or Google.

### Internationalisation

All user interface text will be presented in English only.

### Browser compatibility

The BirthdayApp should work consistently across the following browsers:

- Chrome
- Edge
- Firefox

## Constraints

This section provides information about the constraints imposed on the development of the
techtribes.je website.

### Budget

Since there is no formal budget for the BirthdayApp, there is a constraint to use free and
open source technologies for the development. Ideally, the application should run on a single server
with hosting costs of less than 20 USD per month.

## Principles

This section provides information about the principles adopted for the development of the
BirthdayApp.

### Automated testing

The strategy for automated testing is to use automated unit and component tests.

- **Unit tests:** These are fast running, very small tests that operate on a single class or method in isolation.
- **Component tests:** Rather than mocking out database connections to test component internals, components are tested as single units to avoid breaking encapsulation.

### Configuration

All configuration needed by components is externalised into a settings.json file, which is
held outside of the deployment files created by the build process. This means that builds can be
migrated from development, testing and into production without change.

## Software Architecture

This section provides an overview of the BirthdayApp software architecture.

### Containers

The following diagram shows the logical containers that make up the BirthdayApp system. The diagram does not represent the physical number and location of containers - please see the infrastructure and deployment sections for this information.

![](https://drive.google.com/uc?id=1WkzdFAeVOG7KocJSl7oOvSkv6YS9TxXa)

- **Contacts Web:**
- **Contacts API:**
- **Database:** A SQL Server database that stores that stores the majority of the data behind the BirthdayApp.
- **BirthdayBot:**

### Components - BirthdayBot

The following diagram shows the components that make up the BirthdayBot.

## Infrastructure Architecture

This section provides information about the infrastructure architecture of the BirthdayApp.

### Live environment

The live environment is very simple; it's a single Cloud Server at Azure, hosted in the East US location as follows:

#### Azure function

- **Description:** Azure Function is a serverless compute service that enables user to run event-triggered code without having to provision or manage infrastructure.
- **Notes:** Ingresar a "Settings >> Configuration" y crear una nueva "application setting" con el nombre "SqlConnectionString".

#### SQL Database

- **Description:** Azure SQL Database is an always-up-to-date, fully managed relational database service built for the cloud.
- **Notes:** Para que la Azure Function pueda acceder al servidor de BD, tenemos que entrar a este y marcar la opción "Allow Azure services and resources to access to this server".

#### Web App

- **Description:** Azure App Service is an HTTP-based service for hosting web applications, REST APIs, and mobile back ends.
- **Notes:** -

[Azure naming convention](https://learn.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming)

## Deployment

This section provides information about the mapping between the software architecture and the infrastructure architecture.

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

https://www.labnol.org/google-drive-image-hosting-220515
https://www.markdownguide.org/basic-syntax/
