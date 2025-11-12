namespace CodeFirst.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string? Name { get; set; }

        //public virtual List<Post> Posts { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}
