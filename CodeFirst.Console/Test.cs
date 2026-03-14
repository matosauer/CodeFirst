using CodeFirst.Domain;
using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Console
{
    public class Test
    {
        private readonly BloggingContext _db;

        public Test(BloggingContext db) => _db = db;

        public async Task RunAsync()
        {
            System.Console.WriteLine("Testing database connection...");

            var blogs = _db.Blogs.ToList();
            System.Console.WriteLine($"Found {blogs.Count} blogs.");
        }

        public async Task AddPostAsync() {
            var blog = await _db.Blogs
                        .Include(f => f.Posts)
                        .FirstOrDefaultAsync();

            if (blog != null) {
                var post = new Post { Title = "King Lear 3", Content = "Some content here 2" };

                if (blog.Posts.Any())
                {
                    var fp = blog.Posts.First();
                    fp.Title = post.Title;
                    fp.Content = post.Content;
                }
                else
                {
                    blog.Posts.Add(post);                    
                }

                await _db.SaveChangesAsync();
            }
        }
    }
}
