using CodeFirst.Domain;

namespace CodeFirst.Console
{
    public class Worker
    {
        private readonly BloggingContext _db;

        public Worker(BloggingContext db) => _db = db;

        public void Run()
        {
            var blogs = _db.Blogs.ToList();
            System.Console.WriteLine($"Found {blogs.Count} users.");

            System.Console.WriteLine("Hello CodeFirst.Console");
        }
    }
}
