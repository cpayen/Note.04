# Note

Playing with .Net Core and Vue.js

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