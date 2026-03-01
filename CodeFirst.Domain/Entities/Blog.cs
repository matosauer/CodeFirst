namespace CodeFirst.Domain.Entities
{
    public enum State
    {
        Draft,
        Published, 
    }

    public class Blog
    {
        public Guid BlogId { get; set; }
        public required string Name { get; set; }

        public string? Description { get; set; }

        public State State { get; set; } = State.Draft;

        public ICollection<Post> Posts { get; set; } = [];
    }
}