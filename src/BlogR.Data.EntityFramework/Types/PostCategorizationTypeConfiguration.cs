using BlogR.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogR.Data.EntityFramework.Types
{
    internal class PostCategorizationTypeConfiguration : IEntityTypeConfiguration<PostCategorization>
    {
        public void Configure(EntityTypeBuilder<PostCategorization> builder)
        {
            builder.HasKey(x => new { x.PostId, x.CategoryId });
            builder.HasOne(x => x.Post).WithMany(x => x.PostCategorization);
            builder.HasOne(x => x.Category).WithMany(x => x.PostCategorization);
        }
    }
}
