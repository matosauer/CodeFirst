using CodeFirst.Domain.Configuration;
using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Domain
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new BlogConfiguration());


        }
    }
}
