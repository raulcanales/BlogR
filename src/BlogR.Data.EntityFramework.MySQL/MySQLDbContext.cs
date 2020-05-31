using BlogR.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Linq;

namespace BlogR.Data.EntityFramework.MySQL
{
    public class MySQLDbContext : AppDbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options) : base(ChangeOptionsType<AppDbContext>(options))
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
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
}
