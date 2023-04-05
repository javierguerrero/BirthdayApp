Crear una nueva aplicación
ng new heroesApp

Angular Material
https://material.angular.io/guide/getting-started
ng add @angular/material

Reconstruir módulo de nodejs
npm install

Ejecutar aplicación
ng serve -o

Crear módulo
ng g m auth

Crear módulo con routing
ng g m auth --routing

Crear un componente
ng g c auth/pages/login

Crear módulo en la raiz del proyecto
ng g m appRouting --flat

json-server
https://www.npmjs.com/package/json-server

Levantar json-server
json-server --watch db.json

https://quicktype.io/

Crear variables de entorno
ng g environments

CSS Grid Generator
https://cssgrid-generator.netlify.app/

Crear un Guard
ng g guard auth/guards/auth

Autenticación mediante Google

1. configuracion en Google Console
   https://console.cloud.google.com/

- Configure consent screen (OAuth consent screen)
- APIs & Services >> Credentials >> OAth client ID
- Save the "Client ID"
- Display the Sign In With Google button (https://developers.google.com/identity/gsi/web/guides/display-button#javascript)
- Para ver el contenido del token, usar https://jwt.io/







# Contacts

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 15.2.4.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
