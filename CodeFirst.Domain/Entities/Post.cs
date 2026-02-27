namespace CodeFirst.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }

        // foreign key property (non-nullable)
        public int BlogId { get; set; }

        // navigation property
        //public required Blog Blog { get; set; }
    }
}
