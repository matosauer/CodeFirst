namespace CodeFirst.Domain.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }

        // foreign key property (non-nullable)
        public Guid BlogId { get; set; }

        // navigation property
        //public required Blog Blog { get; set; }
    }
}
