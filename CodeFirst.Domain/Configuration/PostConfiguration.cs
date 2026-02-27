using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Domain.Configuration
{
    
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p=>p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p=>p.Content).HasMaxLength(2000);

            // required one-to-many relationship with Blog
            builder.HasOne(p => p.Blog)
                   .WithMany(b => b.Posts)
                   .HasForeignKey(p => p.BlogId)
                   .IsRequired();
        }
    }
}
