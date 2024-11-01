using IndividualBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndividualBlog.Data.Configurations
{
    public class ConfigurationsTagInPost : IEntityTypeConfiguration<TagInPost>
    {
        public void Configure(EntityTypeBuilder<TagInPost> builder)
        {
            builder.HasKey(x => new { x.PostId, x.TagId });
            builder.HasOne(x => x.Post).WithMany(x => x.TagInPosts).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Tag).WithMany(x => x.TagInPosts).HasForeignKey(x => x.TagId);
        }
    }
}
