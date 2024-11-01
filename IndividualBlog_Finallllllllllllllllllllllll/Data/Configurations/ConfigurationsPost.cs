using IndividualBlog.Models;
using IndividualBlog.Utilties.Common;
using IndividualBlog.Utilties.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace IndividualBlog.Data.Configurations
{
    public class ConfigurationsPost : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Title).IsRequired().IsUnicode().HasMaxLength(250);
            builder.Property(x => x.Summary).IsUnicode().IsRequired();
            builder.Property(x => x.Content).IsUnicode().IsRequired();
            builder.Property(x => x.Slug).IsUnicode().IsRequired();
            builder.Property(x => x.Created_At).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Updated_At).HasDefaultValue(DateTime.Now);
            builder.HasOne(x=>x.User).WithMany(x=>x.Posts).HasForeignKey(x=>x.UserId);

            

        }


    }
}
