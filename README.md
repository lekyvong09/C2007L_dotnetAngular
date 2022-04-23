# Create project
```
cd ../project
dotnet new sln
dotnet new webapi -o API
dotnet sln add API/
```
### Visual Code extension
- C# of OmniSharp
- C# Extensions of JosKreativ
- NuGet Package Manager of jmrog
- NuGet Gallery of pcislo
### SSL certificate for dotnet
- sudo dotnet dev-certs https


# Code first approach - Migration
### install dotnet tool
- https://www.nuget.org/packages/dotnet-ef/
- Update tool: dotnet tool update --global dotnet-ef
### Create migration
```
PS> add-migration <migrationName>
$ dotnet ef migrations add <migrationName>
```
### Create or update database
```
PS> Update-Database
$ dotnet ef database update
```
### Delete database
```
PS> drop-database
$ dotnet ef database drop
```