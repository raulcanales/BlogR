using BlogR.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogR.Data.EntityFramework.Types
{
    internal class CommentTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(160);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.CreationTimeUtc).IsRequired();
            builder.Property(x => x.LastModifiedUtc);
            builder.HasOne(x => x.ParentComment);
            builder.HasOne(x => x.Author).WithMany(x => x.Comments).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Post).WithMany(x => x.Comments);
        }
    }
}
