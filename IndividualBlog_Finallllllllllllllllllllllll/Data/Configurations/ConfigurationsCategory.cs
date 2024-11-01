using IndividualBlog.Models;
using IndividualBlog.Utilties.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace IndividualBlog.Data.Configurations
{
    public class ConfigurationsCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Title).IsRequired().IsUnicode().HasMaxLength(250);
            builder.Property(x => x.Description).IsUnicode();
            builder.Property(x => x.Slug).IsUnicode().IsRequired();
            builder.Property(x => x.Created_At).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Updated_At).HasDefaultValue(DateTime.Now);
        }
    }
}
