using BlogR.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.Data.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Linq;

namespace BlogR.Data.EF.MySQL
{
    public class MySQLDbContext : AppDbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options) : base(ChangeOptionsType<AppDbContext>(options))
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Post>().ToTable("Posts");

            base.OnModelCreating(builder);
        }

        protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            var sqlExt = options.Extensions.FirstOrDefault(e => e is MySQLOptionsExtension);
            if (sqlExt == null)
                throw (new Exception("Failed to retrieve SQL connection string for base Context"));

            return new DbContextOptionsBuilder<T>()
                        .UseMySQL(((MySQLOptionsExtension)sqlExt).ConnectionString)
                        .Options;
        }
    }

    public class BloggingContextFactory : IDesignTimeDbContextFactory<MySQLDbContext>
    {
        public MySQLDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MySQLDbContext>();
            //optionsBuilder.UseMySQL(CONNECTIONSTRING GOES HERE);
            return new MySQLDbContext(optionsBuilder.Options);
        }
    }
}
