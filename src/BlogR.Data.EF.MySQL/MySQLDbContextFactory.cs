using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BlogR.Data.EF.MySQL
{
    public class MySQLDbContextFactory : IDesignTimeDbContextFactory<MySQLDbContext>
    {
        public MySQLDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var builder = new DbContextOptionsBuilder<MySQLDbContext>();
            var connectionString = configuration.GetConnectionString("Migrations");
            builder.UseMySQL(connectionString);
            return new MySQLDbContext(builder.Options);
        }
    }
}
