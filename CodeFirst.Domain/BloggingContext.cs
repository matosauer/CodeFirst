using CodeFirst.Domain.Configuration;
using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Domain
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }

        public DbSet<Blog> Blogs => Set<Blog>();
        public DbSet<Post> Posts => Set<Post>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

#if DEVELOPMENT
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
#endif

            //modelBuilder.Entity<Blog>()
            //   .HasMany(f => f.Posts)
            //   .WithOne(s => s.Blog)
            //   .HasForeignKey(s => s.BlogId);

        }
    }
}
