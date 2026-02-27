namespace CodeFirst.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public required string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Post> Posts { get; set; } = [];
    }
}