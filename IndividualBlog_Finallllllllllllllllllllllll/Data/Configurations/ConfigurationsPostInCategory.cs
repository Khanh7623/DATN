using IndividualBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndividualBlog.Data.Configurations
{
    public class ConfigurationsPostInCategory : IEntityTypeConfiguration<PostInCategory>
    {
        public void Configure(EntityTypeBuilder<PostInCategory> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.PostId });
            builder.HasOne(x => x.Category).WithMany(x => x.PostInCategories).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Post).WithMany(x => x.PostInCategories).HasForeignKey(x => x.PostId);
        }
    }
}
