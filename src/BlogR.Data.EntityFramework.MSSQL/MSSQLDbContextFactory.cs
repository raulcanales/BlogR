using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BlogR.Data.EntityFramework.MSSQL
{
    public class MSSQLDbContextFactory : IDesignTimeDbContextFactory<MSSQLDbContext>
    {
        public MSSQLDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var builder = new DbContextOptionsBuilder<MSSQLDbContext>();
            var connectionString = configuration.GetConnectionString("Migrations");
            builder.UseSqlServer(connectionString);
            return new MSSQLDbContext(builder.Options);
        }
    }
}
