cd ../src/BlogR.Data.EF.MySQL
dotnet ef migrations add InitialSchema
dotnet ef database update