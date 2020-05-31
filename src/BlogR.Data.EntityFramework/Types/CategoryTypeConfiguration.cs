using BlogR.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogR.Data.EntityFramework.Types
{
    internal class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
            builder.Property(x => x.CreationTimeUtc).IsRequired();
            builder.Property(x => x.LastModifiedUtc);
        }
    }
}
