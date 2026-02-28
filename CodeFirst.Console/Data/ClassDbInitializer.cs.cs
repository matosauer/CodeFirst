using System;
using CodeFirst.Domain;
using CodeFirst.Domain.Entities;

namespace CodeFirst.Console;

public static class ClassDbInitializer
{
    public static void Initialize(BloggingContext context)
    {
        // Look for any blogs.
        if (context.Blogs.Any())
        {
            return;   // DB has been seeded
        }

        var blogs = new Blog[]
        {
            new Blog{Name="Blog 1"},
            new Blog{Name="Blog 2"},
            new Blog{Name="Blog 3"},
        };
        
        context.Blogs.AddRange(blogs);
        context.SaveChanges();
    }
}
