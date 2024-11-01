using IndividualBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IndividualBlog.Data.Configurations
{
    public class ConfigurationsComment : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired().IsUnicode().HasMaxLength(250);
            builder.Property(x => x.Created_At).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Updated_At).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ParentId).HasDefaultValue(0);

            builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
