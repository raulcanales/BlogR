using BlogR.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogR.Data.EF.Types
{
    internal class PostTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(160);
            builder.Property(x => x.Summary).IsRequired().HasMaxLength(460);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(160);
            builder.Property(x => x.ViewCount).IsRequired();
            builder.Property(x => x.CreationTimeUtc).IsRequired();
            builder.Property(x => x.LastModifiedUtc);
            builder.HasOne(x => x.Author).WithMany(x => x.Posts);
        }
    }
}
