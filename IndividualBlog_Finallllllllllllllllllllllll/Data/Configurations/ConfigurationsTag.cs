using IndividualBlog.Models;
using IndividualBlog.Utilties.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndividualBlog.Data.Configurations
{
    public class ConfigurationsTag : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(20);
            builder.Property(x => x.Slug).IsRequired().IsUnicode();
        }
    }
}
