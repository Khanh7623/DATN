using IndividualBlog.Data.Configurations;
using IndividualBlog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndividualBlog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigurationsPost());
            modelBuilder.ApplyConfiguration(new ConfigurationsPostInCategory());
            modelBuilder.ApplyConfiguration(new ConfigurationsCategory());
            modelBuilder.ApplyConfiguration(new ConfigurationsComment());
            modelBuilder.ApplyConfiguration(new ConfigurationsTagInPost());
            modelBuilder.ApplyConfiguration(new ConfigurationsTag());
            modelBuilder.ApplyConfiguration(new ConfigurationsUser());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostInCategory> PostInCategories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments  { get; set; }
        public DbSet<TagInPost> TagInPosts  { get; set; }
        public DbSet<Tag> Tags { get; set; }


    }
}
