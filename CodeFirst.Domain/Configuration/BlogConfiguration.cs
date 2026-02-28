using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Domain.Configuration
{
    
    internal class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder
                .ToTable("Blogs")
                .Property(p=>p.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
