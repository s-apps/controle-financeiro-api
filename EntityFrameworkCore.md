# Persist and retrieve relational data with Entity Framework Core

## Add NuGet packages

## Provider for MySQL
```
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
```

## Entity Framework Core Tools
```
dotnet tool install --global dotnet-ef
```

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## Create and run a migration
```
dotnet ef migrations add InitialCreate --context ControleFinanceiroContext
```

```
dotnet ef database update --context ControleFinanceiroContext
```

## HTTP PATCH
``` 
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 6.0.4
```

```
dotnet add package Microsoft.AspNetCore.JsonPatch --version 6.0.4
```

```
builder.Services.AddControllers().AddNewtonsoftJson();
```