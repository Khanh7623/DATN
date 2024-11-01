using IndividualBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace IndividualBlog.Data.Configurations
{
    public class ConfigurationsUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirtName).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().IsUnicode().HasMaxLength(150);
            builder.Property(x => x.Adress).IsUnicode().HasMaxLength(150);
            builder.Property(x => x.Avatar).IsUnicode().HasMaxLength(250);
            builder.Property(x => x.Created_At).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Updated_At).HasDefaultValue(DateTime.Now);

        }
    }
}
