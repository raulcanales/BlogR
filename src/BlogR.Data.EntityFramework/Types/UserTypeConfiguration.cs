using BlogR.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogR.Data.EntityFramework.Types
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(160);
            builder.Property(x => x.Salt).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(160);
            builder.Property(x => x.Nickname).IsRequired().HasMaxLength(40);
            builder.HasMany(x => x.Comments).WithOne(x => x.Author).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
