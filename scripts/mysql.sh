cd ../src/BlogR.Data.EntityFramework.MySQL
dotnet ef migrations add InitialSchema
dotnet ef database update