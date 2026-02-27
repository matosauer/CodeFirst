namespace CodeFirst.Domain.Entities
{
    public class Blog
    {
        public Guid BlogId { get; set; }
        public required string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Post> Posts { get; set; } = [];
    }
}