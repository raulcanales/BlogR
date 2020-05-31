cd ../src/BlogR.Data.EntityFramework.MSSQL
dotnet ef migrations add InitialSchema
dotnet ef database update