namespace CodeFirst.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string? Name { get; set; }


        //lazy
        //public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<Post> Posts { get; set; } = [];

    }
}
