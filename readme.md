# Note

Playing with .Net Core and Vue.js

- 1 app front Vue.js
- 1 API .Net Core 3.1
- Error / Logging middlewares
- Clean architecture / hexagonal
- JWT authentication / AAD
- Swagger doc
- SQL Server / EF Core / Generic repository

## Vue.js app

Launch dev server
``` 
yarn serve 
``` 

## EF Core

As they are multiple startup projects, you need to specify startup project in EF Core commands.

```
add-migration Initial -StartupProject "Note.Api" -OutputDir Data/Migrations/
update-database -StartupProject "Note.Api"
```
