# dotnet-aspnet-codegenerator

## Add NuGet package
```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.0.3
```

## Install
```
dotnet tool install -g dotnet-aspnet-codegenerator
```

## Update
```
dotnet tool update -g dotnet-aspnet-codegenerator
```

## Uninstall
```
dotnet tool uninstall -g dotnet-aspnet-codegenerator
```

## Create a Controller
```
dotnet-aspnet-codegenerator controller --project . -name CategoryController -outDir Controllers -async -api -actions
```