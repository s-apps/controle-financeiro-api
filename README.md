# Create a web API with ASP.NET Core controllers

Create a RESTful service with ASP.NET Core controllers that supports create, read, update, delete (CRUD) operations.

## Create a web API project on Windows

- mkdir ControleFinanceiroApi
- cd ControleFinanceiroApi

```
dotnet new webapi -f net6.0
```

## Generate a gitignore file

```
dotnet new gitignore
```

## Trust the ASP.NET Core HTTPS development certificate on Windows

```
dotnet dev-certs https --trust
```

## Build and test the web API

```
dotnet run
```

# Persist and retrieve relational data with Entity Framework Core

Here: [Entity Framework Core](EntityFrameworkCore.md)