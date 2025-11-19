using CodeFirst.Domain;
using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Console
{
    public class Worker
    {
        private readonly BloggingContext _db;

        public Worker(BloggingContext db) => _db = db;

        public async Task RunAsync()
        {
            System.Console.WriteLine("Hello CodeFirst.Console");

            //var blogs = _db.Blogs.ToList();
            //System.Console.WriteLine($"Found {blogs.Count} users.");

            await TestSomething();

        }

        private async Task TestSomething() {
            //using (var db = new TestContext())
            //{

            //when lazy loading is enabled will load posts as well
            //var blog = _db.Blogs.Find(1);

            var blog = await _db.Blogs
                        .Include(f => f.Posts)
                        .FirstOrDefaultAsync(f => f.BlogId == 1);

            if (blog != null) {

                var post = new Post { Title = "King Lear 2", Content = "Some content here 2" };

                if (blog.Posts.Any())
                {
                    var fp = blog.Posts.First();
                    //fp.Title = post.Title;
                    //fp.Content = post.Content;

                    _db.Entry(fp).CurrentValues.SetValues(post);
                }
                else
                {
                    //blog.Posts.Add(post);

                    _db.Add(post);                    
                }

                await _db.SaveChangesAsync();

            }
        }
    }
}
